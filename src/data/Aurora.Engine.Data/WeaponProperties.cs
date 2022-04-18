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

        public IEnumerable<string> GetProficiencies()
        {
            return Proficiency.Split(ElementStrings.Properties.PropertiesSeparator);
        }
    }
}
