namespace Aurora.Engine.Elements.Abstractions;

/// <summary>
/// The interface that represents a handler that evaluates conditions for the rule.
/// </summary>
public interface IRuleConditionHandler<TRule> where TRule : IElementRule
{
    bool EvaluateCondition(TRule rule);
}