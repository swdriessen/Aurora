using System.Diagnostics.CodeAnalysis;
using Aurora.Engine.Data;
using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;
using Aurora.Engine.Utilities;

namespace Aurora.Engine.Equipment.Components
{
    /// <summary>
    /// Initalizes a new instance of the <see cref="EquipmentComponentDecorator"/> class.
    /// </summary>
    public class EquipmentComponentDecorator : EquipmentComponentBase
    {
        private EquipmentComponentBase parentComponent;

        /// <summary>
        /// Initalizes a new instance of the <see cref="EquipmentComponentDecorator"/> class in order to decorate a component.
        /// </summary>
        /// <param name="element">The decorating element model.</param>
        /// <param name="parentComponent">The component that you are decorating.</param>
        public EquipmentComponentDecorator(ElementModel element, EquipmentComponentBase parentComponent)
            : base(element)
        {
            this.parentComponent = parentComponent;
        }

        /// <summary>
        /// Sets the component that you are decorating.
        /// </summary>
        /// <param name="parentComponent"></param>
        public void SetParentComponent([NotNull] EquipmentComponentBase parentComponent)
        {
            this.parentComponent = parentComponent;
        }

        public override string GetDisplayName()
        {
            if (Element.Properties.ContainsProperty(ElementStrings.Properties.ItemNameFormat))
            {
                return Element.Properties.GetPropertyAs(ElementStrings.Properties.ItemNameFormat, Element.Name)
                    .ReplaceInline(ReplacementStrings.Parent, parentComponent.GetDisplayName());
            }

            // when there is no formatted name provided, use the name of the decorator e.g. "Flametongue"
            return Element.Name;
        }

        public override int GetEnhancementBonus()
        {
            var bonus = parentComponent.GetEnhancementBonus();

            bonus += EquipmentProperties.EnhancementProperties.EnhancementValue;

            return bonus;
        }
    }
}