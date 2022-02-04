using DotnetDiff.Models;

namespace DotnetDiff.Services.ProjectSearchers
{
    public class DotNetCoreProjectSearcher : ProjectsSearcher<DotNetCoreProject>
    {
        public DotNetCoreProjectSearcher(string repositoryDirectory) : base(repositoryDirectory)
        {
            ProjectExtension = ".csproj";
        }

        public override string ProjectExtension { get; protected set; }
    }
}