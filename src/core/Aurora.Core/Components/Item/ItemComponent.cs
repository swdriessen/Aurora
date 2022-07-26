namespace Aurora.Core.Components.Item;

public class ItemComponent : IElementComponent
{
    /// <summary>
    /// Gets or sets a value whether the item is stackable.
    /// </summary>
    public bool IsStackable { get; set; }

    /// <summary>
    /// Gets or sets a value whether the item is consumable.
    /// </summary>
    public bool IsConsumable { get; set; }

    /// <summary>
    /// Gets or sets the rarity of the item.
    /// </summary>
    public string Rarity { get; set; } = string.Empty;
}