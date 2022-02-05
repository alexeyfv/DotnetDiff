using DotnetDiff.Models.Projects;
using System.Diagnostics;

namespace DotnetDiff.Services.ProjectBuilders
{
    /// <summary>
    /// A base class that implements project bulding
    /// </summary>
    /// <typeparam name="T">Project type</typeparam>
    public abstract class ProjectBuilder<T> where T : Project, new()
    {
        private bool buildingIsSuccess;

        /// <summary>
        /// This action is invoked when the builder returns any data from the standart output
        /// </summary>
        public Action<string>? DataReceived;

        /// <summary>
        /// A path to the builder
        /// </summary>
        public string BuilderPath { get; protected set; }

        /// <summary>
        /// The build command that used by the builder
        /// </summary>
        public string BuildingCommand { get; protected set; }

        /// <summary>
        /// Initialize project builder instance
        /// </summary>
        /// <param name="builderPath">A path to the builder</param>
        /// <param name="buildingCommand">The build command that used by the builder</param>
        /// <exception cref="ArgumentException"></exception>
        public ProjectBuilder(string builderPath, string buildingCommand)
        {
            if (string.IsNullOrEmpty(builderPath))
            {
                throw new ArgumentException($"'{nameof(builderPath)}' cannot be null or empty.", nameof(builderPath));
            }

            if (string.IsNullOrEmpty(buildingCommand))
            {
                throw new ArgumentException($"'{nameof(buildingCommand)}' cannot be null or empty.", nameof(buildingCommand));
            }

            BuilderPath = builderPath;
            BuildingCommand = buildingCommand;
        }

        /// <summary>
        /// Returns building arguments string
        /// </summary>
        /// <param name="buildingCommand">Building command</param>
        /// <param name="projectFilePath">Project file path</param>
        /// <returns>Building arguments string</returns>
        public abstract string GetBuildingArguments(string buildingCommand, string projectFilePath);

        public virtual async Task<bool> BuildAsync(IEnumerable<Project> projects)
        {
            buildingIsSuccess = true;

            foreach (var project in projects)
            {
                if (project is null || project.FileInfo is null)
                {
                    continue;
                }

                using var process = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = BuilderPath,
                        Arguments = GetBuildingArguments(BuildingCommand, project.FileInfo.FullName),
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true
                    }
                };


                process.OutputDataReceived += Process_OutputDataReceived;

                try
                {
                    process.Start();
                    process.BeginOutputReadLine();
                    await process.WaitForExitAsync();
                    buildingIsSuccess = buildingIsSuccess && process.ExitCode == 0;
                }
                catch (Exception e)
                {
                    buildingIsSuccess = false;
                    OnDataReceived($"Building process throws an exception:\n{e.Message}");
                }
                finally
                {
                    process.OutputDataReceived -= Process_OutputDataReceived;
                }
            }

            return buildingIsSuccess;
        }

        private void OnDataReceived(string data) => DataReceived?.Invoke(data);

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            OnDataReceived(e.Data ?? string.Empty);
        }
    }
}