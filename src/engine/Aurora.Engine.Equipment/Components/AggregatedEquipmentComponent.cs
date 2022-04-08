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
        public AggregatedEquipmentComponent([NotNull]EquipmentComponent equipmentComponent)
        {
            EquipmentComponent = equipmentComponent;
        }

        /// <summary>
        /// Gets the equipment component.
        /// </summary>
        public EquipmentComponent EquipmentComponent { get; }

        /// <summary>
        /// Decorate the equipment component with the element model.
        /// </summary>
        /// <param name="model">The element model with which you want to decorate the component.</param>
        /// <returns>The decorated that was created and added to the list of decorators.</returns>
        public EquipmentComponentDecorator Decorate(ElementModel model)
        {
            EquipmentComponentDecorator decorater = IsDecorated()
                ? new EquipmentComponentDecorator(model, equipmentComponentDecorators.Last())
                : new EquipmentComponentDecorator(model, EquipmentComponent);

            equipmentComponentDecorators.Add(decorater);

            return decorater;
        }

        public bool IsDecorated()
        {
            return equipmentComponentDecorators.Any();
        }

        public EquipmentComponentDecorator GetAggregatedComponent()
        {
            return equipmentComponentDecorators.Last();
        }

        public string GetDisplayName()
        {
            if (IsDecorated())
            {
                return GetAggregatedComponent().GetDisplayName();
            }

            return EquipmentComponent.GetDisplayName();
        }
    }
}