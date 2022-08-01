namespace Aurora.Engine.Elements.Abstractions;

public interface IProperties
{
    /// <summary>
    /// Gets the properties associated with this object.
    /// </summary>
    IPropertiesCollection Properties { get; }
}