using DotnetDiff.Models;

namespace DotnetDiff.Services.ProjectSearchers
{
    public interface IProjectsSearcher
    {
        IEnumerable<Project> GetChangedProjects(IEnumerable<SourceCodeFile> sourceCodeFiles);
    }
}