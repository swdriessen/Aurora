using Aurora.Engine.Elements.Abstractions;

namespace Aurora.Engine.Elements.Components.Level;

public class LevelComponent : IElementComponent
{
    /// <summary>
    /// Gets or sets the level of character progression.
    /// </summary>
    public int Level { get; set; }
}