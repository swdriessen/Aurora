using Aurora.Core.Abstractions;

namespace Aurora.Core.Components.Rules;

public static class RulesComponentExtensions
{
    public static IElement AddRulesComponent(this IElement element)
    {
        element.Components.AddComponent(new ItemComponent());

        return element;
    }
}