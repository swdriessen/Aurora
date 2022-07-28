using Aurora.Engine.Abstractions;

namespace Aurora.Engine.Components.Description;

/// <summary>
/// Extension methods for working with the <see cref="DescriptionComponent"/> class.
/// </summary>
public static class DescriptionComponentExtensions
{
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
}