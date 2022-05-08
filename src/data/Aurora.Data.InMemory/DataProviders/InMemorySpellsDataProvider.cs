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
            var elements = new List<ElementModel>();

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

            return elements;
        }
    }
}