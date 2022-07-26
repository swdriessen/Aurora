namespace Aurora.Core.Components.Extractable;

public class ExtractableComponent : IElementComponent
{
    /// <summary>
    /// Gets or sets a value whether the item is extractable.
    /// </summary>
    public bool IsExtractable { get; set; }

    /// <summary>
    /// Gets a collection of extractable items.
    /// </summary>
    public List<IExtractableItem> ExtractableItems { get; } = new();
}
