using Aurora.Engine.Abstractions;
using Aurora.Engine.Elements;

namespace Aurora.Engine.Rules;

public abstract class ElementRuleBase : IElementRule
{
    /// <summary>
    /// Gets a collection of properties associated with this rule.
    /// </summary>
    public Properties Properties { get; } = new();
}
