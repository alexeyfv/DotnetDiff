using DotnetDiff.Models;
using DotnetDiff.Models.SourceCodeFiles;

namespace DotnetDiff.Services.VersionControlSystems
{
    public interface IVersionControlSystem
    {
        IEnumerable<SourceCodeFile> GetChangedFiles(string firstCommitSha, string lastCommitSha);
    }
}