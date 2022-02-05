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

        private bool buildIsSuccessfull = false;

        private bool assembliesAreExists = true;

        private string? outputFolder;

        public DotNetCoreProjectBuilderStepDefinitions(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            this.specFlowOutputHelper = specFlowOutputHelper ?? throw new ArgumentNullException(nameof(specFlowOutputHelper));
            dotNetCoreProjectBuilder.DataReceived += s => specFlowOutputHelper.WriteLine(s);
        }

        [Given(@"the ""([^""]*)""")]
        public void GivenThe(string projectFiles)
        {
            projects = projectFiles.Parse().Select(s => new DotNetCoreProject()
            {
                FileInfo = new FileInfo(@$"{Resources.GitRepository}{s}")
            });
        }

        [When(@"builder builds projects to ""([^""]*)""")]
        public void WhenBuilderBuildsProjectsTo(string outputFolder)
        {
            this.outputFolder = Path.GetFullPath(outputFolder);
            buildIsSuccessfull = dotNetCoreProjectBuilder.BuildAsync(projects, this.outputFolder).Result;
        }

        [Then(@"result should be true")]
        public void ThenResultShouldBeTrue()
        {
            buildIsSuccessfull.Should().BeTrue();
        }

        [Then(@"result should be false")]
        public void ThenResultShouldBeFalse()
        {
            buildIsSuccessfull.Should().BeFalse();
        }

        [Then(@"output files are exist shoukd be true")]
        public void ThenOutputFilesAreExistShoukdBeTrue()
        {
            CheckAssemblies();
            assembliesAreExists.Should().BeTrue();
        }

        [Then(@"output files are exist shoukd be false")]
        public void ThenOutputFilesAreExistShoukdBeFalse()
        {
            CheckAssemblies();
            assembliesAreExists.Should().BeFalse();
        }

        private void CheckAssemblies()
        {
            foreach (var project in projects)
            {
                if (project is null || project.FileInfo is null || string.IsNullOrEmpty(outputFolder))
                {
                    continue;
                }

                var assemblyName = Path.GetFileNameWithoutExtension(project.FileInfo.FullName);
                var assemblyPath = Path.Combine(outputFolder, assemblyName);

                assembliesAreExists = assembliesAreExists && (File.Exists($"{assemblyPath}.dll") || File.Exists($"{assemblyPath}.exe"));

                if (!assembliesAreExists)
                {
                    break;
                }
            }
        }
    }
}
