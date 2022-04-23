namespace Aurora.Engine.Data.Strings
{
    public static partial class ElementConstants
    {
        public static partial class Properties
        {
            public const string Abbreviation = "abbreviation";

            //abilities
            public const string Ability = "ability";
        }

        // sorting
        public static partial class Properties
        {
            public const string SortingOrder = "sort.order";
        }

        public static partial class SpellProperties
        {
            public const string Level = "spell.level";
            public const string MagicSchool = "spell.magic_school";

            public const string CastingTime = "spell.casting_time";
            public const string Range = "spell.range";
            public const string Duration = "spell.duration";

            public const string VerbalComponent = "component.verbal";
            public const string SomaticComponent = "component.somatic";
            public const string MaterialComponent = "component.material";
            public const string MaterialComponentDescription = "component.material_description";

            public const string Concentration = "spell.concentration";
            public const string Ritual = "spell.ritual";

            public const string Spellcasters = "spell.spellcasters";
        }

        public static partial class Properties
        {
            public const string PropertiesSeparator = ";";

            public const string ItemCostCurrencyDefault = "gp"; // default should be set from system config
            public const string ItemWeightUnitDefault = "lb."; // default should be set from system config



            public const string ItemCost = $"item.cost";
            public const string ItemCostCurrency = $"{ItemCost}.currency";
            public const string ItemCostFormat = $"{ItemCost}.format";
            public const string ItemCostFormatDefault = "{{cost}} {{cost.currency}}";

            public const string ItemWeight = "item.weight";
            public const string ItemWeightUnit = $"{ItemWeight}.unit";
            public const string ItemWeightFormat = $"{ItemWeight}.format";
            public const string ItemWeightFormatDefault = "{{weight}} {{weight.unit}}";
            public const string ItemWeightIgnore = $"{ItemWeight}.ignore";

            public const string ItemCategory = "item.category";
            public const string ItemType = "item.type";
            public const string ItemStackable = "item.stackable";
            public const string ItemNameFormat = "item.name_format";
            public const string ItemRarity = "item.rarity";

            public const string Enhancement = "enhancement";
            public const string EnhancementValue = $"{Enhancement}.value";
            public const string EnhancementTarget = $"{Enhancement}.target";

            public const string Equippable = "equippable";
            public const string EquippableTarget = $"{Equippable}.target";

            public const string Attunement = "attunement";
            public const string AttunementTarget = $"{Attunement}.target";

            public const string DamageDieQuantity = "damage.die.quantity";
            public const string DamageDieSize = "damage.die.size";
            public const string DamageType = "damage.type";

            public const string WeaponProficiency = "weapon.proficiency";
            public const string WeaponProperties = "weapon.properties";
            public const string WeaponPropertiesSpecial = "weapon.properties.special";
            public const string WeaponGroup = "weapon.group";
            public const string WeaponRange = "weapon.range";

            public const string AbilityKey = $"ability.key";




        }
    }
}
