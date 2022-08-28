using Aurora.Engine.Elements.Abstractions;

namespace Aurora.Engine.Generation.Evaluation;

/// <summary>
/// Initializes a new instance of the <see cref="RuleConditionHandler"/> class which is a generic rule conditional handler that supports executing a collection of handlers.
/// </summary>
/// <typeparam name="TRule"></typeparam>
public sealed class RuleConditionHandler<TRule> : IRuleConditionHandler<TRule> where TRule : IElementRule
{
    private readonly List<IRuleConditionHandler<TRule>> handlers = new();

    /// <summary>
    /// Adds a rule condition handler to the list of handlers that will be used in evaluation the condition.
    /// </summary>
    /// <param name="handler"></param>
    public void AddHandler(IRuleConditionHandler<TRule> handler)
    {
        handlers.Add(handler);
    }

    public bool EvaluateCondition(TRule rule)
    {
        var result = true;

        foreach (var handler in handlers)
        {
            result = result && handler.EvaluateCondition(rule);
        }

        return result;
    }
}