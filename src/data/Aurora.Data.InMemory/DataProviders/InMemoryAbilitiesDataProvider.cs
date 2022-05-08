using Aurora.Engine.Data.Interfaces;
using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;

namespace Aurora.Data.InMemory.DataProviders
{
    internal class InMemoryAbilitiesDataProvider : IDataProvider
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

            return elements;
        }
    }
}