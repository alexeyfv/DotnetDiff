using DotnetDiff.Models.Projects;

namespace DotnetDiff.Services.ProjectBuilders
{
    public abstract class ProjectBuilder<T> : IProjectsBuilder<T> where T : Project, new()
    {
        public ProjectBuilder()
        {

        }

        public bool Build(IEnumerable<Project> projects)
        {
            return false;
        }

        public abstract string BuilderPath { get; protected set; }

        public abstract string BuildingOptions { get; protected set; }
    }
}