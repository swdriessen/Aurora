namespace Aurora.Engine.Utilities
{
    public static class InlineReplacementExtensions
    {
        /// <summary>
        /// Performs inline replacement of case-sensitive keys with the values provided in the key and value.
        /// <para>The string to replace should be surrounded with double curly braces e.g. <c>{{key}}</c></para>
        /// </summary>
        /// <param name="input">The string that contains entries that need to be replaced.</param>
        /// <param name="key">The key that should be replaced.</param>
        /// <param name="value">The replacement value.</param>
        /// <returns>The replaced string.</returns>
        public static string ReplaceInline(this string input, string key, object value)
        {
            return input.Replace($"{{{{{key}}}}}", value?.ToString());
        }

        /// <summary>
        /// Performs inline replacement of case-sensitive keys with the values provided in the dictionary.
        /// <para>The string to replace should be surrounded with double curly braces e.g. <c>{{key}}</c></para>
        /// </summary>
        /// <param name="input">The string that contains entries that need to be replaced.</param>
        /// <param name="replacementPairs">A dictionary that contains pairs with the keys and the replacement value.</param>
        /// <returns>The replaced string.</returns>
        public static string ReplaceInline(this string input, Dictionary<string, string> replacementPairs)
        {
            var output = input;

            foreach (var pair in replacementPairs)
            {
                output = output.ReplaceInline(pair.Key, pair.Value);
            }

            return output;
        }

        /// <summary>
        /// Performs inline replacement of case-sensitive keys with the values provided in the dictionary.
        /// <para>The string to replace should be surrounded with double curly braces e.g. <c>{{key}}</c></para>
        /// </summary>
        /// <param name="input">The string that contains entries that need to be replaced.</param>
        /// <param name="replacementPairs">A dictionary that contains pairs with the keys and the replacement value.</param>
        /// <returns>The replaced string.</returns>
        public static string ReplaceInline(this string input, Dictionary<string, object> replacementPairs)
        {
            var output = input;

            foreach (var pair in replacementPairs)
            {
                output = output.ReplaceInline(pair.Key, pair.Value);
            }

            return output;
        }
    }
}