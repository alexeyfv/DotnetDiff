using DotnetDiff.Models.Projects;

namespace DotnetDiff.Services.ProjectBuilders
{
    public interface IProjectsBuilder<T> where T : Project
    {
        Task<bool> BuildAsync(IEnumerable<Project> projects);
    }
}