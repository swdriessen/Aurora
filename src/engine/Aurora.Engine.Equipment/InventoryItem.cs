using Aurora.Engine.Equipment.Interfaces;

namespace Aurora.Engine.Equipment
{
    /// <summary>
    /// Represents the base class for an item that can be stored in the inventory.
    /// </summary>
    public abstract class InventoryItem : IInventoryItem
    {
        /// <summary>
        /// Gets the options for this indiviual item.
        /// </summary>
        public InventoryItemOptions Options { get; } = new();

        public bool IsStackable { get; set; }

        public int Quantity { get; set; } = 1;

        public abstract string GetDisplayName();
    }
}