using DotnetDiff.Models.Projects;

namespace DotnetDiff.Services.ProjectBuilders
{
    public class DotNetCoreProjectBuilder : ProjectBuilder<DotNetCoreProject>
    {
        public DotNetCoreProjectBuilder()
        {
            BuilderPath = "";
            BuildingOptions = "";
        }

        public override string BuildingOptions { get; protected set; }
        public override string BuilderPath { get; protected set; }
    }
}