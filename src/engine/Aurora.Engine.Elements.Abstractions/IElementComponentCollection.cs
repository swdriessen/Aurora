namespace Aurora.Engine.Elements.Abstractions;

public interface IElementComponentCollection
{
    /// <summary>
    /// Adds an <see cref="IElementComponent"/> to the collection.
    /// </summary>
    /// <typeparam name="T">The type of the component.</typeparam>
    /// <param name="component">The component to add.</param>
    void AddComponent<T>(T component) where T : class, IElementComponent;

    /// <summary>
    /// Tries to get the <see cref="IElementComponent"/> from the collection.
    /// </summary>
    /// <typeparam name="T">The type of the component.</typeparam>
    /// <param name="component">The component to retrieve.</param>
    /// <returns>True when the component was found.</returns>
    bool TryGetComponent<T>(out T component) where T : class, IElementComponent;

    /// <summary>
    /// Gets a value indicating whether the collection contains any components.
    /// </summary>
    /// <returns>True if the collection contains any components.</returns>
    bool HasComponents();
}