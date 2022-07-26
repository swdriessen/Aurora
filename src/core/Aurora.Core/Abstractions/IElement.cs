namespace Aurora.Core.Abstractions;

public interface IElement : IProperties
{
    string Identifier { get; set; }
    string Name { get; set; }
    string ElementType { get; set; }
    string Source { get; set; }

    /// <summary>
    /// Gets the components that make up this element's additional functionallity.
    /// </summary>
    ElementComponents Components { get; }
}