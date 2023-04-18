using Aurora.Engine.Elements.Abstractions;

namespace Aurora.Engine.Elements.Components.Level;

/// <summary>
/// Extension methods for working with the <see cref="LevelComponent"/> class.
/// </summary>
public static class LevelComponentExtensions
{
    /// <summary>
    /// The type of the level element.
    /// </summary>
    private const string Level = "Level";

    /// <summary>
    /// Gets a value indicating whether this element is a Level element which contains a <see cref="LevelComponent"/>.
    /// </summary>
    /// <param name="element">The element.</param>
    /// <returns>True when the element can be treated as a Level.</returns>
    public static bool IsLevel(this IElement element)
    {
        return element.ElementType is (Level); // && element.TryGetComponent<LevelComponent>(out var _);
    }

    /// <summary>
    /// Gets the <see cref="LevelComponent"/> associated with this element.
    /// </summary>
    /// <param name="element">The element.</param>
    /// <returns>The <see cref="LevelComponent"/> if it exists, otherwise throws an <see cref="ElementComponentNotFoundException"/> exception.</returns>
    public static LevelComponent GetLevelComponent(this IElement element)
    {
        return element.GetComponent<LevelComponent>();
    }
}