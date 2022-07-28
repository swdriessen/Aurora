using Aurora.Engine.Elements;

namespace Aurora.Engine.Abstractions;

public interface IElement : IProperties
{
    /// <summary>
    /// Gets or sets the identifier of the element.
    /// </summary>
    string Identifier { get; set; }

    /// <summary>
    /// Gets or sets the name of the element.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// Gets or sets the specific type of the element.
    /// <para>e.g. Class Feature, Spell, Magic Item</para>
    /// </summary>
    string ElementType { get; set; }

    /// <summary>
    /// Gets or sets the source of the element.
    /// <para>//TODO: this probably should become a component due to the additional information that might be associated with the source (e.g. specific url, specific page, id of Source element)</para>
    /// </summary>
    string Source { get; set; }

    /// <summary>
    /// Gets the components that make up this element's additional functionallity.
    /// </summary>
    ElementComponents Components { get; }
}