using Aurora.Engine.Data.Interfaces;
using Aurora.Engine.Data.Models;

namespace Aurora.Data.InMemory
{
    public class InMemoryDataProvider : IDataProvider
    {
        private readonly List<ElementModel> elements = new();

        /// <summary>
        /// Initialize a new instance of the <see cref="InMemoryDataProvider"/> class used for testing.
        /// </summary>
        public InMemoryDataProvider()
        {
            LoadDamageTypes();
            LoadWeapons();
        }

        public List<ElementModel> GetElements()
        {
            return elements;
        }

        private void LoadDamageTypes()
        {
            var names = new List<string> { "Slashing", "Bludgeoning", "Piercing" };

            names.ForEach(name =>
            {
                elements.Add(new ElementModel() { Name = name, Type = "Damage Type" });
            });
        }
        private void LoadWeapons()
        {
            var longsword = new ElementModel()
            {
                Name = "Longsword",
                Type = "Weapon",
                Properties = new()
                {
                    { "cost", 15 },
                    { "cost.currency", "gp" },
                    { "weight", 15 },
                    { "weight.unit", "lb." },
                    { "damage", "1d8 slashing" },
                    { "damage.die.quantity", 1 },
                    { "damage.die.size", 8 },
                    { "damage.type", "Slashing" }
                }
            };

            elements.Add(longsword);
        }
    }
}