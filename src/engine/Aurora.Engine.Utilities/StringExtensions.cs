using System.Text.RegularExpressions;

namespace Aurora.Engine.Utilities
{
    public static class StringExtensions
    {
        /// <summary>
        /// Gets the sanitized value for the input string. It will preserves spaces and only leave [a-zA-Z0-9] characters.
        /// </summary>
        /// <param name="input">The string to be normalized.</param>
        /// <returns>The normalized string.</returns>
        public static string Sanitize(this string input)
        {
            var excludePattern = @"[^a-zA-Z0-9 ]";

            input = input.Replace("-", " ");
            input = Regex.Replace(input, excludePattern, string.Empty);

            return input.Trim();
        }
    }
}