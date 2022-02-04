﻿using DotnetDiff.Models.Projects;
using System.Diagnostics;

namespace DotnetDiff.Services.ProjectBuilders
{
    public abstract class ProjectBuilder<T> : IProjectsBuilder<T> where T : Project, new()
    {
        private bool buildingIsSuccess;

        /// <summary>
        /// 
        /// </summary>
        public Action<string>? DataReceived;

        /// <summary>
        /// 
        /// </summary>
        public string BuilderPath { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public string BuildingCommand { get; protected set; }

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