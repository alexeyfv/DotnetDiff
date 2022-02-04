using DotnetDiff.Models.Projects;
using DotnetDiff.Services.ProjectBuilders;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace DotnetDiff.Specs.StepDefinitions
{
    [Scope(Tag = "ProjectBuilder")]
    [Binding]
    public class DotNetCoreProjectBuilderStepDefinitions
    {
        private IEnumerable<DotNetCoreProject> projects = Enumerable.Empty<DotNetCoreProject>();

        private readonly DotNetCoreProjectBuilder dotNetCoreProjectBuilder = new(Resources.DotNetCoreBuilder, Resources.DotNetCoreBuilderArguments);
        private readonly ISpecFlowOutputHelper specFlowOutputHelper;
        private bool result = false;

        public DotNetCoreProjectBuilderStepDefinitions(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            this.specFlowOutputHelper = specFlowOutputHelper ?? throw new ArgumentNullException(nameof(specFlowOutputHelper));
            dotNetCoreProjectBuilder.DataReceived += s => specFlowOutputHelper.WriteLine(s);
        }

        [Given(@"the ""([^""]*)""")]
        public void GivenThe(string projects)
        {
            this.projects = projects.Parse().Select(s => new DotNetCoreProject()
            {
                FileInfo = new FileInfo(@$"{Resources.GitRepository}{s}")
            });

            foreach (var project in this.projects)
            {
                specFlowOutputHelper.WriteLine(project.FileInfo.FullName);
            }
        }

        [When(@"builder builds projects")]
        public void WhenBuilderBuildsProjects()
        {
            result = dotNetCoreProjectBuilder.BuildAsync(projects).Result;
        }

        [Then(@"result should be true")]
        public void ThenResultShouldBeTrue()
        {
            result.Should().BeTrue();
        }

        [Then(@"result should be false")]
        public void ThenResultShouldBeFalse()
        {
            result.Should().BeFalse();
        }

    }
}
