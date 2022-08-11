namespace Aurora.Engine.Elements.Abstractions;

public static class ElementExtensions
{
    /// <summary>
    /// Configure an element component from the components collection. When the component already exists it configures the existing component, otherwise it will add a new component and configure that.
    /// </summary>
    public static IElement ConfigureComponent<T>(this IElement element, Action<T> component) where T : class, IElementComponent, new()
    {
        if (element.Components.TryGetComponent<T>(out var existingComponent))
        {
            component(existingComponent);
        }
        else
        {
            var instance = new T();
            component(instance);
            element.Components.AddComponent(instance);
        }

        return element;
    }
}