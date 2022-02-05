using DotnetDiff.Models.Projects;

namespace DotnetDiff.Services.ProjectSearchers
{
    /// <summary>
    /// .NET Core project searcher
    /// </summary>
    public class DotNetCoreProjectSearcher : ProjectSearcher<DotNetCoreProject>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="repositoryDirectory">Repository directory</param>
        public DotNetCoreProjectSearcher(string repositoryDirectory) : base(repositoryDirectory)
        {
            ProjectExtension = ".csproj";
        }

        public override string ProjectExtension { get; protected set; }
    }
}