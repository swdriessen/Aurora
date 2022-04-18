using Aurora.Engine.Data.Models;
using System.Text.Json;

namespace Aurora.Engine.Data.Serialization
{
    public class ElementModelSerializer : IDataSerializer<ElementModel>
    {
        private readonly JsonSerializerOptions options = new();

        public ElementModelSerializer(Action<JsonSerializerOptions>? configureOptions = null)
        {
            configureOptions?.Invoke(options);
        }

        public string Serialize(ElementModel element)
        {
            return JsonSerializer.Serialize(element, options);
        }

        public ElementModel? Deserialize(string json)
        {
            return JsonSerializer.Deserialize<ElementModel>(json, options);
        }
    }
}
