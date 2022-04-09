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

        /// <summary>
        /// Initializes a new instance of the <see cref="EquipmentItem"/> class with an <see cref="EquipmentComponent"/> .
        /// </summary>
        public EquipmentItem(EquipmentComponent equipmentComponent)
        {
            aggregatedComponent = new AggregatedEquipmentComponent(equipmentComponent);
        }

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
    }
}