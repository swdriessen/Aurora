using System.Diagnostics.CodeAnalysis;
using Aurora.Engine.Elements.Abstractions;

namespace Aurora.Engine.Elements;

public class ElementComponents : IElementComponentCollection
{
    private readonly List<IElementComponent> components = new();

    public void AddComponent<T>(T component) where T : class, IElementComponent
    {
        if (components.Any(x => x is T))
        {
            throw new ArgumentException($"This component '{component.GetType()}' has already been added to the element.");
        }

        components.Add(component);
    }

    public bool TryGetComponent<T>([NotNullWhen(true)] out T? component) where T : class, IElementComponent
    {
        component = components.FirstOrDefault(x => x is T) as T;
        return component is not null;
    }

    public bool HasComponents() => components.Any();
}