namespace Aurora.Engine.Elements.Abstractions;

public interface IElementDataProvider
{
    /// <summary>
    /// Gets an element that matches the predicate.
    /// </summary>
    /// <param name="predicate">The predicate to match your element.</param>
    /// <returns>The element if found, otherwise returns null.</returns>
    IElement? GetElement(Func<IElement, bool> predicate);

    /// <summary>
    /// Gets a collection of elements that matches the predicate.
    /// </summary>
    /// <param name="predicate">The predicate to match your elements.</param>
    /// <returns>The list of elements that match your predicate, otherwise returns an empty collection.</returns>
    IEnumerable<IElement> GetElements(Func<IElement, bool> predicate);
}