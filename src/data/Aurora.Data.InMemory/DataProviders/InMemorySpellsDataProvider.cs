using System.Text;
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
            var builder = new DescriptionBuilder();
            builder.Paragraph("A beam of crackling energy streaks toward a creature within range. Make a ranged spell attack against the target. On a hit, the target takes 1d10 force damage.");
            builder.IndentedParagraph("The spell creates more than one beam when you reach higher levels: two beams at 5th level, three beams at 11th level, and four beams at 17th level. you can direct the beams at the same target or at different ones. Make a separate attack roll for each beam.");
            var result = builder.Build();



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

    public class DescriptionBuilder
    {
        readonly StringBuilder builder = new StringBuilder();

        public DescriptionBuilder()
        {

        }

        public DescriptionBuilder Paragraph(string input)
        {
            //A beam of crackling energy streaks toward a creature within range. Make a ranged spell attack against the target. On a hit, the target takes 1d10 force damage.
            //The spell creates more than one beam when you reach higher levels: two beams at 5th level, three beams at 11th level, and four beams at 17th level. you can direct the beams at the same target or at different ones. Make a separate attack roll for each beam.

            builder.Append($"<p>{input}</p>");
            return this;
        }
        public DescriptionBuilder IndentedParagraph(string input)
        {
            //A beam of crackling energy streaks toward a creature within range. Make a ranged spell attack against the target. On a hit, the target takes 1d10 force damage.
            //The spell creates more than one beam when you reach higher levels: two beams at 5th level, three beams at 11th level, and four beams at 17th level. you can direct the beams at the same target or at different ones. Make a separate attack roll for each beam.

            builder.Append($"<p class=\"indent\">{input}</p>");
            return this;
        }

        public string Build()
        {
            return builder.ToString();
        }

        public override string ToString()
        {
            return builder.ToString();
        }
    }
}