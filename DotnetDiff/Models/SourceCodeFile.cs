namespace DotnetDiff.Models
{
    /// <summary>
    /// A base class for source code file
    /// </summary>
    public class SourceCodeFile
    {
        /// <summary>
        /// A path to the source code file
        /// </summary>
        public string Path { get; }

        public SourceCodeFile(string path)
        {
            Path = path;
        }

        public override bool Equals(object? obj) => Equals((obj as SourceCodeFile)!);

        public virtual bool Equals(SourceCodeFile obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return string.Equals(Path, obj.Path, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode() => Path.GetHashCode();
    }
}