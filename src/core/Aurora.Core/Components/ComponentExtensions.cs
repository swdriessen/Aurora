using Aurora.Engine.Abstractions;
using Aurora.Engine.Components.Extractable;
using Aurora.Engine.Components.Item;

namespace Aurora.Engine.Components;

public static class ComponentExtensions
{
    /// <summary>
    /// Adds the <see cref="ItemComponent"/> to the list of components of the element.
    /// </summary>
    /// <param name="element">The element to add the component to.</param>
    /// <returns>The element.</returns>
    public static IElement AddItemComponent(this IElement element)
    {
        element.Components.AddComponent(new ItemComponent());
        return element;
    }

    /// <summary>
    /// Adds the <see cref="WeightComponent"/> to the list of components of the element.
    /// </summary>
    /// <param name="element">The element to add the component to.</param>
    /// <returns>The element.</returns>
    public static IElement AddWeightComponent(this IElement element)
    {
        element.Components.AddComponent(new WeightComponent());
        return element;
    }

    /// <summary>
    /// Adds the <see cref="CostComponent"/> to the list of components of the element.
    /// </summary>
    /// <param name="element">The element to add the component to.</param>
    /// <returns>The element.</returns>
    public static IElement AddCostComponent(this IElement element)
    {
        element.Components.AddComponent(new CostComponent());
        return element;
    }

    /// <summary>
    /// Adds the <see cref="ExtractableComponent"/> to the list of components of the element.
    /// </summary>
    /// <param name="element">The element to add the component to.</param>
    /// <returns>The element.</returns>
    public static IElement AddExtractableComponent(this IElement element)
    {
        element.Components.AddComponent(new ExtractableComponent());
        return element;
    }
}
