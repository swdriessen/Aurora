namespace Aurora.Engine.Data.Models
{
    public class ExtractableItemsModel
    {
        /// <summary>
        /// Gets a list of items that can be extracted from this element.
        /// </summary>
        public List<ExtractableItem> Items { get; } = new();
    }
}
