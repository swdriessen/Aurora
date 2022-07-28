using Aurora.Engine.Abstractions;

namespace Aurora.Engine.Components.Item;

public class ItemComponent : IElementComponent
{
    /// <summary>
    /// Gets or sets the equipment category the item belongs to. (e.g. Adventuring Gear, Treasure, etc.)
    /// </summary>
    public string EquipmentCategory { get; set; } = string.Empty;

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