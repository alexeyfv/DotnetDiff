namespace DotnetDiff.Specs.Support
{
    /// <summary>
    /// Custom string extensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Parses a string with commas into a collection of strings
        /// </summary>
        /// <param name="s">A string to parse</param>
        /// <returns>Collection of strings</returns>
        public static IEnumerable<string> Parse(this string s) => s.Split(",").Select(s => s.Trim());
    }
}
