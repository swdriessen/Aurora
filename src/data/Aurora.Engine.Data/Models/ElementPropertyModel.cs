using System.Text.Json.Serialization;

namespace Aurora.Engine.Data.Models
{
    public class ElementPropertyModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }
}
