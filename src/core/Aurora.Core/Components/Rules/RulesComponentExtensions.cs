using Aurora.Engine.Abstractions;

namespace Aurora.Engine.Components.Rules;

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
}