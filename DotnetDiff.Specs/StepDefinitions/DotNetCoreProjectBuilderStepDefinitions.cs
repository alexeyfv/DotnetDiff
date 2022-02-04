using DotnetDiff.Models.Projects;
using DotnetDiff.Services.ProjectBuilders;
using System;
using TechTalk.SpecFlow;

namespace DotnetDiff.Specs.StepDefinitions
{
    [Scope(Tag ="ProjectBuilder")]
    [Binding]
    public class DotNetCoreProjectBuilderStepDefinitions
    {
        private IEnumerable<DotNetCoreProject> projects = Enumerable.Empty<DotNetCoreProject>();

        private readonly DotNetCoreProjectBuilder dotNetCoreProjectBuilder = new();

        private bool result = false;

        [Given(@"the ""([^""]*)""")]
        public void GivenThe(string projects)
        {
            this.projects = projects.Parse().Select(s => new DotNetCoreProject() 
            {
                FileInfo = new FileInfo(@$"{Resources.GitRepository}{s}") 
            });
        }

        [When(@"builder builds projects")]
        public void WhenBuilderBuildsProjects()
        {
            result = dotNetCoreProjectBuilder.Build(projects);
        }

        [Then(@"result should be true")]
        public void ThenResultShouldBeTrue()
        {
            result.Should().BeTrue();
        }
    }
}
