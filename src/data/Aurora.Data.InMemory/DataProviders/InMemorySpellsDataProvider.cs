using Aurora.Engine.Data.Interfaces;
using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;

namespace Aurora.Data.InMemory.DataProviders
{
    internal class InMemorySpellsDataProvider : IDataProvider
    {
        public List<ElementModel> GetElements()
        {
            return new List<ElementModel>(CreateSpells());
        }

        public List<ElementModel> GetElements(string type)
        {
            return GetElements().Where(x => x.Type.Equals(type)).ToList();
        }

        private static List<ElementModel> CreateSpells()
        {
            var elements = new List<ElementModel>
            {
                new ElementModel()
                {
                    Name = "Eldritch Blast",
                    Properties = new()
                    {
                        { ElementConstants.SpellProperties.MagicSchool, "Evocation" },
                        { ElementConstants.SpellProperties.Level, 0 },
                        { ElementConstants.SpellProperties.CastingTime, "1 action" },
                        { ElementConstants.SpellProperties.Range, "120 feet" },
                        { ElementConstants.SpellProperties.SomaticComponent, true },
                        { ElementConstants.SpellProperties.VerbalComponent, true },
                        { ElementConstants.SpellProperties.Duration, "Instantaneous" },
                    }
                },
                new ElementModel()
                {
                    Name = "Fireball",
                    Properties = new()
                    {
                        { ElementConstants.SpellProperties.MagicSchool, "Evocation" },
                        { ElementConstants.SpellProperties.Level, 3 },
                        { ElementConstants.SpellProperties.CastingTime, "1 action" },
                        { ElementConstants.SpellProperties.Range, "150 feet" },
                        { ElementConstants.SpellProperties.SomaticComponent, true },
                        { ElementConstants.SpellProperties.VerbalComponent, true },
                        { ElementConstants.SpellProperties.MaterialComponent, true },
                        { ElementConstants.SpellProperties.MaterialComponentDescription, "a tiny ball of bat guano and sulfur" },
                        { ElementConstants.SpellProperties.Duration, "Instantaneous" },
                    }
                }
            };

            elements.ForEach(e =>
            {
                e.Type = "Spell";
            });

            return elements;
        }
    }
}