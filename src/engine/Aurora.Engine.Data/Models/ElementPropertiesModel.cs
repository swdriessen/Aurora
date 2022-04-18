namespace Aurora.Engine.Data.Models
{
    public partial class ElementPropertiesModel : Dictionary<string, object>
    {
        public ElementPropertiesModel()
        {

        }

        public bool Contains(string property)
        {
            return ContainsKey(property);
        }

        public T Get<T>(string key, T defaultValue)
        {
            return TryGetValue(key, out object? propertyValue) && propertyValue is T value ? value : defaultValue;
        }

        public void Set(string key, object value)
        {
            if (value is string valueString)
            {
                this[key] = valueString.Trim();
                return;
            }

            this[key] = value;
        }

        public new void Add(string key, object value)
        {
            Set(key, value);
        }
    }
}
