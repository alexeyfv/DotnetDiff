using DotnetDiff.Models.Projects;
using DotnetDiff.Models.SourceCodeFiles;

namespace DotnetDiff.Services.ProjectSearchers
{
    public abstract class ProjectsSearcher<T> : IProjectsSearcher<T> where T : Project, new()
    {
        /// <summary>
        /// Project file extension
        /// </summary>
        public abstract string ProjectExtension { get; protected set; }

        /// <summary>
        /// Repository directory info
        /// </summary>
        public DirectoryInfo RepositoryDirectory { get; }

        public ProjectsSearcher(string repositoryDirectory)
        {
            if (string.IsNullOrEmpty(repositoryDirectory))
            {
                throw new ArgumentException($"'{nameof(repositoryDirectory)}' cannot be null or empty.", nameof(repositoryDirectory));
            }            

            RepositoryDirectory = new DirectoryInfo(repositoryDirectory);
        }

        /// <summary>
        /// Returns collection of changed projects for provided source code files
        /// </summary>
        /// <param name="sourceCodeFiles">Collection of source code files</param>
        /// <returns>Collection of changed projects</returns>
        public virtual IEnumerable<T> GetChangedProjects(IEnumerable<SourceCodeFile> sourceCodeFiles)
        {
            var projects = new List<T>();

            foreach (var sourceCodeFile in sourceCodeFiles)
            {
                projects.Add(SearchProject(sourceCodeFile));
            }

            return projects.Distinct();
        }

        /// <summary>
        /// Searches for project for provided source code file
        /// </summary>
        /// <param name="sourceCodeFile">Source code file</param>
        /// <returns>Project for provided source code file</returns>
        /// <exception cref="FileNotFoundException">Exception will throw if project will not be found</exception>
        protected virtual T SearchProject(SourceCodeFile sourceCodeFile)
        {
            // Search algorythm
            // 1. Check directory
            // 2. If project file is found, then return, if no then do Step 3
            // 3. Go up and do Step 1
            // 4. Repeat step 1 - 3 until reaching root repo directory

            // Get current directory for the source code file
            var fileInfo = new FileInfo(@$"{RepositoryDirectory.FullName}\{sourceCodeFile.Path}");
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
                var project = ScanDirectory(directory);

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

            throw new FileNotFoundException("Unable to find project file");
        }

        /// <summary>
        /// Scans provided directory for project files
        /// </summary>
        /// <param name="directory">Directory to scan</param>
        /// <returns>Instance of <see cref="T"/> or <see cref="null"/> if not found</returns>
        protected virtual T? ScanDirectory(DirectoryInfo directory)
        {
            foreach (var file in directory.GetFiles())
            {
                if (string.Equals(file.Extension, ProjectExtension, StringComparison.OrdinalIgnoreCase))
                {
                    return new T() { FileInfo = file };
                }
            }

            return null;
        }
    }
}