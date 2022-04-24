namespace Aurora.Engine.Equipment.Interfaces
{
    public interface IEquipmentExtractor
    {
        /// <summary>
        /// Gets a value indicating whether an item can be extracted.
        /// </summary>
        /// <param name="inventoryItem">The item to extract.</param>
        /// <returns>True when it can be extracted.</returns>
        bool CanExtract(InventoryItem inventoryItem);

        /// <summary>
        /// Extracts items from an existing equipment item.
        /// </summary>
        /// <param name="equipmentItem">The item from which to extract items.</param>
        /// <returns>A list of items that can be extracted from this item.</returns>
        /// <exception cref="InvalidOperationException">Throws when this item is not extractable.</exception>
        IEnumerable<InventoryItem> Extract(EquipmentItem equipmentItem);
    }
}