using Aurora.Engine.Elements.Abstractions;

namespace Aurora.Engine.Elements.Rules;

public class ElementRuleConditionHandler : IRuleConditionHandler<IElementRule>
{
    public bool EvaluateCondition(IElementRule rule)
    {
        return rule is not null && rule.Properties is not null; // always satisfies the condition for now :)
    }
}