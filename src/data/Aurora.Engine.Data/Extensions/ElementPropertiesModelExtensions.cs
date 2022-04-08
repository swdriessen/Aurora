
using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;

namespace Aurora.Engine.Data.Extensions
{
    public static class ElementPropertiesModelExtensions
    {
        /// <summary>
        /// A shorthand to add a property to the list of properties of the element model.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The value of the property.</param>
        public static void AddProperty(this ElementPropertiesModel properties, string name, object value)
        {
            properties.Add(name, value);
        }

        /// <summary>
        /// A shorthand to add the item nameformatting property to the list of properties of the element model.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The value of the property.</param>
        public static void AddItemNameFormattingProperty(this ElementPropertiesModel properties, string value)
        {
            properties.Add(ElementStrings.Properties.Item.NameFormatting, value);
        }
    }
}
