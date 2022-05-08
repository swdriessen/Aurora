using Aurora.Engine.Data.Interfaces;
using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;

namespace Aurora.Data.InMemory.DataProviders
{
    internal class InMemoryExtractableItemsDataProvider : IDataProvider
    {
        public List<ElementModel> GetElements()
        {
            return new List<ElementModel>(CreateExtractableItems());
        }

        public List<ElementModel> GetElements(string type)
        {
            return GetElements().Where(x => x.Type.Equals(type)).ToList();
        }

        private static List<ElementModel> CreateExtractableItems()
        {
            var elements = new List<ElementModel>();

            var item = new ElementModel()
            {
                Name = "Extractable Pack",
                Type = "Item",
                Properties = new()
                {
                    { ElementConstants.Properties.ItemExtractable, "true" },
                }
            };

            // a scimitar, a treasure map of the isle of madness, a wooden figurine of a raven, and 2 ancient coins with 10 gp each

            item.ExtractableItems.Items.Add(new ExtractableItem("ID_WEAPON_SCIMITAR"));

            var map = new ExtractableItem("Treasure Map of the Isle of Madness");
            item.ExtractableItems.Items.Add(map);

            var figurine = new ExtractableItem("Wooden Figurine of a Raven");
            figurine.Properties.Add(ElementConstants.Properties.ItemValuable, true);
            item.ExtractableItems.Items.Add(figurine);

            var coins = new ExtractableItem("Ancient Coin", 2);
            coins.Properties.Add(ElementConstants.Properties.ItemStackable, true);
            coins.Properties.Add(ElementConstants.Properties.ItemValuable, true);
            coins.Properties.Add(ElementConstants.Properties.ItemCost, 10);
            item.ExtractableItems.Items.Add(coins);

            elements.Add(item);

            return elements;
        }
    }
}