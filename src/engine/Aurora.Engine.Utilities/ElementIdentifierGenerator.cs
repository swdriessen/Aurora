namespace Aurora.Engine.Utilities
{
    public class ElementIdentifierGenerator
    {
        private readonly AbbreviationGenerator abbreviationGenerator;
        private readonly GenerationOptions options = new();

        public ElementIdentifierGenerator(Action<GenerationOptions>? configure = null)
        {
            configure?.Invoke(options);

            abbreviationGenerator = new AbbreviationGenerator(options =>
            {
                options.Exceptions.Add("Internal");
                options.Presets.Add("Player's Handbook", "PHB");
            });
        }

        /// <summary>
        /// Generates an identifier for an element. Include a source and author to allow for a more unique identifier.
        /// </summary>
        /// <param name="source">The full name of the source.</param>
        /// <param name="author">The full name of the author.</param>
        /// <param name="type">The type of the element. This cannot be empty.</param>
        /// <param name="name">The name of the element. This cannot be empty.</param>
        /// <param name="parentName">The optional name of the parent element.</param>
        /// <returns>The generated identifier.</returns>
        /// <exception cref="ArgumentException"></exception>
        public string GenerateIdentifier(string source, string author, string type, string name, string? parentName = null)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException($"'{nameof(type)}' cannot be null or whitespace.", nameof(type));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }

            var parts = new List<string>
            {
                options.IdentifierPrefix.Trim()
            };

            if (options.IncludeSourceAbbreviation)
            {
                parts.Add(abbreviationGenerator.Generate(source));
            }

            if (options.IncludeAuthorAbbreviation)
            {
                parts.Add(abbreviationGenerator.Generate(author));
            }

            parts.Add(Sanatize(type));

            if (!string.IsNullOrEmpty(parentName))
            {
                parts.Add(Sanatize(parentName));
            }

            parts.Add(Sanatize(name));

            return string.Join("_", parts).ToUpperInvariant();
        }

        private static string Sanatize(string input)
        {
            return input.Sanitize().Replace(" ", "_");
        }

        public class GenerationOptions
        {
            /// <summary>
            /// Gets or sets the prefix for the identifier to be generated. (Default is 'ID')
            /// </summary>
            public string IdentifierPrefix { get; set; } = "ID";

            /// <summary>
            /// Gets or sets a value whether or not to include the source abbreviation in the generated identifier. (Default is true)
            /// </summary>
            public bool IncludeSourceAbbreviation { get; set; } = true;

            /// <summary>
            /// Gets or sets a value whether or not to include the author abbreviation in the generated identifier. (Default is true)
            /// </summary>
            public bool IncludeAuthorAbbreviation { get; set; } = true;
        }
    }

}