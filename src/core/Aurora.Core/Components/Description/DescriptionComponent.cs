using Aurora.Engine.Abstractions;

namespace Aurora.Engine.Components.Description;

/// <summary>
/// Initializes a new instance of the <see cref="DescriptionComponent"/> class to provide a description to an element.
/// </summary>
public class DescriptionComponent : IElementComponent
{
    /// <summary>
    /// Gets or sets the description of the element.
    /// </summary>
    public string Content { get; set; } = string.Empty;
}