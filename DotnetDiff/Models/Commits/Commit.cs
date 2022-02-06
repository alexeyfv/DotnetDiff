using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetDiff.Models.Commits
{
    public abstract class Commit
    {
        public Commit(string author, DateTimeOffset timestamp, string message)
        {

            if (string.IsNullOrEmpty(author))
            {
                throw new ArgumentException($"'{nameof(author)}' cannot be null or empty.", nameof(author));
            }

            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException($"'{nameof(message)}' cannot be null or empty.", nameof(message));
            }

            Author = author;
            Message = message;
            Timestamp = timestamp;
        }

        /// <summary>
        /// Commit message
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Author of this commit
        /// </summary>
        public string Author { get; }

        /// <summary>
        /// Commit timestamp
        /// </summary>
        public DateTimeOffset Timestamp { get; set; }
    }

    public class GitCommit : Commit
    {
        public GitCommit(string author, DateTimeOffset timestamp, string message, string sha) : base(author, timestamp, message)
        {
            Sha = sha;
        }

        /// <summary>
        /// SHA of this commit
        /// </summary>
        public string Sha { get; }
    }
}
