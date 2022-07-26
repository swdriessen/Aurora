namespace Aurora.Core;

public class ElementComponents
{
    private readonly List<IElementComponent> components = new();

    public ElementComponents()
    {

    }

    public void AddComponent<T>(T component) where T : IElementComponent
    {
        if (ContainsComponentType(component.GetType()))
        {
            throw new ArgumentException($"This component '{component.GetType()}' has already been added to the element.");
        }

        components.Add(component);
    }

    public T? GetComponent<T>() where T : class, IElementComponent
    {
        foreach (var component in components)
        {
            if (component is T elementComponent)
            {
                return elementComponent;
            }
        }

        return default;
    }

    public bool ContainsComponent<T>() where T : class, IElementComponent
    {
        return components.Any(x => x.GetType() == typeof(T));
    }

    public bool ContainsComponentType(Type type)
    {
        return components.Any(x => x.GetType() == type);
    }

    public bool HasComponents() => components.Any();

}