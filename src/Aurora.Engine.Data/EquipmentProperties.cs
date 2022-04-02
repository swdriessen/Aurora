using Aurora.Engine.Data.Constants;

namespace Aurora.Engine.Data
{
    public abstract class PropertiesBase
    {
        public PropertiesBase(ElementProperties properties)
        {
            Properties = properties;
        }

        protected ElementProperties Properties { get; }
    }

    public class EquipmentProperties
    {
        private readonly ElementProperties properties;

        public EquipmentProperties(ElementProperties properties)
        {
            this.properties = properties;
        }

        public int GetEquipmentCostValue()
        {
            return properties.GetPropertyAsInteger(PropertyNames.Equipment.Cost.Value);
        }

        public string GetEquipmentCostCurrency()
        {
            return properties.GetPropertyAsString(PropertyNames.Equipment.Cost.Currency)?.Trim() ?? string.Empty;
        }

        public string GetDisplayCost()
        {
            // when a format is provided, use it instead of the default one
            if (properties.ContainsProperty(PropertyNames.Equipment.Cost.DisplayFormat))
            {
                return GetFormattedDisplayCost();
            }

            return $"{GetEquipmentCostValue()} {GetEquipmentCostCurrency()}";
        }

        private string GetFormattedDisplayCost()
        {
            var displayFormat = properties.GetPropertyAsString(PropertyNames.Equipment.Cost.DisplayFormat) ?? PropertyNames.Equipment.Cost.DisplayFormatDefault;

            // extract to replace utilities to auto replace properties with the string variant of that key
            displayFormat = displayFormat.Replace($"{{{{{PropertyNames.Equipment.Cost.Value}}}}}", GetEquipmentCostValue().ToString());
            displayFormat = displayFormat.Replace($"{{{{{PropertyNames.Equipment.Cost.Currency}}}}}", GetEquipmentCostCurrency());

            if (displayFormat.Contains("{{") || displayFormat.Contains("}}"))
            {
                throw new InvalidOperationException($"The {PropertyNames.Equipment.Cost.DisplayFormat} contains an unknown property that cannot be replaced.");
            }

            return displayFormat.Trim();
        }
    }
}
