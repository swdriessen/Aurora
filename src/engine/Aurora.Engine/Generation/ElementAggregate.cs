using Aurora.Engine.Elements.Abstractions;

namespace Aurora.Engine.Generation;

/// <summary>
/// The aggregated element represents an element that has been assigned to a character. It holds additional information surrouding the assignment of the element as well as it's current state.
/// </summary>
public class ElementAggregate
{
    public ElementAggregate(IElement element)
    {
        Element = element;
        Identifier = Guid.NewGuid().ToString();
    }

    /// <summary>
    /// Gets the unique identifier for this aggregate.
    /// </summary>
    public string Identifier { get; }

    /// <summary>
    /// Gets the element associated with this aggregate.
    /// </summary>
    public IElement Element { get; }

    /// <summary>
    /// Create an <see cref="ElementAggregate"/> for the specified <see cref="IElement"/>.
    /// </summary>
    /// <param name="element">The element for which to create the aggregate.</param>
    /// <returns>The new element aggregate.</returns>
    public static ElementAggregate ForElement(IElement element)
    {
        return new ElementAggregate(element);
    }

    public override string ToString()
    {
        return $"[{Identifier}] {Element.Name}";
    }
}