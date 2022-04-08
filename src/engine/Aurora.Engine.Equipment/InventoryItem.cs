using Aurora.Engine.Equipment.Interfaces;

namespace Aurora.Engine.Equipment
{
    /// <summary>
    /// Represents the base class for an item that can be stored in the inventory.
    /// </summary>
    public abstract class InventoryItem : IDisplayNameComponent
    {
        public abstract string GetDisplayName();
    }
}