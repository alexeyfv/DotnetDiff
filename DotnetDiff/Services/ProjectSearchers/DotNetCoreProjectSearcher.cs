using DotnetDiff.Models.Projects;

namespace DotnetDiff.Services.ProjectSearchers
{
    /// <summary>
    /// .NET Core project searcher
    /// </summary>
    public class DotNetCoreProjectSearcher : ProjectSearcher<DotNetCoreProject>
    {
        public override string ProjectExtension { get; protected set; } = ".csproj";
    }
}