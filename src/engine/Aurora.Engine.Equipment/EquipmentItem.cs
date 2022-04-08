using Aurora.Engine.Data.Models;
using Aurora.Engine.Equipment.Components;

namespace Aurora.Engine.Equipment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EquipmentItem"/> class.
    /// </summary>
    public class EquipmentItem : InventoryItem
    {
        private readonly AggregatedEquipmentComponent aggregatedEquipmentComponent;

        /// <summary>
        /// Initializes a new instance of the <see cref="EquipmentItem"/> class with an <see cref="EquipmentComponent"/> .
        /// </summary>
        public EquipmentItem(EquipmentComponent equipmentComponent)
        {
            aggregatedEquipmentComponent = new AggregatedEquipmentComponent(equipmentComponent);
        }

        /// <summary>
        /// Decorate the item with another element model.
        /// <para>e.g. decorate a Longsword with a Weapon of Fire to create a Longsword of Fire</para>
        /// </summary>
        /// <param name="elementModel">The element model to decorate this item with.</param>
        public void Decorate(ElementModel elementModel)
        {
            aggregatedEquipmentComponent.Decorate(elementModel);
        }

        public override string GetDisplayName()
        {
            return aggregatedEquipmentComponent.GetDisplayName();
        }
    }
}