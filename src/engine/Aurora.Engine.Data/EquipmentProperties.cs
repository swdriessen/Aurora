using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;
using Aurora.Engine.Utilities;

namespace Aurora.Engine.Data
{
    public class EquipmentProperties
    {
        private readonly ElementPropertiesModel properties;

        public EquipmentProperties(ElementPropertiesModel properties)
        {
            this.properties = properties;

            ItemProperties = new ItemProperties(properties);
            EnhancementProperties = new EnhancementProperties(properties);
        }

        public ItemProperties ItemProperties { get; }

        public EnhancementProperties EnhancementProperties { get; }

        public int Cost => ItemProperties.Cost;
        public string Currency => ItemProperties.CostCurrency;

        public string GetDisplayCost()
        {
            // when a format is provided, use it instead of the default one
            if (properties.Contains(ElementConstants.Properties.ItemCostFormat))
            {
                return GetFormattedDisplayCost();
            }

            return $"{Cost} {Currency}";
        }

        private string GetFormattedDisplayCost()
        {
            var displayFormat = properties.Get(ElementConstants.Properties.ItemCostFormat, ElementConstants.Properties.ItemCostFormatDefault);

            displayFormat = displayFormat.ReplaceInline(GetReplacementDictionary());

            if (displayFormat.Contains("{{") || displayFormat.Contains("}}"))
            {
                throw new InvalidOperationException($"The {ElementConstants.Properties.ItemCostFormat} contains an unknown property that cannot be replaced.");
            }

            return displayFormat.Trim();
        }

        private Dictionary<string, object> GetReplacementDictionary()
        {
            return new Dictionary<string, object>
            {
                { ElementConstants.Properties.ItemCost, Cost },
                { ElementConstants.Properties.ItemCostCurrency, Currency }
            };
        }
    }
}
