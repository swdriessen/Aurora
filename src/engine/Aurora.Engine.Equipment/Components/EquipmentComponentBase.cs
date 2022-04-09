using Aurora.Engine.Data;
using Aurora.Engine.Data.Models;
using Aurora.Engine.Equipment.Interfaces;

namespace Aurora.Engine.Equipment.Components
{
    public abstract class EquipmentComponentBase : IEquipmentComponent
    {
        public EquipmentComponentBase(ElementModel element)
        {
            Element = element;
            EquipmentProperties = new EquipmentProperties(element.Properties);
        }

        /// <summary>
        /// Gets the element model assosiated with this component.
        /// </summary>
        public ElementModel Element { get; }

        /// <summary>
        /// Gets the element properties assosiated with this component's element.
        /// </summary>
        protected EquipmentProperties EquipmentProperties { get; set; }

        /// <summary>
        /// Gets the display name for this component.
        /// </summary>
        public abstract string GetDisplayName();

        /// <summary>
        /// Gets the enhancement bonus name for this component.
        /// </summary>
        public abstract int GetEnhancementBonus();
    }
}