using Aurora.Engine.Data.Models;

namespace Aurora.Engine.Equipment.Components
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EquipmentComponent"/> class.
    /// </summary>
    public class EquipmentComponent : EquipmentComponentBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EquipmentComponent"/> class.
        /// </summary>
        /// <param name="element">The element model that will be used as the base for the item.</param>
        public EquipmentComponent(ElementModel element)
        {
            Element = element;
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
            if (Element.Properties.TryGetValue("enhancement.value", out object? value) && value is int enhancementValue)
            {
                return enhancementValue;
            }

            return 0;
        }
    }
}