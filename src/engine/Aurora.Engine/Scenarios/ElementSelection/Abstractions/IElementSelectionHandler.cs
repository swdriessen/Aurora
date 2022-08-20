using Aurora.Engine.Elements.Rules;

namespace Aurora.Engine.Scenarios.ElementSelection.Abstractions;

public interface IElementSelectionHandler
{
    /// <summary>
    /// Gets the unique identifier for the selection handler.
    /// </summary>
    Guid UniqueIdentifier { get; }

    /// <summary>
    /// Gets the selection rule associated with the selection handler.
    /// </summary>
    SelectionRule SelectionRule { get; }

    /// <summary>
    /// Initialize the handler for the current selection rule.
    /// </summary>
    Task Initialize();
}