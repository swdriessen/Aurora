using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;
using Aurora.Engine.Utilities;
using System.Diagnostics.CodeAnalysis;

namespace Aurora.Engine.Equipment.Components
{
    /// <summary>
    /// Initalizes a new instance of the <see cref="EquipmentComponentDecorator"/> class.
    /// </summary>
    public class EquipmentComponentDecorator : EquipmentComponentBase
    {
        private readonly ElementModel element;
        private EquipmentComponentBase parentComponent;

        /// <summary>
        /// Initalizes a new instance of the <see cref="EquipmentComponentDecorator"/> class in order to decorate a component.
        /// </summary>
        /// <param name="element">The decorating element model.</param>
        /// <param name="parentComponent">The component that you are decorating.</param>
        public EquipmentComponentDecorator(ElementModel element, EquipmentComponentBase parentComponent)
        {
            this.element = element;
            this.parentComponent = parentComponent;
        }

        /// <summary>
        /// Sets the component that you are decorating.
        /// </summary>
        /// <param name="parentComponent"></param>
        public void SetParentComponent([NotNull]EquipmentComponentBase parentComponent)
        {
            this.parentComponent = parentComponent;
        }

        public override string GetDisplayName()
        {
            if(element.Properties.TryGetValue(ElementStrings.Properties.Item.NameFormatting, out object? value) && value is string nameFormat)
            {
                return nameFormat.ReplaceInline(ReplacementStrings.Parent, parentComponent.GetDisplayName());
            }

            // when there is no formatted name provided, use the name of the decorator e.g. "Flametongue"
            return element.Name;
        }
    }
}