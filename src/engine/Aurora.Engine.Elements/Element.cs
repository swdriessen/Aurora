using Aurora.Engine.Elements.Abstractions;

namespace Aurora.Engine.Elements;

/// <summary>
/// The element represents a composable element of the engine that is populated from loaded content.
/// </summary>
public class Element : IElement
{
    public string Identifier { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Name { get; set; } = string.Empty;
    public string ElementType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Source { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    /// <summary>
    /// Gets the properties associated with this element.
    /// </summary>
    public IPropertiesCollection Properties { get; } = new Properties();

    /// <summary>
    /// Gets the components that provide additional functionallity to this element.
    /// </summary>
    public IElementComponentCollection Components { get; } = new ElementComponents();
}