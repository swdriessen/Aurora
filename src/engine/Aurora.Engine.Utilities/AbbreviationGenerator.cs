namespace Aurora.Engine.Utilities
{
    public class AbbreviationGenerator
    {
        private readonly Options options = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="AbbreviationGenerator"/> class for use to generate abbreviations used in element identifiers.
        /// </summary>
        /// <param name="configure"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public AbbreviationGenerator(Action<Options>? configure = null)
        {
            configure?.Invoke(options);

            if (options.MinimumLength < 2)
            {
                throw new InvalidOperationException("The minimum length of an abbreviation should be set to two.");
            }
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

            if (options.Presets.ContainsKey(input))
            {
                return options.Presets[input].ToUpperInvariant();
            }

            var parts = input.Sanitize().Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            string output;

            if (parts.Length == 1)
            {
                output = parts[0].Length < options.MinimumLength ? parts[0] : parts[0][..options.MinimumLength];
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
            /// Gets or sets the minimum length of the abbreviation to generate. (Default is 2)
            /// </summary>
            public int MinimumLength { get; set; } = 2;

            /// <summary>
            /// Gets or sets the maximum length of the abbreviation to generate. (Default is 6)
            /// </summary>
            public int MaximumLength { get; set; } = 6;

            /// <summary>
            /// Gets a list of exceptions that should not be abbreviated.
            /// </summary>
            public List<string> Exceptions { get; } = new();

            /// <summary>
            /// Gets a list of preset mappings of source to abbreviation to force certain abbreviations.
            /// </summary>
            public Dictionary<string, string> Presets { get; } = new();
        }
    }
}