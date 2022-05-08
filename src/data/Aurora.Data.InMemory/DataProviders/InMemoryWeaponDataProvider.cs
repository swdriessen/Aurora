using Aurora.Engine.Data.Interfaces;
using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;

namespace Aurora.Data.InMemory.DataProviders
{
    internal class InMemoryWeaponDataProvider : IDataProvider
    {
        public List<ElementModel> GetElements()
        {
            var elements = new List<ElementModel>
            {
                CreateLongsword(),
                CreateLongbow()
            };

            elements.ForEach(element =>
            {
                element.Type = ElementTypeConstants.Weapon;
                element.Properties.Add(ElementConstants.Properties.ItemCategory, "Weapons");
                element.Properties.Add(ElementConstants.Properties.Equippable, true);
                element.Properties.Add(ElementConstants.Properties.ItemCostCurrency, "gp");
                element.Properties.Add(ElementConstants.Properties.ItemWeightUnit, "lb.");
            });

            elements.AddRange(CreateWeaponPropertyTypes());
            elements.AddRange(CreateWeaponGroupTypes());

            return elements;
        }

        public List<ElementModel> GetElements(string type)
        {
            return GetElements().Where(x => x.Type.Equals(type)).ToList();
        }

        private static ElementModel CreateLongsword()
        {
            return new ElementModel()
            {
                Name = "Longsword",
                Properties = new()
                {
                    { "cost", 15 },
                    { "weight", 3 },
                    { "damage.die.quantity", 1 },
                    { "damage.die.size", 8 },
                    { "damage.type", "Slashing" },
                    { "weapon.proficiency", "Longsword" },
                    { "weapon.properties", "Versatile" },
                    { "weapon.group", "Swords" },
                }
            };
        }

        private static ElementModel CreateLongbow()
        {
            return new ElementModel()
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
            };
        }

        private static List<ElementModel> CreateWeaponPropertyTypes()
        {
            var elements = new List<ElementModel>();

            var names = new List<string> { "Versatile", "Ammunition", "Heavy", "Two-Handed" };

            names.ForEach(name =>
            {
                elements.Add(new ElementModel() { Name = name, Type = ElementTypeConstants.WeaponProperty });
            });

            return elements;
        }

        private static List<ElementModel> CreateWeaponGroupTypes()
        {
            var elements = new List<ElementModel>();

            var names = new List<string> { "Swords", "Bows" };

            names.ForEach(name =>
            {
                elements.Add(new ElementModel() { Name = name, Type = ElementTypeConstants.WeaponGroup });
            });

            return elements;
        }
    }
}