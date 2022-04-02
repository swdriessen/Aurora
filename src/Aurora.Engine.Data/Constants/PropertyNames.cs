namespace Aurora.Engine.Data.Constants
{
    public static class PropertyNames
    {
        public static class Equipment
        {
            public static class Cost
            {
                public const string Value = $"equipment.cost.value";
                public const string Currency = "equipment.cost.currency";
                public const string DisplayFormat = "equipment.cost.displayformat";
                public const string DisplayFormatDefault = "{{equipment.cost.value}} {{equipment.cost.currency}}";
            }
            public static class Weight
            {
                public const string Value = "equipment.weight.value";
                public const string Unit = "equipment.weight.unit";
                public const string DisplayFormat = "equipment.weight.displayformat";
                public const string DisplayFormatDefault = "{{equipment.weight.value}} {{equipment.weight.unit}}";
            }
        }
    }
}
