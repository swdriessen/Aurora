using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;

namespace Aurora.Engine.Data
{
    public class ItemProperties
    {
        private readonly ElementPropertiesModel properties;

        public ItemProperties(ElementPropertiesModel properties)
        {
            this.properties = properties;
        }

        public bool IsStackable
        {
            get { return properties.GetPropertyAsBoolean(ElementStrings.Properties.Item.Stackable); }
            set { properties[ElementStrings.Properties.Item.Stackable] = value; }
        }
    }
}
