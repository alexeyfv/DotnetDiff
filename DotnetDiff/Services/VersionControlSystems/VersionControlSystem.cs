using DotnetDiff.Models;
using DotnetDiff.Models.SourceCodeFiles;

namespace DotnetDiff.Services.VersionControlSystems
{
    public abstract class VersionControlSystem
    {
        /// <summary>
        /// Returns collection of source code files that were changed between <paramref name="firstCommitSha"/> and <paramref name="lastCommitSha"/>
        /// </summary>
        /// <param name="firstCommitSha">SHA for the first commit</param>
        /// <param name="lastCommitSha">SHA for the last commit</param>
        /// <returns>Collection of source code files</returns>
        public abstract Task<IEnumerable<SourceCodeFile>> GetChangedFilesAsync(string firstCommitSha, string lastCommitSha);
    }
}