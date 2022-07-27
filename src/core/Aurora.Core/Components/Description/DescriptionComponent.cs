using Aurora.Core;

namespace Aurora.Engine.Components.Description;

public class DescriptionComponent : IElementComponent
{
    /// <summary>
    /// Gets or sets the description of the element.
    /// </summary>
    public string Content { get; set; } = string.Empty;
}