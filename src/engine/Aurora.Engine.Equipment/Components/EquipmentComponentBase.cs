using Aurora.Engine.Equipment.Interfaces;

namespace Aurora.Engine.Equipment.Components
{
    public abstract class EquipmentComponentBase : IDisplayNameComponent, IEquipmentComponent
    {
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