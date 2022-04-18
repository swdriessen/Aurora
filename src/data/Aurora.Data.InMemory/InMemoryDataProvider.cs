using Aurora.Engine.Data.Interfaces;
using Aurora.Engine.Data.Models;

namespace Aurora.Data.InMemory
{
    public class InMemoryDataProvider : IDataProvider
    {
        private readonly List<ElementModel> elements = new();
        private readonly Dictionary<string, List<ElementModel>> typedElements = new();

        /// <summary>
        /// Initialize a new instance of the <see cref="InMemoryDataProvider"/> class used for testing.
        /// </summary>
        public InMemoryDataProvider()
        {
            LoadCurrencyTypes();
            LoadDamageTypes();
            LoadWeaponPropertyTypes();
            LoadWeapons();
            LoadMagicItems();

            elements.ForEach(element => element.Source = new ElementSourceModel() { Name = "System Reference Document" });
        }

        public List<ElementModel> GetElements()
        {
            return elements;
        }

        public List<ElementModel> GetElements(string type)
        {
            if (!typedElements.ContainsKey(type))
            {
                typedElements[type] = new List<ElementModel>(elements.Where(element => element.Type.Equals(type)));
            }

            return typedElements[type];
        }

        private void LoadCurrencyTypes()
        {
            var currencyTypes = new List<ElementModel>();

            var copper = new ElementModel()
            {
                Name = "Copper",
                Properties = new()
                {
                    { "abbreviation", "cp" },
                    { "currency.rate", 0.01 }
                }
            };
            var silver = new ElementModel()
            {
                Name = "Silver",
                Properties = new()
                {
                    { "abbreviation", "sp" },
                    { "currency.rate", 0.1 }
                }
            };
            var gold = new ElementModel()
            {
                Name = "Gold",
                Properties = new()
                {
                    { "abbreviation", "gp" },
                    { "currency.rate", 1 }
                }
            };
            var platinum = new ElementModel()
            {
                Name = "Platinum",
                Properties = new()
                {
                    { "abbreviation", "pp" },
                    { "currency.rate", 10 }
                }
            };
            var electrum = new ElementModel()
            {
                Name = "Electrum",
                Properties = new()
                {
                    { "abbreviation", "ep" },
                    { "currency.rate", 0.5 }
                }
            };

            currencyTypes.Add(copper);

            currencyTypes.ForEach(e =>
            {
                e.Type = "Currency";
                e.Properties.Add("weight", 0.02);
                e.Properties.Add("weight.unit", "lb.");
            });

            elements.AddRange(currencyTypes);
        }

        private void LoadDamageTypes()
        {
            var names = new List<string> { "Slashing", "Bludgeoning", "Piercing" };

            names.ForEach(name =>
            {
                elements.Add(new ElementModel() { Name = name, Type = "Damage Type" });
            });
        }
        private void LoadWeaponPropertyTypes()
        {
            var names = new List<string> { "Versatile", "Ammunition", "Heavy", "Two-Handed" };

            names.ForEach(name =>
            {
                elements.Add(new ElementModel() { Name = name, Type = "Weapon Property" });
            });
        }

        private void LoadWeapons()
        {
            var weaponTypes = new List<ElementModel>
            {
                new ElementModel()
                {
                    Name = "Longsword",
                    Properties = new()
                    {
                        { "cost", 15 },
                        { "weight", 3 },
                        //{ "damage", "1d8 slashing" },
                        { "damage.die.quantity", 1 },
                        { "damage.die.size", 8 },
                        { "damage.type", "Slashing" },
                        { "weapon.proficiency", "Longsword" },
                        { "weapon.properties", "Versatile" },
                    }
                },
                new ElementModel()
                {
                    Name = "Longbow",
                    Properties = new()
                    {
                        { "cost", 50 },
                        { "weight", 2 },
                        //{ "damage", "1d8 piercing" },
                        { "damage.die.quantity", 1 },
                        { "damage.die.size", 8 },
                        { "damage.type", "Piercing" },
                        { "weapon.proficiency", "Longbow" },
                        { "weapon.properties", "Ammunition;Heavy;Two-Handed" },
                        { "weapon.range", "150/600" },
                    }
                }
            };

            weaponTypes.ForEach(e =>
            {
                e.Type = "Weapon";
                e.Properties.Add("item.category", "Weapons");
                e.Properties.Add("item.equippable", true);
                e.Properties.Add("cost.currency", "gp");
                e.Properties.Add("weight.unit", "lb.");
            });

            elements.AddRange(weaponTypes);
        }

        private void LoadMagicItems()
        {
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
                new ElementModel()
                {
                    Name = "Frost Brand",
                    Properties = new()
                    {
                        { "enhancement.target", "Weapon" },
                    }
                }
            };

            types.ForEach(e =>
            {
                e.Type = "Magic Item";
                e.Properties.Add("item.category", "Magic Items");
            });

            elements.AddRange(types);
        }
    }
}