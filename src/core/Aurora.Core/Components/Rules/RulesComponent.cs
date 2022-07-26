namespace Aurora.Core.Components.Rules;

public class ItemComponent : IElementComponent
{
    public List<IElementRule> Rules { get; } = new List<IElementRule>();
}
