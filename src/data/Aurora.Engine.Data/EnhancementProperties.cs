using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;
using Aurora.Engine.Utilities;

namespace Aurora.Engine.Data
{
    public class EnhancementProperties
    {
        private readonly ElementPropertiesModel properties;

        public EnhancementProperties(ElementPropertiesModel properties)
        {
            this.properties = properties;
        }

        public int EnhancementValue
        {
            get { return properties.GetPropertyAs(ElementStrings.Properties.EnhancementValue, 0); }
            set { properties[ElementStrings.Properties.EnhancementValue] = value; }
        }

        public string GetFormattedEnhancement()
        {
            if (EnhancementValue == 0)
            {
                return string.Empty;
            }

            var format = "+{{enhancement.value}}";

            return format.ReplaceInline(GetReplacementDictionary()).Trim();
        }

        private Dictionary<string, object> GetReplacementDictionary()
        {
            var replacements = new Dictionary<string, object>();

            foreach (var item in properties)
            {
                replacements.Add(item.Key, item.Value);
            }

            return replacements;
        }
    }
}
