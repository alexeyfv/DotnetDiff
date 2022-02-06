using DotnetDiff.UI.ViewModels.Controls;
using DotnetDiff.UI.ViewModels.MediatR.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotnetDiff.UI.ViewModels.MediatR.Handlers
{
    class RepositoryInfoHandler : INotificationHandler<RepositoryInfoNotification>
    {
        private readonly ProjectsBuilderViewModel projectsBuilderViewModel;

        public RepositoryInfoHandler(ProjectsBuilderViewModel projectsBuilderViewModel)
        {
            this.projectsBuilderViewModel = projectsBuilderViewModel ?? throw new ArgumentNullException(nameof(projectsBuilderViewModel));
        }

        public async Task Handle(RepositoryInfoNotification notification, CancellationToken cancellationToken) => 
            await projectsBuilderViewModel.ReceiveNotification(notification);
    }
}
