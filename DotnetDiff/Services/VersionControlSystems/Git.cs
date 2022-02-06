using DotnetDiff.Models;
using DotnetDiff.Models.Commits;
using DotnetDiff.Models.SourceCodeFiles;

namespace DotnetDiff.Services.VersionControlSystems
{
    /// <summary>
    /// Git
    /// </summary>
    public class Git : VersionControlSystem<GitCommit>
    {
        private readonly LibGit2Sharp.Repository repository;

        /// <summary>
        /// Initialize Git repository
        /// </summary>
        /// <param name="repositoryDirectory">Git repository directory</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Git(string repositoryDirectory)
        {
            if (string.IsNullOrEmpty(repositoryDirectory))
            {
                throw new ArgumentException($"'{nameof(repositoryDirectory)}' cannot be null or empty.", nameof(repositoryDirectory));
            }

            repository = new LibGit2Sharp.Repository(repositoryDirectory);
        }

        public override async Task<IEnumerable<SourceCodeFile>> GetChangedFilesAsync(string firstCommitSha, string lastCommitSha) => await Task.Run(() =>
        {
            var list = new List<SourceCodeFile>();

            var lastCommit = repository.Commits.FirstOrDefault(c => c.Sha == lastCommitSha);
            var firstCommit = repository.Commits.FirstOrDefault(c => c.Sha == firstCommitSha);

            if (lastCommit == null || firstCommit == null)
            {
                return list;
            }

            var treeChanges = repository.Diff.Compare<LibGit2Sharp.TreeChanges>(firstCommit.Tree, lastCommit.Tree);

            list.AddRange(treeChanges.Added.Select(e => new SourceCodeFile(e.Path)));
            list.AddRange(treeChanges.Deleted.Select(e => new SourceCodeFile(e.Path)));
            list.AddRange(treeChanges.Modified.Select(e => new SourceCodeFile(e.Path)));
            list.AddRange(treeChanges.Renamed.Select(e => new SourceCodeFile(e.Path)));

            return list;
        });

        public override IEnumerable<GitCommit> GetCommits(int startIndex, int count)
        {
            var currentIndex = 0;
            var currentCount = 0;

            foreach (var commit in repository.Commits)
            {
                if (currentIndex >= startIndex)
                {
                    yield return new GitCommit(commit.Author.Name, commit.Author.When, commit.MessageShort, commit.Sha);
                    currentCount++;
                }

                if (currentCount == count)
                {
                    break;
                }

                currentIndex++;
            }

            yield break;
        }
    }
}