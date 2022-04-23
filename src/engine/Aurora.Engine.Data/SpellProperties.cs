using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;

namespace Aurora.Engine.Data
{
    public class SpellProperties
    {
        private readonly ElementPropertiesModel properties;

        public SpellProperties(ElementPropertiesModel properties)
        {
            this.properties = properties;
        }

        public int Level
        {
            get { return properties.Get(ElementConstants.SpellProperties.Level, -1); }
        }

        public string MagicSchool
        {
            get { return properties.Get(ElementConstants.SpellProperties.MagicSchool, string.Empty); }
        }

        public string CastingTime
        {
            get { return properties.Get(ElementConstants.SpellProperties.CastingTime, string.Empty); }
        }

        public string Duration
        {
            get { return properties.Get(ElementConstants.SpellProperties.Duration, string.Empty); }
        }

        public string Range
        {
            get { return properties.Get(ElementConstants.SpellProperties.Range, string.Empty); }
        }

        public bool VerbalComponent
        {
            get { return properties.Get(ElementConstants.SpellProperties.VerbalComponent, false); }
        }

        public bool SomaticComponent
        {
            get { return properties.Get(ElementConstants.SpellProperties.SomaticComponent, false); }
        }

        public bool MaterialComponent
        {
            get { return properties.Get(ElementConstants.SpellProperties.MaterialComponent, false); }
        }

        public string MaterialComponentDescription
        {
            get { return properties.Get(ElementConstants.SpellProperties.MaterialComponentDescription, string.Empty); }
        }

        public bool Concentration
        {
            get { return properties.Get(ElementConstants.SpellProperties.Concentration, false); }
        }

        public bool Ritual
        {
            get { return properties.Get(ElementConstants.SpellProperties.Ritual, false); }
        }

        private string Spellcasters
        {
            get { return properties.Get(ElementConstants.SpellProperties.Spellcasters, string.Empty); }
        }

        ///// <summary>
        ///// Gets a list of spellcasters.
        ///// </summary>
        public IEnumerable<string> GetSpellcasters()
        {
            return SplitDistinct(Spellcasters);
        }

        private static IEnumerable<string> SplitDistinct(string input)
        {
            return input
                .Split(ElementConstants.Properties.PropertiesSeparator, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Distinct();
        }
    }
}
