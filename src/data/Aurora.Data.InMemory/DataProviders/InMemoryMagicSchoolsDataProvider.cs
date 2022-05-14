using Aurora.Engine.Data.Interfaces;
using Aurora.Engine.Data.Models;

namespace Aurora.Data.InMemory.DataProviders
{
    internal class InMemoryMagicSchoolsDataProvider : IDataProvider
    {
        public List<ElementModel> GetElements()
        {
            return new List<ElementModel>(CreateMagicSchools());
        }

        public List<ElementModel> GetElements(string type)
        {
            return GetElements().Where(x => x.Type.Equals(type)).ToList();
        }

        private static List<ElementModel> CreateMagicSchools()
        {
            var elements = new List<ElementModel>
            {
                new ElementModel() { Name = "Abjuration" },
                new ElementModel() { Name = "Conjuration" },
                new ElementModel() { Name = "Divination" },
                new ElementModel() { Name = "Enchantment" },
                new ElementModel() { Name = "Evocation" },
                new ElementModel() { Name = "Illusion" },
                new ElementModel() { Name = "Necromancy" },
                new ElementModel() { Name = "Transmutation" },
            };

            elements.ForEach(e =>
            {
                e.Type = "Magic School";
            });

            return elements;
        }
    }
}