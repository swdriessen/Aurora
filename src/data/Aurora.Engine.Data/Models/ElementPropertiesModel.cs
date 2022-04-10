namespace Aurora.Engine.Data.Models
{
    public class ElementPropertiesModel : Dictionary<string, object>
    {
        public bool ContainsProperty(string property)
        {
            return ContainsKey(property);
        }

        public T GetPropertyAs<T>(string key, T defaultValue)
        {
            return TryGetValue(key, out object? propertyValue) && propertyValue is T value ? value : defaultValue;
        }
    }
}
