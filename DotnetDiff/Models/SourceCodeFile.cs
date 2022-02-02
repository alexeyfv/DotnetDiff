namespace DotnetDiff.Models
{
    public class SourceCodeFile
    {
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

            return string.Equals(this.Path, obj.Path, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode() => Path.GetHashCode();
    }
}