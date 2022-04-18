
using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;

namespace Aurora.Engine.Data.Extensions
{
    public static class ElementPropertiesExtensions
    {
        /// <summary>
        /// A shorthand to add the item nameformatting property to the list of properties of the element model.
        /// </summary>
        /// <param name="value">The value of the property.</param>
        public static void AddItemNameFormattingProperty(this ElementPropertiesModel properties, string value)
        {
            properties.Add(ElementStrings.Properties.ItemNameFormat, value);
        }
    }
}
