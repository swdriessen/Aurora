using System.Text.Json.Serialization;

namespace Aurora.Engine.Data.Models
{
    public class ElementSourceModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;
    }
}
