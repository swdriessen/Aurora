namespace Aurora.Engine.Scenarios.ElementSelection.Abstractions;

public interface ISelectionOption
{
    /// <summary>
    /// Gets or sets the identifier of the option.
    /// </summary>
    string Identifier { get; }

    /// <summary>
    /// Gets or sets the name of the option.
    /// </summary>
    string Name { get; }
}