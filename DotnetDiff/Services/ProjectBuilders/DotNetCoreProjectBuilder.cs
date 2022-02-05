using DotnetDiff.Models.Projects;

namespace DotnetDiff.Services.ProjectBuilders
{
    /// <summary>
    /// .NET Core project builder
    /// </summary>
    public class DotNetCoreProjectBuilder : ProjectBuilder<DotNetCoreProject>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="builderPath">A path to the builder</param>
        /// <param name="buildingArguments">The build command that used by the builder</param>
        public DotNetCoreProjectBuilder(string builderPath, string buildingArguments) : base(builderPath, buildingArguments)
        {
        }

        public override string GetBuildingArguments(string buildingCommand, string projectFilePath, string outputFolder) => 
            $"{buildingCommand} {projectFilePath} --output {outputFolder}";
    }
}