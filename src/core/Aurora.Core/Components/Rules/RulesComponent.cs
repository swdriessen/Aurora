namespace Aurora.Core.Components.Rules;

public class RulesComponent : IElementComponent
{
    public List<IElementRule> Rules { get; } = new();
}
