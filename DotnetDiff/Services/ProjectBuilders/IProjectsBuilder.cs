using DotnetDiff.Models.Projects;

namespace DotnetDiff.Services.ProjectBuilders
{
    public interface IProjectsBuilder<T> where T : Project
    {
        bool Build(IEnumerable<Project> projects);
    }
}