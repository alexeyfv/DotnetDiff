using DotnetDiff.Services.VersionControlSystems;
using LibGit2Sharp;

namespace DotnetDiff.Specs.StepDefinitions
{
    [Binding]
    public class GitStepDefinitions
    {
        private readonly Git git;

        private string firstCommit = string.Empty;

        private string lastCommit = string.Empty;

        private IEnumerable<SourceCodeFile> sourceCodeFiles = Enumerable.Empty<SourceCodeFile>();

        public GitStepDefinitions()
        {
            var repository = new Repository(Resources.GitRepository);
            git = new Git(repository);
        }

        [Given(@"the first commit is ""([^""]*)""")]
        public void GivenTheFirstCommitIs(string p0) => firstCommit = p0;

        [Given(@"the second commit is ""([^""]*)""")]
        public void GivenTheSecondCommitIs(string p0) => lastCommit = p0;

        [When(@"Git returns changed file")]
        public void WhenGitReturnsChangedFiles()
        {
            sourceCodeFiles = git.GetChangedFiles(firstCommit, lastCommit);
        }

        [Then(@"the file should be ""([^""]*)""")]
        public void ThenTheResultShouldBe(string pathes)
        {
            var files = pathes.Parse().Select(s => new SourceCodeFile(s));
            sourceCodeFiles.Should().Contain(files).And.HaveSameCount(files);
        }
    }
}
