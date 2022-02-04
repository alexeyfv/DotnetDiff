using DotnetDiff.Models.Projects;
using DotnetDiff.Models.SourceCodeFiles;

namespace DotnetDiff.Services.ProjectSearchers
{
    public interface IProjectsSearcher<T> where T : Project
    {
        IEnumerable<T> GetChangedProjects(IEnumerable<SourceCodeFile> sourceCodeFiles);
    }
}