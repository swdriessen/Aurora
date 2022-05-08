using Aurora.Engine.Data.Interfaces;
using Aurora.Engine.Data.Models;

namespace Aurora.Data.InMemory.DataProviders
{
    internal class InMemoryMagicItemsDataProvider : IDataProvider
    {
        public List<ElementModel> GetElements()
        {
            return new List<ElementModel>(CreateAbilities());
        }

        public List<ElementModel> GetElements(string type)
        {
            return GetElements().Where(x => x.Type.Equals(type)).ToList();
        }

        private static List<ElementModel> CreateAbilities()
        {
            var elements = new List<ElementModel>();

            var types = new List<ElementModel>
            {
                new ElementModel()
                {
                    Name = "Magic Weapon, +1",
                    Properties = new()
                    {
                        { "enhancement", 1 },
                        { "enhancement.target", "Weapon" },
                        { "item.name_format", "{{parent}}" },
                    }
                },
                /*
Frost Brand 
Weapon (any sword), very rare (requires attunement) 
When you hit with an attack using this magic sword, the target takes an extra 1d6 cold damage. In addition, while you hold the sword, you have resistance to fire damage. 
In freezing temperatures, the blade sheds bright light in a 10-­‐‑foot radius and dim light for an additional 10 feet. 
When you draw this weapon, you can extinguish all nonmagical flames within 30 feet of you. This property can be used no more than once per hour.
                 */
                new ElementModel()
                {
                    Name = "Frost Brand",
                    Properties = new()
                    {
                        { "weapon", "any sword" },
                        { "weapon.target", "ID_WEAPON_GROUP_SWORD" },
                        { "attunement", true },
                        { "item.rarity", "Very Rare" },
                        { "damage", "extra 1d6 cold damage" },
                        { "damage.die.quantity", 1 },
                        { "damage.die.size", 6 },
                        { "damage.type", "Cold" },
                    }
                    //resistance to fire damage
                }
            };

            types.ForEach(e =>
            {
                e.Type = "Magic Item";
                e.Properties.Add("item.category", "Magic Items");
            });

            elements.AddRange(types);

            return elements;
        }
    }
}