using Aurora.Engine.Equipment.Components;
using Aurora.Engine.Equipment.Interfaces;

namespace Aurora.Engine.Equipment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EquipmentExtractor"/> class.
    /// </summary>
    public class EquipmentExtractor : IEquipmentExtractor
    {
        private readonly IEquipmentDataProvider equipmentDataProvider;

        public EquipmentExtractor(IEquipmentDataProvider equipmentDataProvider)
        {
            this.equipmentDataProvider = equipmentDataProvider;
        }

        public bool CanExtract(InventoryItem inventoryItem)
        {
            return inventoryItem is EquipmentItem item && item.IsExtractable;
        }

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
                    var element = equipmentDataProvider.GetElementModel(extractableItem.Item);

                    var item = new EquipmentItem(new EquipmentComponent(element));

                    items.Add(item);
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