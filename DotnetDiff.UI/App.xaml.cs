using DotnetDiff.Services.ProjectBuilders;
using DotnetDiff.Services.ProjectSearchers;
using DotnetDiff.UI.ViewModels.Controls;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace DotnetDiff.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static ServiceProvider? serviceProvider;

        public App()
        {
            var servicesCollection = new ServiceCollection();
            ConfigureServices(servicesCollection);
            serviceProvider = servicesCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSingleton<RepositorySelectorViewModel>();
            services.AddSingleton<ProjectsBuilderViewModel>();

            services.AddSingleton<IProjectSearcher, DotNetCoreProjectSearcher>();
            services.AddSingleton<IProjectBuilder>(new DotNetCoreProjectBuilder("dotnet", "build"));

            services.AddSingleton<MainWindow>();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider?.GetService<MainWindow>();
            mainWindow?.Show();
        }

        public static RepositorySelectorViewModel? RepositorySelectorViewModel => serviceProvider?.GetService<RepositorySelectorViewModel>();

        public static ProjectsBuilderViewModel? ProjectsBuilderViewModel => serviceProvider?.GetService<ProjectsBuilderViewModel>();
    }
}
