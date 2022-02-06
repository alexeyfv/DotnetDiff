using DotnetDiff.Models.SourceCodeFiles;
using DotnetDiff.Services.VersionControlSystems;
using LibGit2Sharp;

namespace DotnetDiff.Specs.StepDefinitions
{
    [Scope(Tag = "Git")]
    [Binding]
    public class GitStepDefinitions
    {
        private readonly Git git;

        private string firstCommit = string.Empty;

        private string lastCommit = string.Empty;

        private IEnumerable<SourceCodeFile> actualSourceCodeFiles = Enumerable.Empty<SourceCodeFile>();

        public GitStepDefinitions()
        {
            git = new Git(Resources.GitRepository);
        }

        [Given(@"the first commit is ""([^""]*)""")]
        public void GivenTheFirstCommitIs(string p0) => firstCommit = p0;

        [Given(@"the second commit is ""([^""]*)""")]
        public void GivenTheSecondCommitIs(string p0) => lastCommit = p0;

        [When(@"Git returns changed file")]
        public void WhenGitReturnsChangedFiles()
        {
            actualSourceCodeFiles = git.GetChangedFilesAsync(firstCommit, lastCommit).Result;
        }

        [Then(@"the file should be ""([^""]*)""")]
        public void ThenTheResultShouldBe(string pathes)
        {
            var expectedSourceCodeFiles = pathes.Parse().Select(s => new SourceCodeFile(s));
            actualSourceCodeFiles.Should().Contain(expectedSourceCodeFiles).And.HaveSameCount(expectedSourceCodeFiles);
        }
    }
}
