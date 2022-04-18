namespace Aurora.Engine.Data.Models
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ElementModel"/> class.
    /// </summary>
    public class ElementModel
    {
        public string Id { get; set; } = default!;

        public string Name { get; set; } = default!;

        public string Type { get; set; } = default!;

        public ElementSourceModel Source { get; set; } = new();

        public ElementPropertiesModel Properties { get; set; } = new();
    }
}
