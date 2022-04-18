namespace Aurora.Engine.Utilities
{
    public class AbbreviationGenerator
    {
        private readonly Options options = new();

        public AbbreviationGenerator(Action<Options>? configure = null)
        {
            configure?.Invoke(options);
        }

        /// <summary>
        /// Generates an abbreviation from an input string.
        /// <para>e.g. turn "Dungeon Master's Guide into DMG"</para>
        /// </summary>
        /// <param name="input">The input to abbreviate.</param>
        /// <returns>The abbreviation.</returns>
        public string Generate(string input)
        {
            if (options.Exceptions.Contains(input))
            {
                return input.Sanitize().ToUpperInvariant();
            }

            var parts = input.Sanitize().Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            string output;

            if (parts.Length == 1)
            {
                output = parts[0][..options.MinimumLength];
            }
            else
            {
                var characters = new List<char>();

                foreach (var part in parts)
                {
                    characters.Add(part[0]);
                }

                output = string.Join("", characters);
            }

            return (output.Length > options.MaximumLength ? output[..options.MaximumLength] : output).ToUpperInvariant();
        }

        public class Options
        {
            /// <summary>
            /// Gets or sets the minimum length of the abbreviation to generate.
            /// </summary>
            public int MinimumLength { get; set; } = 2;

            /// <summary>
            /// Gets or sets the maximum length of the abbreviation to generate.
            /// </summary>
            public int MaximumLength { get; set; } = 6;

            /// <summary>
            /// Gets a list of exceptions that should not be abbreviated.
            /// </summary>
            public List<string> Exceptions { get; } = new();
        }
    }
}