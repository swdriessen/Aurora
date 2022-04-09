using Aurora.Engine.Data;
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
            : base(element)
        {

        }

        public override string GetDisplayName()
        {
            return Element.Name;
        }

        public override int GetEnhancementBonus()
        {
            return EquipmentProperties.EnhancementProperties.EnhancementValue;
        }
    }
}