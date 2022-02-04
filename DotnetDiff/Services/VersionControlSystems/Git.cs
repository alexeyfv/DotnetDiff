using DotnetDiff.Models;
using DotnetDiff.Models.SourceCodeFiles;
using LibGit2Sharp;

namespace DotnetDiff.Services.VersionControlSystems
{
    public class Git : IVersionControlSystem
    {
        private readonly Repository repository;

        public Git(Repository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IEnumerable<SourceCodeFile> GetChangedFiles(string firstCommitSha, string lastCommitSha)
        {
            var list = new List<SourceCodeFile>();

            var lastCommit = repository.Commits.FirstOrDefault(c => c.Sha == lastCommitSha);
            var firstCommit = repository.Commits.FirstOrDefault(c => c.Sha == firstCommitSha);

            if (lastCommit == null || firstCommit == null)
            {
                return list;
            }

            var treeChanges = repository.Diff.Compare<TreeChanges>(firstCommit.Tree, lastCommit.Tree);

            list.AddRange(treeChanges.Added.Select(e => new SourceCodeFile(e.Path)));
            list.AddRange(treeChanges.Deleted.Select(e => new SourceCodeFile(e.Path)));
            list.AddRange(treeChanges.Modified.Select(e => new SourceCodeFile(e.Path)));
            list.AddRange(treeChanges.Renamed.Select(e => new SourceCodeFile(e.Path)));

            return list;
        }
    }
}