namespace Aurora.Engine.Models;

public class Character
{
    public Character()
    {
        Name = "New Character";
    }

    /// <summary>
    /// Gets or sets the name of the character.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the level of the character.
    /// </summary>
    public int Level { get; set; }

    public override string ToString()
    {
        return $"{Name} (Level {Level})";
    }
}