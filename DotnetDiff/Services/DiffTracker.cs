using DotnetDiff.Models.Projects;
using DotnetDiff.Services.ProjectBuilders;
using DotnetDiff.Services.ProjectSearchers;
using DotnetDiff.Services.VersionControlSystems;

namespace DotnetDiff.Services
{
    class DiffTracker<T>: IDiffTracker where T : Project
    {
        private readonly IVersionControlSystem versionControlSystem;

        private readonly IProjectsSearcher<T> projectSearcher;

        private readonly IProjectsBuilder<T> projectsBuilder;

        public DiffTracker(
            IVersionControlSystem versionControlSystem,
            IProjectsSearcher<T> searcher,
            IProjectsBuilder<T> projectsBuilder)
        {
            this.versionControlSystem = versionControlSystem ?? throw new ArgumentNullException(nameof(versionControlSystem));
            this.projectSearcher = searcher ?? throw new ArgumentNullException(nameof(searcher));
            this.projectsBuilder = projectsBuilder ?? throw new ArgumentNullException(nameof(projectsBuilder));
        }

        public virtual void Rebuild()
        {
            var changedFiles = versionControlSystem.GetChangedFiles(string.Empty, string.Empty);
            var changedProjects = projectSearcher.GetChangedProjects(changedFiles);
            projectsBuilder.Build(changedProjects);
        }
    }
}