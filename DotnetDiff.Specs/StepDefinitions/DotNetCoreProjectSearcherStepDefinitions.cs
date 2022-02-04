using DotnetDiff.Models.Projects;
using DotnetDiff.Models.SourceCodeFiles;
using DotnetDiff.Services.ProjectSearchers;

namespace DotnetDiff.Specs.StepDefinitions
{
    [Binding]
    public class DotNetCoreProjectSearcherStepDefinitions
    {
        private IEnumerable<SourceCodeFile> sourceCodeFiles = Enumerable.Empty<SourceCodeFile>();

        private IEnumerable<Project> actualProjects = Enumerable.Empty<Project>();

        private readonly DotNetCoreProjectSearcher dotNetCoreProjectSearcher;

        public DotNetCoreProjectSearcherStepDefinitions()
        {
            dotNetCoreProjectSearcher = new DotNetCoreProjectSearcher(Resources.GitRepository);
        }

        [Given(@"the ""([^""]*)""")]
        public void GivenThe(string sourceFiles)
        {
            sourceCodeFiles = sourceFiles.Parse().Select(s => new SourceCodeFile(s));
        }

        [When(@"searcher returns project")]
        public void WhenSearcherReturnsProject()
        {
            actualProjects = dotNetCoreProjectSearcher.GetChangedProjects(sourceCodeFiles);
        }

        [Then(@"the projects should be ""([^""]*)""")]
        public void ThenTheProjectsShouldBe(string projects)
        {
            var expectedProjects = projects.Parse().Select(s => new DotNetCoreProject() { FileInfo = new FileInfo(@$"{Resources.GitRepository}{s}") });
            actualProjects.Should().Contain(expectedProjects).And.HaveSameCount(expectedProjects);
        }
    }
}
