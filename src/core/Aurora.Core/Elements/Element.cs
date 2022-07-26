using Aurora.Core.Abstractions;

namespace Aurora.Core;

/// <summary>
/// The element represents the basic building block of the engine that is populated from loaded content.
/// </summary>
public class Element : IElement
{
    public string Identifier { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string ElementType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Source { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public ElementComponents Components { get; } = new();

    /// <summary>
    /// Gets the properties associated with this element.
    /// </summary>
    public Properties Properties { get; } = new();
}