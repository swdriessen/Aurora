using System.Diagnostics.CodeAnalysis;
using Aurora.Engine.Elements.Abstractions;

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
}