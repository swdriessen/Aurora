using Aurora.Engine.Data.Interfaces;
using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;

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
            LoadAbilitiesTypes();
            LoadSkillTypes();
            LoadCurrencyTypes();
            LoadDamageTypes();
            LoadWeaponPropertyTypes();
            LoadWeaponGroupTypes();
            LoadWeapons();
            LoadMagicItems();
            LoadSpells();
            LoadExtractableItems();

            elements.ForEach(element =>
            {
                element.Source = new ElementSourceModel() { Name = "System Reference Document" };
            });
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

        private void LoadAbilitiesTypes()
        {
            var names = new List<string> { "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma" };

            var order = 1;
            names.ForEach(name =>
            {
                elements.Add(new ElementModel()
                {
                    Name = name,
                    Type = ElementTypeConstants.Ability,
                    Properties = new()
                    {
                        { ElementConstants.Properties.SortingOrder, order },
                    }
                });

                elements.Add(new ElementModel()
                {
                    Name = $"{name} Saving Throw",
                    Type = ElementTypeConstants.SavingThrow,
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, name },
                        { ElementConstants.Properties.SortingOrder, order },
                    }
                });

                order++;
            });
        }
        private void LoadSkillTypes()
        {
            var skills = new List<ElementModel>
            {
                new ElementModel()
                {
                    Name = "Athletics",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Strength" },
                    }
                },
                new ElementModel()
                {
                    Name = "Acrobatics",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Dexterity" },
                    }
                },
                new ElementModel()
                {
                    Name = "Sleight of Hand",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Dexterity" },
                    }
                },
                new ElementModel()
                {
                    Name = "Stealth",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Dexterity" },
                    }
                },
                new ElementModel()
                {
                    Name = "Arcana",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Intelligence" },
                    }
                },
                new ElementModel()
                {
                    Name = "History",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Intelligence" },
                    }
                },
                new ElementModel()
                {
                    Name = "Investigation",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Intelligence" },
                    }
                },
                new ElementModel()
                {
                    Name = "Nature",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Intelligence" },
                    }
                },
                new ElementModel()
                {
                    Name = "Religion",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Intelligence" },
                    }
                },
                new ElementModel()
                {
                    Name = "Animal Handling",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Wisdom" },
                    }
                },
                new ElementModel()
                {
                    Name = "Insight",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Wisdom" },
                    }
                },
                new ElementModel()
                {
                    Name = "Medicine",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Wisdom" },
                    }
                },
                new ElementModel()
                {
                    Name = "Perception",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Wisdom" },
                    }
                },
                new ElementModel()
                {
                    Name = "Survival",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Wisdom" },
                    }
                },
                new ElementModel()
                {
                    Name = "Deception",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Charisma" },
                    }
                },
                new ElementModel()
                {
                    Name = "Intimidation",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Charisma" },
                    }
                },
                new ElementModel()
                {
                    Name = "Performance",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Charisma" },
                    }
                },
                new ElementModel()
                {
                    Name = "Persuasion",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Charisma" },
                    }
                }
            };

            var order = 1;
            skills.ForEach(e =>
            {
                e.Type = "Skill";
                e.Properties.Add(ElementConstants.Properties.SortingOrder, order);
                order++;
            });

            elements.AddRange(skills);
        }
        private void LoadCurrencyTypes()
        {
            var currencyTypes = new List<ElementModel>();

            var copper = new ElementModel()
            {
                Name = "Copper",
                Properties = new()
                {
                    { ElementConstants.Properties.Abbreviation, "cp" },
                    { "currency.rate", 0.01 }
                }
            };
            var silver = new ElementModel()
            {
                Name = "Silver",
                Properties = new()
                {
                    { ElementConstants.Properties.Abbreviation, "sp" },
                    { "currency.rate", 0.1 }
                }
            };
            var gold = new ElementModel()
            {
                Name = "Gold",
                Properties = new()
                {
                    { ElementConstants.Properties.Abbreviation, "gp" },
                    { "currency.rate", 1 }
                }
            };
            var platinum = new ElementModel()
            {
                Name = "Platinum",
                Properties = new()
                {
                    { ElementConstants.Properties.Abbreviation, "pp" },
                    { "currency.rate", 10 }
                }
            };
            var electrum = new ElementModel()
            {
                Name = "Electrum",
                Properties = new()
                {
                    { ElementConstants.Properties.Abbreviation, "ep" },
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
            var names = new List<string> { "Slashing", "Bludgeoning", "Piercing", "Cold" };

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
        private void LoadWeaponGroupTypes()
        {
            var names = new List<string> { "Swords", "Bows" };

            names.ForEach(name =>
            {
                elements.Add(new ElementModel() { Name = name, Type = "Weapon Group" });
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
                        { "weapon.group", "Swords" },
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
                        { "weapon.group", "Bows" },
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
        }
        private void LoadSpells()
        {
            var spells = new List<ElementModel>
            {
                new ElementModel()
                {
                    Name = "Fireball",
                    Properties = new()
                    {
                        { ElementConstants.SpellProperties.CastingTime, "1 action" },
                        { ElementConstants.SpellProperties.Range, "120 feet" },
                        { ElementConstants.SpellProperties.Duration, "Instantaneous" },
                        { ElementConstants.SpellProperties.SomaticComponent, true },
                        { ElementConstants.SpellProperties.VerbalComponent, true },
                        { ElementConstants.SpellProperties.MaterialComponent, true },
                        { ElementConstants.SpellProperties.MaterialComponentDescription, "a brimstone" },
                    }
                },
                new ElementModel()
                {
                    Name = "Iceball",
                    Properties = new()
                    {
                        { ElementConstants.SpellProperties.CastingTime, "1 action" },
                        { ElementConstants.SpellProperties.Range, "120 feet" },
                        { ElementConstants.SpellProperties.Duration, "Instantaneous" },
                        { ElementConstants.SpellProperties.SomaticComponent, true },
                        { ElementConstants.SpellProperties.VerbalComponent, true },
                        { ElementConstants.SpellProperties.MaterialComponent, true },
                        { ElementConstants.SpellProperties.MaterialComponentDescription, "a snowflake" },
                    }
                }
            };

            spells.ForEach(e =>
            {
                e.Type = "Spell";
            });

            elements.AddRange(spells);
        }
        private void LoadExtractableItems()
        {
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
        }
    }
}