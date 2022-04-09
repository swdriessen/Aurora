using Aurora.Engine.Data;
using Aurora.Engine.Data.Extensions;
using Aurora.Engine.Data.Models;

namespace Aurora.Engine.Equipment.Components
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EquipmentComponent"/> class.
    /// </summary>
    public class EquipmentComponent : EquipmentComponentBase
    {
        private readonly EnhancementProperties enhancementProperties;

        /// <summary>
        /// Initializes a new instance of the <see cref="EquipmentComponent"/> class.
        /// </summary>
        /// <param name="element">The element model that will be used as the base for the item.</param>
        public EquipmentComponent(ElementModel element)
        {
            Element = element;
            enhancementProperties = element.GetEnhancementProperties();
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
            return enhancementProperties.EnhancementValue;
        }
    }
}