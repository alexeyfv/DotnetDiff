using DotnetDiff.Models;
using DotnetDiff.Services.VersionControlSystems;
using LibGit2Sharp;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

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

        [When(@"the version control system gets changed files")]
        public void WhenTheVersionControlSystemGetsChangedFiles()
        {
            sourceCodeFiles = git.GetChangedFiles(firstCommit, lastCommit);
        }

        [Then(@"the result should be ""([^""]*)""")]
        public void ThenTheResultShouldBe(string p0)
        {
            var list = new List<SourceCodeFile>() { new SourceCodeFile(p0) };
            sourceCodeFiles.Should().Contain(list).And.HaveSameCount(list);
        }
    }
}
