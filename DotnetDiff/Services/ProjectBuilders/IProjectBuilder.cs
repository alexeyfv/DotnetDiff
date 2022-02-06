using DotnetDiff.Models.Projects;

namespace DotnetDiff.Services.ProjectBuilders
{
    /// <summary>
    /// Provides mechanism for building projects
    /// </summary>
    public interface IProjectBuilder
    {
        /// <summary>
        /// A path to the builder
        /// </summary>
        string BuilderPath { get; }

        /// <summary>
        /// The build command that used by the builder
        /// </summary>
        string BuildingCommand { get; }

        /// <summary>
        /// This action is invoked when the builder returns any data from the standart output
        /// </summary>
        Action<string>? DataReceived { get; set; }

        /// <summary>
        /// Starts async building
        /// </summary>
        /// <param name="projects">Collection of projects to build</param>
        /// <param name="outputFolder">Output folder</param>
        /// <returns>A task that returns true, if all the projects were builded successfully</returns>
        Task<bool> BuildAsync(IEnumerable<Project> projects, string outputFolder);
    }
}