using Aurora.Engine.Data.Models;
using Aurora.Engine.Equipment.Components;
using Aurora.Engine.Equipment.Interfaces;

namespace Aurora.Engine.Equipment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EquipmentManager"/> class.
    /// </summary>
    public class EquipmentManager : IEquipmentManager
    {
        private readonly IEquipmentExtractor equipmentExtractor;

        public EquipmentManager(IEquipmentExtractor equipmentExtractor)
        {
            this.equipmentExtractor = equipmentExtractor;
        }

        public InventoryItemCollection Items { get; } = new();

        public EquipmentItem Add(ElementModel element)
        {
            var item = new EquipmentItem(new EquipmentComponent(element));

            Items.Add(item);

            return item;
        }

        public bool Extract(EquipmentItem item)
        {
            if (Items.Contains(item) && equipmentExtractor.CanExtract(item))
            {
                var currentIndex = Items.IndexOf(item);
                var extractedItems = equipmentExtractor.Extract(item);

                if (Items.Remove(item))
                {
                    Items.InsertRange(currentIndex, extractedItems);
                    return true;
                }
            }

            return false;
        }
    }
}