using DotnetDiff.Models;
using DotnetDiff.Models.Commits;
using DotnetDiff.Models.SourceCodeFiles;

namespace DotnetDiff.Services.VersionControlSystems
{
    /// <summary>
    /// A base class for the version control system
    /// </summary>
    /// <typeparam name="C">Commit type</typeparam>
    public abstract class VersionControlSystem<C> where C: Commit
    {
        /// <summary>
        /// Returns collection of source code files that were changed between <paramref name="firstCommitSha"/> and <paramref name="lastCommitSha"/>
        /// </summary>
        /// <param name="firstCommitSha">SHA for the first commit</param>
        /// <param name="lastCommitSha">SHA for the last commit</param>
        /// <returns>Collection of source code files</returns>
        public abstract Task<IEnumerable<SourceCodeFile>> GetChangedFilesAsync(string firstCommitSha, string lastCommitSha);

        /// <summary>
        /// Returns collection of commits for the current selected branch
        /// </summary>
        /// <param name="startIndex">Zero-based index of the commit starting from HEAD</param>
        /// <param name="count">Number of commits</param>
        /// <returns>Collection of commits</returns>
        public abstract IEnumerable<C> GetCommits(int startIndex, int count);
    }
}