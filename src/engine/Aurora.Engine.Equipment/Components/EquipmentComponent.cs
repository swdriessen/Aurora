using Aurora.Engine.Data;
using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;

namespace Aurora.Engine.Equipment.Components
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EquipmentComponent"/> class.
    /// </summary>
    public class EquipmentComponent : EquipmentComponentBase
    {
        private readonly EquipmentProperties equipmentProperties;

        /// <summary>
        /// Initializes a new instance of the <see cref="EquipmentComponent"/> class.
        /// </summary>
        /// <param name="element">The element model that will be used as the base for the item.</param>
        public EquipmentComponent(ElementModel element)
        {
            Element = element;

            equipmentProperties = new EquipmentProperties(element.Properties);
        }

        /// <summary>
        /// Gets the element model assosiated with this component.
        /// </summary>
        public ElementModel Element { get; }

        public override string GetDisplayName()
        {
            return Element.Name;
        }

        public override int GetEnhancementBonus()
        {
            if (Element.Properties.TryGetValue(ElementStrings.Properties.Enhancement.Value, out object? value) && value is int enhancementValue)
            {
                return enhancementValue;
            }

            return 0;
        }
    }
}