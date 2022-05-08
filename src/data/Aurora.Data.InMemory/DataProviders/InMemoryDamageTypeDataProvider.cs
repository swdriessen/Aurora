using Aurora.Engine.Data.Interfaces;
using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;

namespace Aurora.Data.InMemory.DataProviders
{
    internal class InMemoryDamageTypeDataProvider : IDataProvider
    {
        public List<ElementModel> GetElements()
        {
            var elements = new List<ElementModel>();

            elements.AddRange(CreateDamageTypes());

            return elements;
        }

        public List<ElementModel> GetElements(string type)
        {
            return GetElements().Where(x => x.Type.Equals(type)).ToList();
        }

        private static List<ElementModel> CreateDamageTypes()
        {
            var elements = new List<ElementModel>();

            var names = new List<string> { "Slashing", "Bludgeoning", "Piercing", "Cold" };

            names.ForEach(name =>
            {
                elements.Add(new ElementModel() { Name = name, Type = ElementTypeConstants.DamageType });
            });

            return elements;
        }
    }
}