using System.Text.RegularExpressions;

namespace Aurora.Engine.Utilities
{
    public static class StringExtensions
    {
        /// <summary>
        /// Gets the sanitized value for the input string. It will preserves spaces and only leave [a-zA-Z0-9] characters.
        /// </summary>
        /// <param name="input">The string to be sanitized.</param>
        /// <returns>The sanitized string.</returns>
        public static string Sanitize(this string input)
        {
            var excludePattern = @"[^a-zA-Z0-9 ]";

            input = input.Replace("-", " ");
            input = Regex.Replace(input, excludePattern, string.Empty);

            return input.Trim();
        }

        /// <summary>
        /// Gets a value whether the input string is an element identifier, indicated by starting with 'ID_'.
        /// </summary>
        /// <param name="input">The input string to be evaluated.</param>
        /// <returns>True when the string is considered to be an element id.</returns>
        public static bool IsElementIdentifier(this string input)
        {
            return input.StartsWith("ID_");
        }
    }
}