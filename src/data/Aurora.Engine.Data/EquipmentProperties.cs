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

        public int GetEquipmentCostValue()
        {
            return properties.GetPropertyAs(ElementStrings.Properties.Item.Cost.Value, 0);
        }

        public string GetEquipmentCostCurrency()
        {
            return properties.GetPropertyAs(ElementStrings.Properties.Item.Cost.Currency, string.Empty).Trim();
        }

        public string GetDisplayCost()
        {
            // when a format is provided, use it instead of the default one
            if (properties.ContainsProperty(ElementStrings.Properties.Item.Cost.DisplayFormat))
            {
                return GetFormattedDisplayCost();
            }

            return $"{GetEquipmentCostValue()} {GetEquipmentCostCurrency()}";
        }

        private string GetFormattedDisplayCost()
        {
            var displayFormat = properties.GetPropertyAs(ElementStrings.Properties.Item.Cost.DisplayFormat, ElementStrings.Properties.Item.Cost.DisplayFormatDefault);

            displayFormat = displayFormat.ReplaceInline(GetReplacementDictionary());

            if (displayFormat.Contains("{{") || displayFormat.Contains("}}"))
            {
                throw new InvalidOperationException($"The {ElementStrings.Properties.Item.Cost.DisplayFormat} contains an unknown property that cannot be replaced.");
            }

            return displayFormat.Trim();
        }

        private Dictionary<string, object> GetReplacementDictionary()
        {
            return new Dictionary<string, object>
            {
                { ElementStrings.Properties.Item.Cost.Value, GetEquipmentCostValue() },
                { ElementStrings.Properties.Item.Cost.Currency, GetEquipmentCostCurrency() }
            };
        }
    }
}
