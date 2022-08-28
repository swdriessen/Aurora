using Aurora.Engine.Elements.Abstractions;

namespace Aurora.Engine.Elements.Components.Rules;

public static class RulesComponentExtensions
{
    /// <summary>
    /// Adds the <see cref="RulesComponent"/> to the list of components of the element.
    /// </summary>
    /// <param name="element">The element to add the component to.</param>
    /// <returns>The element.</returns>
    public static IElement AddRulesComponent(this IElement element)
    {
        element.Components.AddComponent(new RulesComponent());
        return element;
    }

    /// <summary>
    /// Gets the <see cref="RulesComponent"/> associated with this element.
    /// </summary>
    /// <param name="element">The element.</param>
    /// <returns>The <see cref="RulesComponent"/> if it exists, otherwise throw a <see cref="ElementComponentNotFoundException"/> exception.</returns>
    public static RulesComponent GetRulesComponent(this IElement element)
    {
        return element.GetComponent<RulesComponent>();
    }
}