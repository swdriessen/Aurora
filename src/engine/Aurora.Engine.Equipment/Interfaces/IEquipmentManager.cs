using Aurora.Engine.Data.Models;

namespace Aurora.Engine.Equipment.Interfaces
{
    public interface IEquipmentManager
    {
        /// <summary>
        /// Gets the items that are stored in the inventory.
        /// </summary>
        InventoryItemCollection Items { get; }

        /// <summary>
        /// Add the element model to the inventory as an equipment item.
        /// </summary>
        /// <param name="element">The element to add.</param>
        /// <returns>The added equipment item.</returns>
        EquipmentItem Add(ElementModel element);

        /// <summary>
        /// Extracts an extractable equipment item into the inventory.
        /// </summary>
        /// <param name="item">The item to extract.</param>
        /// <returns>True if the item was extracted successfully. Returns False when the item was not found in the inventory or the item was not extractable.</returns>
        bool Extract(EquipmentItem item);
    }
}