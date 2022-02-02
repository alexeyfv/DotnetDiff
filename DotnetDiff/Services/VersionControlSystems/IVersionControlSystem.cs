using DotnetDiff.Models;

namespace DotnetDiff.Services.VersionControlSystems
{
    public interface IVersionControlSystem
    {
        IEnumerable<SourceCodeFile> GetChangedFiles(string firstCommitSha, string lastCommitSha);
    }
}