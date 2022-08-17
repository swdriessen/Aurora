namespace Aurora.Engine.Elements.Abstractions;

/// <summary>
/// The interface that represents a handler that evaluates conditions for the rule.
/// </summary>
public interface IRuleConditionHandler<TRule> where TRule : IElementRule
{
    /// <summary>
    /// Evaluate the conditions of the rule.
    /// </summary>
    /// <param name="rule">The rule to evaluate.</param>
    /// <returns>True if all conditions are satisfied and the rule can be applied.</returns>
    bool EvaluateCondition(TRule rule);
}