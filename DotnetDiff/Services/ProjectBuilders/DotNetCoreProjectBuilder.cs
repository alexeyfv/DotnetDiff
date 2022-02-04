using DotnetDiff.Models.Projects;

namespace DotnetDiff.Services.ProjectBuilders
{
    public class DotNetCoreProjectBuilder : ProjectBuilder<DotNetCoreProject>
    {
        public DotNetCoreProjectBuilder(string builderPath, string buildingArguments) : base(builderPath, buildingArguments)
        {
        }

        public override string GetBuildingArguments(string buildingCommand, string projectFilePath) => $"{buildingCommand} {projectFilePath}";
    }
}