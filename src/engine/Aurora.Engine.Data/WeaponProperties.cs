using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;

namespace Aurora.Engine.Data
{
    public class WeaponProperties
    {
        private readonly ElementPropertiesModel properties;

        public WeaponProperties(ElementPropertiesModel properties)
        {
            this.properties = properties;
        }

        public string Proficiency
        {
            get { return properties.Get(ElementConstants.Properties.WeaponProficiency, string.Empty); }
        }

        private string Properties
        {
            get { return properties.Get(ElementConstants.Properties.WeaponProperties, string.Empty); }
        }

        private string SpecialProperties
        {
            get { return properties.Get(ElementConstants.Properties.WeaponPropertiesSpecial, string.Empty); }
        }

        private string Group
        {
            get { return properties.Get(ElementConstants.Properties.WeaponGroup, string.Empty); }
        }

        public string Range
        {
            get { return properties.Get(ElementConstants.Properties.WeaponRange, string.Empty); }
        }

        /// <summary>
        /// Gets a list of proficiencies.
        /// </summary>
        public IEnumerable<string> GetWeaponProficiencies()
        {
            return SplitDistinct(Proficiency);
        }

        /// <summary>
        /// Gets a list of weapon properties.
        /// </summary>
        public IEnumerable<string> GetWeaponProperties()
        {
            return SplitDistinct(Properties);
        }

        /// <summary>
        /// Gets a list of special weapon properties.
        /// </summary>
        public IEnumerable<string> GetSpecialWeaponProperties()
        {
            return SplitDistinct(SpecialProperties);
        }

        /// <summary>
        /// Gets a list of weapon groups.
        /// </summary>
        public IEnumerable<string> GetWeaponGroups()
        {
            return SplitDistinct(Group);
        }

        private static IEnumerable<string> SplitDistinct(string input)
        {
            return input
                .Split(ElementConstants.Properties.PropertiesSeparator, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Distinct();
        }
    }
}
