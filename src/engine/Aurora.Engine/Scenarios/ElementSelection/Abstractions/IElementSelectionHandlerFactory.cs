namespace Aurora.Engine.Scenarios.ElementSelection.Abstractions;

/// <summary>
/// Represents an implementation for a factory that creates selection handlers.
/// </summary>
public interface IElementSelectionHandlerFactory
{
    /// <summary>
    /// Creates a selection handler for a specific type of element.
    /// </summary>
    /// <param name="context">The context that determines what selection handler to create.</param>
    /// <returns>The selection handler based on the provided context.</returns>
    IElementSelectionHandler Create(ElementSelectionHandlerContext context);
}