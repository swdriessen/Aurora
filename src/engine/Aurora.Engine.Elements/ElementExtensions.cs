using System.Diagnostics.CodeAnalysis;
using Aurora.Engine.Elements.Abstractions;
using Aurora.Engine.Elements.Components;

namespace Aurora.Engine.Elements;

public static class ElementExtensions
{
    public static IElement AddComponent<T>(this IElement element, T component) where T : class, IElementComponent
    {
        element.Components.AddComponent(component);

        return element;
    }

    public static bool TryGetComponent<T>(this IElement element, [NotNullWhen(true)] out T? component) where T : class, IElementComponent
    {
        return element.Components.TryGetComponent(out component);
    }

    /// <summary>
    /// Gets the specified element component associated with this element.
    /// </summary>
    /// <param name="element">The element from which to get the component.</param>
    /// <returns>The requested component if it exists, otherwise throw a <see cref="ElementComponentNotFoundException"/> exception.</returns>
    public static T GetComponent<T>(this IElement element) where T : class, IElementComponent
    {
        return element.Components.TryGetComponent<T>(out var component) ? component : throw new ElementComponentNotFoundException($"The '{nameof(T)}' was not found in the '{element.Name}' element.");
    }
}