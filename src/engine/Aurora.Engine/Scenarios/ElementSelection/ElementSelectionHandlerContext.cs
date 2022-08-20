using Aurora.Engine.Elements.Rules;

namespace Aurora.Engine.Scenarios.ElementSelection;

public class ElementSelectionHandlerContext
{
    private ElementSelectionHandlerContext(Guid identifier, SelectionRule selectionRule, int orderIdentifier)
    {
        Identifier = identifier;
        SelectionRule = selectionRule;
        OrderIdentifier = orderIdentifier;
    }

    /// <summary>
    /// Gets a unique identifier for the selection handler associated with this context.
    /// </summary>
    public Guid Identifier { get; }

    /// <summary>
    /// Gets the selection rule associated with this context.
    /// </summary>
    public SelectionRule SelectionRule { get; }

    /// <summary>
    /// Gets the order identifier for the selection handler associated with this context. This ranges from 1 to n.
    /// </summary>
    public int OrderIdentifier { get; }

    /// <summary>
    /// Create a new selection handler context with a generated identifier.
    /// </summary>
    /// <param name="selectionRule">The selection rule associated with this context.</param>
    /// <param name="orderIdentifier">The order identifier associated with this context.</param>
    /// <returns>A new context.</returns>
    public static ElementSelectionHandlerContext Create(SelectionRule selectionRule, int orderIdentifier = 1)
    {
        return new ElementSelectionHandlerContext(Guid.NewGuid(), selectionRule, orderIdentifier);
    }
}
