using Aurora.Core.Abstractions;
using Aurora.Core.Components.Extractable;
using Aurora.Core.Components.Item;
using Aurora.Engine.Components.Description;

namespace Aurora.Engine.Components;

public static class ComponentExtensions
{
    #region Description

    /// <summary>
    /// Adds the <see cref="DescriptionComponent"/> to the list of components of the element.
    /// </summary>
    /// <param name="element">The element to add the component to.</param>
    /// <returns>The element.</returns>
    public static IElement AddDescriptionComponent(this IElement element)
    {
        element.Components.AddComponent(new DescriptionComponent());
        return element;
    }

    /// <summary>
    /// Gets a value indicating whether the element has a <see cref="DescriptionComponent"/>.
    /// </summary>
    /// <param name="element">The element.</param>
    /// <returns>True when the element has a <see cref="DescriptionComponent"/>.</returns>
    public static bool HasDescriptionComponent(this IElement element)
    {
        return element.Components.ContainsComponent<DescriptionComponent>();
    }

    #endregion

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
