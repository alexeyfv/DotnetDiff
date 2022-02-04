using DotnetDiff.Models;

namespace DotnetDiff.Services.ProjectSearchers
{
    public interface IProjectsSearcher<T> where T : Project
    {
        IEnumerable<T> GetChangedProjects(IEnumerable<SourceCodeFile> sourceCodeFiles);
    }
}