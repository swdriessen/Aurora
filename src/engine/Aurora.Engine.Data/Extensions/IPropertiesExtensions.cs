using Aurora.Engine.Data.Interfaces;

namespace Aurora.Engine.Data.Extensions
{
    public static class IPropertiesExtensions
    {
        /// <summary>
        /// Gets a value indicating whether there are any properties.
        /// </summary>
        /// <returns>True if item has at least one property.</returns>
        public static bool HasProperties(this IProperties item)
        {
            return item.Properties.Any();
        }

        /// <summary>
        /// Gets a new instance of the <see cref="ItemProperties"/> class, populated with the properties of the parent.
        /// </summary>
        public static ItemProperties GetItemProperties(this IProperties item)
        {
            return new ItemProperties(item.Properties);
        }
    }
}
