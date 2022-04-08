using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aurora.Engine.Data.Models
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ElementModel"/> class.
    /// </summary>
    public class ElementModel
    {
        [JsonPropertyOrder(2)]
        [JsonPropertyName("id")]
        public string ID { get; set; } = default!;

        [JsonPropertyOrder(0)]
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyOrder(1)]
        [JsonPropertyName("type")]
        public string Type { get; set; } = default!;

        [JsonPropertyOrder(3)]
        [JsonPropertyName("source")]
        public ElementSourceModel Source { get; set; } = new();

        [JsonPropertyOrder(10)]
        [JsonPropertyName("properties")]
        public ElementPropertiesModel Properties { get; set; } = new();
    }
}
