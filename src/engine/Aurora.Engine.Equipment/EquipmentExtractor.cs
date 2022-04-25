using Aurora.Engine.Data.Extensions;
using Aurora.Engine.Data.Models;
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

            Console.WriteLine($"extracting '{equipmentItem}'");

            var items = new List<InventoryItem>();

            foreach (var extractable in equipmentItem.GetExtractableItems())
            {
                if (extractable.IsExistingItem())
                {
                    ExtractExistingItem(items, extractable);
                }
                else
                {
                    ExtractMundaneItem(items, extractable);
                }
            }

            items.ForEach(item =>
            {
                Console.WriteLine($"extracted '{item}' (x{item.Quantity})");
            });

            return items;
        }

        private static void ExtractMundaneItem(List<InventoryItem> items, ExtractableItem extractable)
        {
            if (extractable.HasProperties() && extractable.GetItemProperties().IsStackable)
            {
                // create stackable mundane item
                items.Add(new MundaneItem(extractable.Item) { Quantity = extractable.Quantity, IsStackable = true });
            }
            else
            {
                // create non-stackable mundate item multiple times
                for (int i = 0; i < extractable.Quantity; i++)
                {
                    items.Add(new MundaneItem(extractable.Item));
                }
            }
        }

        private void ExtractExistingItem(List<InventoryItem> items, ExtractableItem extractable)
        {
            var element = equipmentDataProvider.GetElementModel(extractable.Item); // throw unable to extract exception?
            if (element.HasProperties() && element.GetItemProperties().IsStackable)
            {
                // create item once with set quantity if it is stackable
                var item = new EquipmentItem(new EquipmentComponent(element))
                {
                    Quantity = extractable.Quantity
                };

                items.Add(item);
            }
            else
            {
                for (int i = 0; i < extractable.Quantity; i++)
                {
                    items.Add(new EquipmentItem(new EquipmentComponent(element)));
                }
            }
        }
    }
}