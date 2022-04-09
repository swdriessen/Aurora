namespace Aurora.Engine.Data.Models
{
    public class ElementPropertiesModel : Dictionary<string, object>
    {
        public bool ContainsProperty(string property)
        {
            return ContainsKey(property);
        }

        public string? GetPropertyAsString(string key, string? defaultValue = null)
        {
            if (TryGetValue(key, out object? value))
            {
                return value?.ToString();
            }

            return defaultValue;
        }

        public int GetPropertyAsInteger(string key, int defaultValue = 0)
        {
            return TryGetValue(key, out object? value) ? (int)value : defaultValue;
        }

        public bool GetPropertyAsBoolean(string key, bool defaultValue = false)
        {
            return TryGetValue(key, out object? value) ? (bool)value : defaultValue;
        }
    }
}
