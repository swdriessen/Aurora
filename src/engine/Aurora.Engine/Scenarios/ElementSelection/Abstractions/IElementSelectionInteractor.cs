namespace Aurora.Engine.Scenarios.ElementSelection.Abstractions;

public interface IElementSelectionInteractor
{
    /// <summary>
    /// Register the selection option.
    /// </summary>
    /// <param name="option">The selected option.</param>
    Task Register(string identifier);

    /// <summary>
    /// Unregister the current selection.
    /// </summary>
    Task Unregister();
}