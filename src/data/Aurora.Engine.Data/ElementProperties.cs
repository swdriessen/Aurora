namespace Aurora.Engine.Data
{
    public class ElementProperties : Dictionary<string, object>
    {
        public ElementProperties()
        {

        }

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
