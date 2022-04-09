using Aurora.Engine.Data.Models;
using Aurora.Engine.Equipment.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace Aurora.Engine.Equipment.Components
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AggregatedEquipmentComponent"/> class that helps with decorating equipment.
    /// </summary>
    public class AggregatedEquipmentComponent : IDisplayNameComponent
    {
        private readonly List<EquipmentComponentDecorator> equipmentComponentDecorators = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregatedEquipmentComponent"/> class with the base equipment component.
        /// </summary>
        /// <param name="equipmentComponent">The equipment component.</param>
        public AggregatedEquipmentComponent([NotNull] EquipmentComponent equipmentComponent)
        {
            EquipmentComponent = equipmentComponent;
        }

        /// <summary>
        /// Gets the equipment component.
        /// </summary>
        public EquipmentComponent EquipmentComponent { get; }

        /// <summary>
        /// Gets the decorated component.
        /// </summary>
        public EquipmentComponentDecorator DecoratedComponent => equipmentComponentDecorators.Last();

        /// <summary>
        /// Decorate the equipment component with the element model.
        /// </summary>
        /// <param name="model">The element model with which you want to decorate the component.</param>
        /// <returns>The decorated that was created and added to the list of decorators.</returns>
        public EquipmentComponentDecorator Decorate(ElementModel model)
        {
            var newDecorator = new EquipmentComponentDecorator(model, IsDecorated() ? DecoratedComponent : EquipmentComponent);

            equipmentComponentDecorators.Add(newDecorator);

            return newDecorator;
        }

        public bool IsDecorated()
        {
            return equipmentComponentDecorators.Any();
        }

        public bool HasEnhancementBonus()
        {
            return GetEnhancementBonus() > 0;
        }

        public string GetDisplayName()
        {
            return IsDecorated() ? DecoratedComponent.GetDisplayName() : EquipmentComponent.GetDisplayName();
        }

        public int GetEnhancementBonus()
        {
            return IsDecorated() ? DecoratedComponent.GetEnhancementBonus() : EquipmentComponent.GetEnhancementBonus();
        }
    }
}