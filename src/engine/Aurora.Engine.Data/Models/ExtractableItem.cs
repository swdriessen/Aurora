using Aurora.Engine.Utilities;

namespace Aurora.Engine.Data.Models
{
    public class ExtractableItem
    {
        public ExtractableItem(string item, int quantity = 1)
        {
            Item = item;
            Quantity = quantity;
        }

        /// <summary>
        /// Gets or sets the item. This can be an id or a generic name for a mundane item.
        /// <para>e.g. ID_ITEM_POTION or 'Wooden Figurine of a Raven'</para>
        /// </summary>
        public string Item { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the item. (Default is 1)
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets a list of optional properties associated with this item.
        /// </summary>
        public ElementPropertiesModel Properties { get; } = new();

        /// <summary>
        /// Gets a value indicating whether this extractable item is an existing item or not. An existing item means that this item has an associated identifier.
        /// </summary>
        /// <returns></returns>
        public bool IsExistingItem()
        {
            return Item.IsElementIdentifier();
        }
    }
}
