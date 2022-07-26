using Aurora.Core.Abstractions;
using Aurora.Core.Components.Item;

namespace Aurora.Core.Components;

public static class ComponentExtensions
{
    public static IElement AddItemComponent(this IElement element)
    {
        element.Components.AddComponent(new ItemComponent());
        return element;
    }

    public static IElement AddWeightComponent(this IElement element)
    {
        element.Components.AddComponent(new WeightComponent());
        return element;
    }

    public static IElement AddCostComponent(this IElement element)
    {
        element.Components.AddComponent(new CostComponent());
        return element;
    }
}
