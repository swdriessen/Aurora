using Aurora.Engine.Elements.Abstractions;

namespace Aurora.Engine.Elements.Components.Rules;

public class RulesComponent : IElementComponent
{
    public List<IElementRule> Rules { get; } = new();
}
