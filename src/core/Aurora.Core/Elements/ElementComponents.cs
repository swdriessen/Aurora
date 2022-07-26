namespace Aurora.Core;

public class ElementComponents
{
    private readonly List<IElementComponent> components = new();

    public ElementComponents()
    {

    }

    public void AddComponent<T>(T component) where T : IElementComponent
    {
        components.Add(component);
    }

    public T? GetComponent<T>() where T : IElementComponent
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
}