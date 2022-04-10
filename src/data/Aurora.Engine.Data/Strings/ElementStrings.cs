﻿namespace Aurora.Engine.Data.Strings
{
    public static class ElementStrings
    {
        public static class Properties
        {
            public static class Item
            {
                public const string Category = $"item.category";
                public const string Type = $"item.type";
                public const string Stackable = $"item.stackable";
                public const string NameFormatting = $"item.name_format";

                public static class Cost
                {
                    public const string Value = $"item.cost.value";
                    public const string Currency = "item.cost.currency";
                    public const string DisplayFormat = "item.cost.display_format";
                    public const string DisplayFormatDefault = "{{item.cost.value}} {{item.cost.currency}}";
                }

                public static class Weight
                {
                    public const string Value = "item.weight.value";
                    public const string Unit = "item.weight.unit";
                    public const string DisplayFormat = "item.weight.display_format";
                    public const string DisplayFormatDefault = "{{item.weight.value}} {{item.weight.unit}}";
                    public const string Ignore = "item.weight.ignore";
                }
            }

            public static class Enhancement
            {
                public const string Value = "enhancement.value";
            }

        }
    }
}
