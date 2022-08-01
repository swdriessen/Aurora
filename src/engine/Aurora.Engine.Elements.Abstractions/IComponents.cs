namespace Aurora.Engine.Elements.Abstractions;

public interface IComponents
{
    /// <summary>
    /// Gets the components that provide additional functionallity.
    /// </summary>
    IElementComponentCollection Components { get; }
}
