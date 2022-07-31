using Aurora.Engine.Elements.Abstractions;
using Aurora.Engine.Elements.Elements;

namespace Aurora.Engine.Elements.Rules;

public abstract class ElementRuleBase : IElementRule
{
    /// <summary>
    /// Gets a collection of properties associated with this rule.
    /// </summary>
    public Properties Properties { get; } = new();
}
