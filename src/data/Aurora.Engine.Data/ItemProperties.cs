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
            get { return properties.GetPropertyAs(ElementStrings.Properties.ItemStackable, false); }
            set { properties[ElementStrings.Properties.ItemStackable] = value; }
        }

        public decimal WeightValue
        {
            get { return properties.GetPropertyAs(ElementStrings.Properties.ItemWeight, 0); }
            set { properties[ElementStrings.Properties.ItemWeight] = value; }
        }

        public string WeightUnit
        {
            get { return properties.GetPropertyAs(ElementStrings.Properties.ItemWeightUnit, string.Empty); }
            set { properties[ElementStrings.Properties.ItemWeightUnit] = value; }
        }

        public bool WeightIgnore
        {
            get { return properties.GetPropertyAs(ElementStrings.Properties.ItemWeightIgnore, false); }
            set { properties[ElementStrings.Properties.ItemWeightUnit] = value; }
        }
    }
}
