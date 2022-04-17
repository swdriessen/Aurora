namespace Aurora.Engine.Data.Strings
{
    public static class ElementStrings
    {
        public static partial class Properties
        {
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

            public const string Enhancement = "enhancement";
            public const string EnhancementValue = $"{Enhancement}.value";

            public const string Equippable = "equippable";
            public const string EquippableTarget = $"{Equippable}.target";

            public const string Attunement = "attunement";
            public const string AttunementTarget = $"{Attunement}.target";
        }
    }
}
