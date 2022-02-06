using DotnetDiff.Models.Projects;
using DotnetDiff.Models.SourceCodeFiles;

namespace DotnetDiff.Services.ProjectSearchers
{
    /// <summary>
    /// Provides mechanism for searching projects inside repository
    /// </summary>
    public interface IProjectSearcher
    {
        /// <summary>
        /// Project file extension
        /// </summary>
        string ProjectExtension { get; }

        /// <summary>
        /// Repository directory info
        /// </summary>
        DirectoryInfo? RepositoryDirectory { get; }

        /// <summary>
        /// Returns collection of changed projects for provided source code files
        /// </summary>
        /// <param name="sourceCodeFiles">Collection of source code files</param>
        /// <returns>Collection of changed projects</returns>
        Task<IEnumerable<Project>> GetChangedProjectsAsync(IEnumerable<SourceCodeFile> sourceCodeFiles);

        /// <summary>
        /// Updates repository
        /// </summary>
        /// <param name="repositoryDirectory">Repository directory</param>
        void UpdateRepository(string repositoryDirectory);
    }
}