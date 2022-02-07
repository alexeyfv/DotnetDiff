using DotnetDiff.Models.Projects;
using DotnetDiff.Models.SourceCodeFiles;

namespace DotnetDiff.Services.ProjectSearchers
{
    /// <summary>
    /// A base class that implements project searching
    /// </summary>
    /// <typeparam name="T">Project type</typeparam>
    public abstract class ProjectSearcher<T> : IProjectSearcher where T : Project, new()
    {
        public abstract string ProjectExtension { get; protected set; }

        public DirectoryInfo? RepositoryDirectory { get; protected set; }

        public void UpdateRepository(string repositoryDirectory)
        {
            if (string.IsNullOrEmpty(repositoryDirectory) || string.IsNullOrWhiteSpace(repositoryDirectory))
            {
                throw new ArgumentException($"'{nameof(repositoryDirectory)}' cannot be null or empty.", nameof(repositoryDirectory));
            }

            RepositoryDirectory = new DirectoryInfo(repositoryDirectory);
        }

        public virtual async Task<IEnumerable<Project>> GetChangedProjectsAsync(IEnumerable<SourceCodeFile> sourceCodeFiles)
        {
            var projects = new List<T>();

            foreach (var sourceCodeFile in sourceCodeFiles)
            {
                var project = await SearchProjectAsync(sourceCodeFile);

                if (project is null)
                {
                    continue;
                }

                projects.Add(project);
            }

            return projects.Distinct();
        }

        /// <summary>
        /// Searches for project for provided source code file
        /// </summary>
        /// <param name="sourceCodeFile">Source code file</param>
        /// <returns>Project for provided source code file</returns>
        /// <exception cref="FileNotFoundException">Exception will throw if project will not be found</exception>
        protected virtual async Task<T?> SearchProjectAsync(SourceCodeFile sourceCodeFile) => await Task.Run(async () =>
        {
            // Search algorythm
            // 1. Check directory
            // 2. If project file is found, then return, if no then do Step 3
            // 3. Go up and do Step 1
            // 4. Repeat step 1 - 3 until reaching root repo directory

            // Get current directory for the source code file
            var fileInfo = new FileInfo(@$"{RepositoryDirectory?.FullName}\{sourceCodeFile.Path}");
            var directory = fileInfo?.Directory;

            // Flag for searching until reaching repo root directory
            bool isRepositoryDirectory;

            do
            {
                if (directory is null)
                {
                    break;
                }

                // Update flag value
                isRepositoryDirectory = directory == RepositoryDirectory;

                // Step 1. Scan directory for project file
                var project = await ScanDirectoryAsync(directory);

                // Step 2. If project is present then return it
                if (project is not null)
                {
                    return project;
                }

                // Break the loop if project file wasn't found and it was the root repo directory 
                if (isRepositoryDirectory)
                {
                    break;
                }

                // Step 3. If project is not present then go up and continue
                directory = directory.Parent;

            }
            while (!isRepositoryDirectory);

            return null;
        });

        /// <summary>
        /// Scans provided directory for project files
        /// </summary>
        /// <param name="directory">Directory to scan</param>
        /// <returns>Instance of <see cref="T"/> or <see cref="null"/> if not found</returns>
        protected virtual async Task<T?> ScanDirectoryAsync(DirectoryInfo directory) => await Task.Run(() =>
        {
            foreach (var file in directory.GetFiles())
            {
                if (string.Equals(file.Extension, ProjectExtension, StringComparison.OrdinalIgnoreCase))
                {
                    return new T() { FileInfo = file };
                }
            }

            return null;
        });
    }
}