namespace Aurora.Engine.Scenarios.ElementSelection.Abstractions;

public interface IElementSelectionHandler
{
    /// <summary>
    /// Initialize the handler for the current selection rule.
    /// </summary>
    Task Initialize();
}