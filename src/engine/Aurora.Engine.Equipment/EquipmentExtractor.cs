namespace Aurora.Engine.Equipment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EquipmentExtractor"/> class.
    /// </summary>
    public class EquipmentExtractor
    {
        /// <summary>
        /// Extracts items from an existing equipment item.
        /// </summary>
        /// <param name="equipmentItem">The item from which to extract items.</param>
        /// <returns>A list of items that can be extracted from this item.</returns>
        /// <exception cref="InvalidOperationException">Throws when this item is not extractable.</exception>
        public IEnumerable<InventoryItem> Extract(EquipmentItem equipmentItem)
        {
            if (!equipmentItem.IsExtractable)
            {
                throw new InvalidOperationException($"The equipment item '{equipmentItem}' is not extractable.");
            }

            var items = new List<InventoryItem>();

            foreach (var extractableItem in equipmentItem.GetExtractableItems())
            {
                if (extractableItem.IsExistingItem())
                {
                    // TODO: create equipment item
                    throw new NotImplementedException();
                }
                else
                {
                    // create mundate item
                    items.Add(new MundaneItem(extractableItem.Item));
                }
            }

            return items;
        }
    }
}