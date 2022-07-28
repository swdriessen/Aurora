using Aurora.Engine.Abstractions;

namespace Aurora.Engine.Components.Rules;

public class RulesComponent : IElementComponent
{
    public List<IElementRule> Rules { get; } = new();
}
