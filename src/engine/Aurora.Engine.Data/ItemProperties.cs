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
            get { return properties.Get(ElementConstants.Properties.ItemStackable, false); }
            //set { properties[ElementStrings.Properties.ItemStackable] = value; }
        }

        public decimal WeightValue
        {
            get { return properties.Get(ElementConstants.Properties.ItemWeight, 0); }
            //set { properties[ElementStrings.Properties.ItemWeight] = value; }
        }

        public string WeightUnit
        {
            get { return properties.Get(ElementConstants.Properties.ItemWeightUnit, string.Empty); }
            //set { properties[ElementStrings.Properties.ItemWeightUnit] = value; }
        }

        public bool WeightIgnore
        {
            get { return properties.Get(ElementConstants.Properties.ItemWeightIgnore, false); }
            //set { properties[ElementStrings.Properties.ItemWeightUnit] = value; }
        }

        public int Cost
        {
            get { return properties.Get(ElementConstants.Properties.ItemCost, 0); }
            //set { properties.Set(ElementStrings.Properties.ItemCost, value); }
        }

        public string CostCurrency
        {
            get { return properties.Get(ElementConstants.Properties.ItemCostCurrency, ElementConstants.Properties.ItemCostCurrencyDefault); }
            //set { properties.Set(ElementStrings.Properties.ItemCostCurrency, value); }
        }

        public string Rarity
        {
            get { return properties.Get(ElementConstants.Properties.ItemRarity, ""); }
            //set { properties.Set(ElementStrings.Properties.ItemRarity, value); }
        }

        public bool Extractable
        {
            get { return properties.Get(ElementConstants.Properties.ItemExtractable, false); }
        }

        public bool Consumable
        {
            get { return properties.Get(ElementConstants.Properties.ItemConsumable, false); }
        }
    }
}
