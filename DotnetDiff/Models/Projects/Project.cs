namespace DotnetDiff.Models.Projects
{
    /// <summary>
    /// A base class for project files
    /// </summary>
    public abstract class Project
    {
        /// <summary>
        /// A path to the project file
        /// </summary>
        public FileInfo? FileInfo { get; set; }

        public override bool Equals(object? obj) => Equals((obj as Project)!);

        public virtual bool Equals(Project obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return string.Equals(FileInfo?.FullName, obj.FileInfo?.FullName, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return FileInfo == null ? 0 : FileInfo.FullName.GetHashCode();
        }
    }
}