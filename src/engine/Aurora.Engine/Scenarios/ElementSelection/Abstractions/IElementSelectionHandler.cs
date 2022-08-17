namespace Aurora.Engine.Scenarios.ElementSelection.Abstractions;

public interface IElementSelectionHandler
{
    /// <summary>
    /// Gets the unique identifier for the selection handler.
    /// </summary>
    Guid UniqueIdentifier { get; }

    /// <summary>
    /// Initialize the handler for the current selection rule.
    /// </summary>
    Task Initialize();
}