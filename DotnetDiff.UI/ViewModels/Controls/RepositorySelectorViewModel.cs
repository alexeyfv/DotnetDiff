using DotnetDiff.Models.Commits;
using DotnetDiff.Models.SourceCodeFiles;
using DotnetDiff.Services.VersionControlSystems;
using DotnetDiff.UI.ViewModels.MediatR.Notifications;
using MediatR;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetDiff.UI.ViewModels.Controls
{
    public class RepositorySelectorViewModel : MvxViewModel
    {
        private string repo = string.Empty;

        private MvxCommand? readCommitsCommand;

        private MvxAsyncCommand? getChangedFilesCommand;

        private IEnumerable<SourceCodeFile> sourceCodeFiles = Enumerable.Empty<SourceCodeFile>();

        private IEnumerable<GitCommit> commitsFrom = Enumerable.Empty<GitCommit>();

        private IEnumerable<GitCommit> commitsTo = Enumerable.Empty<GitCommit>();

        private GitCommit? selectedCommitFrom;

        private GitCommit? selectedCommitTo;
        
        private Git? git;

        private readonly IMediator mediator;

        public string RepositoryDirectory
        {
            get => repo; 
            set
            {
               if (SetProperty(ref repo, value))
                {
                    ReadCommitsCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public MvxCommand ReadCommitsCommand => readCommitsCommand ??= new MvxCommand(ReadCommits, CanExecuteReadCommits);

        public MvxAsyncCommand GetChangedFilesCommand => getChangedFilesCommand ??= new MvxAsyncCommand(GetChangedFiles, CanExecuteGetChangedFiles);

        public IEnumerable<SourceCodeFile> SourceCodeFiles { get => sourceCodeFiles; set => SetProperty(ref sourceCodeFiles, value); }

        public IEnumerable<GitCommit> CommitsFrom { get => commitsFrom; set => SetProperty(ref commitsFrom, value); }

        public IEnumerable<GitCommit> CommitsTo { get => commitsTo; set => SetProperty(ref commitsTo, value); }

        public GitCommit? SelectedCommitFrom
        {
            get => selectedCommitFrom; 
            set
            {
                if (SetProperty(ref selectedCommitFrom, value))
                {
                    GetChangedFilesCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public GitCommit? SelectedCommitTo
        {
            get => selectedCommitTo; 
            set
            {
                if (SetProperty(ref selectedCommitTo, value))
                {
                    GetChangedFilesCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public RepositorySelectorViewModel(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        private void ReadCommits()
        {
            if (git is null)
            {
                return;
            }

            CommitsFrom = git.GetCommits(0, 50);
            CommitsTo = CommitsFrom.ToArray();
        }

        private async Task GetChangedFiles()
        {
            if (git is null || SelectedCommitFrom is null || SelectedCommitTo is null)
            {
                return;
            }

            SourceCodeFiles = await git.GetChangedFilesAsync(SelectedCommitFrom.Sha, SelectedCommitTo.Sha);
            await mediator.Publish(new RepositoryInfoNotification(RepositoryDirectory, SourceCodeFiles));
        }

        private bool CanExecuteReadCommits()
        {
            if (string.IsNullOrEmpty(RepositoryDirectory) || 
                string.IsNullOrWhiteSpace(RepositoryDirectory))
            {
                return false;
            }

            try
            {
                git = new Git(RepositoryDirectory);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private bool CanExecuteGetChangedFiles() => 
            git is not null && 
            SelectedCommitFrom is not null && 
            SelectedCommitTo is not null;

    }
}
