using DotnetDiff.Models.SourceCodeFiles;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotnetDiff.Models.Projects;
using System.Threading.Tasks;
using MvvmCross.Commands;
using System.IO;
using DotnetDiff.Services.ProjectSearchers;
using DotnetDiff.Services.ProjectBuilders;
using DotnetDiff.UI.ViewModels.MediatR.Notifications;
using AdonisUI.Controls;

namespace DotnetDiff.UI.ViewModels.Controls
{
    public class ProjectsBuilderViewModel : MvxViewModel
    {
        private IEnumerable<Project> changedProjects = Enumerable.Empty<Project>();

        private string outputDirectory = $"C:\\";

        private MvxAsyncCommand? buildAsyncCommand;

        private MvxCommand? copyAsyncCommand;

        private string output = string.Empty;

        private readonly IProjectSearcher projectSearcher;

        private readonly IProjectBuilder projectBuilder;

        public async Task ReceiveNotification(RepositoryInfoNotification repositoryInfoNotification)
        {
            projectSearcher.UpdateRepository(repositoryInfoNotification.RepositoryDirectory);

            try
            {
                ChangedProjects = await projectSearcher.GetChangedProjectsAsync(repositoryInfoNotification.SourceCodeFiles);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        public IEnumerable<Project> ChangedProjects
        {
            get => changedProjects; set
            {
                if (SetProperty(ref changedProjects, value))
                {
                    RaisePropertyChanged(nameof(OutputDirectoryIsEnabled));
                    BuildAsyncCommand.RaiseCanExecuteChanged();
                    CopyAsyncCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string OutputDirectory
        {
            get => outputDirectory; set
            {
                if (SetProperty(ref outputDirectory, value))
                {
                    BuildAsyncCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public bool OutputDirectoryIsEnabled => ChangedProjects.Any();

        public string Output { get => output; set => SetProperty(ref output, value); }

        public MvxAsyncCommand BuildAsyncCommand => buildAsyncCommand ??= new MvxAsyncCommand(BuildAsync, CanExecuteBuildAsync, allowConcurrentExecutions: true);

        public MvxCommand CopyAsyncCommand => copyAsyncCommand ??= new MvxCommand(CopyAsync, CanExecuteCopyAsync);

        public ProjectsBuilderViewModel(
            IProjectSearcher projectSearcher,
            IProjectBuilder projectBuilder)
        {
            this.projectSearcher = projectSearcher ?? throw new ArgumentNullException(nameof(projectSearcher));
            this.projectBuilder = projectBuilder ?? throw new ArgumentNullException(nameof(projectBuilder));
            projectBuilder.DataReceived += o => Output += $"\n{o}";
        }

        private async Task BuildAsync()
        {
            Output = string.Empty;

            try
            {
                await projectBuilder.BuildAsync(ChangedProjects, OutputDirectory);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        private bool CanExecuteBuildAsync()
        {
            if (string.IsNullOrEmpty(OutputDirectory) ||
                string.IsNullOrWhiteSpace(OutputDirectory) ||
                !ChangedProjects.Any())
            {
                return false;
            }

            return true;
        }

        private void CopyAsync()
        {
            System.Windows.Clipboard.SetText(string.Join("\n", ChangedProjects.Select(p => p.Name)));
        }

        private bool CanExecuteCopyAsync() => ChangedProjects.Any();
    }
}
