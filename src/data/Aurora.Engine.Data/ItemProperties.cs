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
            get { return properties.GetPropertyAs(ElementStrings.Properties.Item.Stackable, false); }
            set { properties[ElementStrings.Properties.Item.Stackable] = value; }
        }

        public decimal WeightValue
        {
            get { return properties.GetPropertyAs(ElementStrings.Properties.Item.Weight.Value, 0); }
            set { properties[ElementStrings.Properties.Item.Weight.Value] = value; }
        }

        public string WeightUnit
        {
            get { return properties.GetPropertyAs(ElementStrings.Properties.Item.Weight.Unit, string.Empty); }
            set { properties[ElementStrings.Properties.Item.Weight.Unit] = value; }
        }

        public bool WeightIgnore
        {
            get { return properties.GetPropertyAs(ElementStrings.Properties.Item.Weight.Ignore, false); }
            set { properties[ElementStrings.Properties.Item.Weight.Unit] = value; }
        }
    }
}
