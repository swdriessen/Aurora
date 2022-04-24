using Aurora.Engine.Data;
using Aurora.Engine.Data.Models;
using Aurora.Engine.Equipment.Components;

namespace Aurora.Engine.Equipment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EquipmentItem"/> class.
    /// </summary>
    public class EquipmentItem : InventoryItem
    {
        private readonly AggregatedEquipmentComponent aggregatedComponent;
        private readonly EquipmentProperties equipmentProperties;

        /// <summary>
        /// Initializes a new instance of the <see cref="EquipmentItem"/> class with an <see cref="EquipmentComponent"/> .
        /// </summary>
        public EquipmentItem(EquipmentComponent equipmentComponent)
        {
            aggregatedComponent = new AggregatedEquipmentComponent(equipmentComponent);
            equipmentProperties = new EquipmentProperties(equipmentComponent.Element.Properties);

            IsStackable = equipmentProperties.ItemProperties.IsStackable;
            IsExtractable = equipmentProperties.ItemProperties.Extractable;
        }

        /// <summary>
        /// Gets a value indicating wether this item contains other items that can be extracted from it.
        /// <para>e.g. an explorer's pack</para>
        /// </summary>
        public bool IsExtractable { get; }

        /// <summary>
        /// Gets or sets a value indicating wether to include the enhancement bonus in the display name of the item or not. (Default = true)
        /// </summary>
        public bool IncludeEnhancementBonus { get; set; } = true;

        /// <summary>
        /// Decorate the item with another element model.
        /// <para>e.g. decorate a Longsword with a Weapon of Fire to create a Longsword of Fire</para>
        /// </summary>
        /// <param name="elementModel">The element model to decorate this item with.</param>
        public void Decorate(ElementModel elementModel)
        {
            aggregatedComponent.Decorate(elementModel);
        }

        public override string GetDisplayName()
        {
            if (IncludeEnhancementBonus && aggregatedComponent.HasEnhancementBonus())
            {
                return $"{aggregatedComponent.GetDisplayName()}, +{aggregatedComponent.GetEnhancementBonus()}";
            }

            return aggregatedComponent.GetDisplayName();
        }

        /// <summary>
        /// Gets the extractable items from the original element model that was used to create this item.
        /// </summary>
        /// <returns>A list of extractable items.</returns>
        public IEnumerable<ExtractableItem> GetExtractableItems()
        {
            return aggregatedComponent.EquipmentComponent.Element.ExtractableItems.Items;
        }
    }
}