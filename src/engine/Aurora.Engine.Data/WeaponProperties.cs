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
            get { return properties.Get(ElementStrings.Properties.WeaponProficiency, string.Empty); }
        }

        private string Properties
        {
            get { return properties.Get(ElementStrings.Properties.WeaponProperties, string.Empty); }
        }

        private string Group
        {
            get { return properties.Get(ElementStrings.Properties.WeaponGroup, string.Empty); }
        }

        public string Range
        {
            get { return properties.Get(ElementStrings.Properties.WeaponRange, string.Empty); }
        }

        /// <summary>
        /// Gets a list of proficiencies.
        /// </summary>
        public IEnumerable<string> GetWeaponProficiencies()
        {
            return Proficiency.Split(ElementStrings.Properties.PropertiesSeparator, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Gets a list of weapon properties.
        /// </summary>
        public IEnumerable<string> GetWeaponProperties()
        {
            return Properties.Split(ElementStrings.Properties.PropertiesSeparator, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Gets a list of weapon groups.
        /// </summary>
        public IEnumerable<string> GetWeaponGroups()
        {
            return Group.Split(ElementStrings.Properties.PropertiesSeparator, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
