using System.Diagnostics.CodeAnalysis;
using Aurora.Engine.Elements;
using Aurora.Engine.Elements.Abstractions;
using Aurora.Engine.Elements.Components.Level;

namespace Aurora.Engine.Tests;

[ExcludeFromCodeCoverage]
internal static class UnitTestElements
{
    /// <summary>
    /// Gets a element of the type 'Level' for use in unit tests.
    /// </summary>
    /// <param name="level">The level the element represents.</param>
    /// <returns>The level element.</returns>
    public static IElement GetLevelElement(int level = 1)
    {
        return Element.Compose(element =>
        {
            element.Name = $"Level {level}";
            element.ElementType = "Level";
            element.ConfigureComponent<LevelComponent>(component => { component.Level = level; });
        });
    }
}
