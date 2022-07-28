using Aurora.Engine.Abstractions;

namespace Aurora.Engine.Components.Extractable;

public interface IExtractableItem : IProperties
{
    /// <summary>
    /// Gets or sets the identifier of the extractable item.
    /// </summary>
    string Identifier { get; }

    /// <summary>
    /// Gets or sets the name of the extractable item.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the quantity of the item that needs to be extracted.
    /// </summary>
    int Quantity { get; }

    /// <summary>
    /// Gets a value indicating whether the item is an existing item instead of a custom item that has to be generated.
    /// </summary>
    /// <returns>True when the item exists in the existing content.</returns>
    bool IsExistingItem();
}