using Aurora.Engine.Elements.Abstractions;

namespace Aurora.Engine.Elements.Rules;

public abstract class ElementRuleBase : IElementRule
{
    /// <summary>
    /// Gets a collection of properties associated with this rule.
    /// </summary>
    public IPropertiesCollection Properties { get; } = new Properties();
}
