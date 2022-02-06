using DotnetDiff.Models.SourceCodeFiles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotnetDiff.UI.ViewModels.MediatR.Notifications
{
    public class RepositoryInfoNotification : INotification
    {
        public RepositoryInfoNotification(string repositoryDirectory, IEnumerable<SourceCodeFile> sourceCodeFiles)
        {
            if (string.IsNullOrEmpty(repositoryDirectory) || string.IsNullOrWhiteSpace(repositoryDirectory))
            {
                throw new ArgumentException($"'{nameof(repositoryDirectory)}' cannot be null or empty.", nameof(repositoryDirectory));
            }

            RepositoryDirectory = repositoryDirectory;
            SourceCodeFiles = sourceCodeFiles ?? throw new ArgumentNullException(nameof(sourceCodeFiles));
        }

        /// <summary>
        /// Repository directory
        /// </summary>
        public string RepositoryDirectory { get; }

        /// <summary>
        /// Collection of changed source code files
        /// </summary>
        public IEnumerable<SourceCodeFile> SourceCodeFiles { get; }
    }
}
