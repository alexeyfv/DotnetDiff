using DotnetDiff.Models.Commits;
using DotnetDiff.Models.Projects;
using DotnetDiff.Services.ProjectBuilders;
using DotnetDiff.Services.ProjectSearchers;
using DotnetDiff.Services.VersionControlSystems;

namespace DotnetDiff.Services
{
    public abstract class DiffTracker<T> where T : Project, new()
    {
        private readonly VersionControlSystem<GitCommit> versionControlSystem;

        private readonly ProjectSearcher<T> projectSearcher;

        private readonly ProjectBuilder<T> projectsBuilder;

        public DiffTracker(
            VersionControlSystem<GitCommit> versionControlSystem,
            ProjectSearcher<T> searcher,
            ProjectBuilder<T> projectsBuilder)
        {
            this.versionControlSystem = versionControlSystem ?? throw new ArgumentNullException(nameof(versionControlSystem));
            this.projectSearcher = searcher ?? throw new ArgumentNullException(nameof(searcher));
            this.projectsBuilder = projectsBuilder ?? throw new ArgumentNullException(nameof(projectsBuilder));
        }

        public virtual async void Rebuild()
        {
            var changedFiles = await versionControlSystem.GetChangedFilesAsync(string.Empty, string.Empty);
            var changedProjects = await projectSearcher.GetChangedProjectsAsync(changedFiles);
            var result = await projectsBuilder.BuildAsync(changedProjects, string.Empty);
        }
    }
}