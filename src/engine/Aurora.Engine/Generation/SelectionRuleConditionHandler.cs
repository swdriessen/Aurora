using Aurora.Engine.Elements.Abstractions;
using Aurora.Engine.Elements.Rules;
using Microsoft.Extensions.Logging;

namespace Aurora.Engine.Generation;

/// <summary>
/// Initializes a new instance of the <see cref="SelectionRuleConditionHandler"/> class.
/// </summary>
public sealed class SelectionRuleConditionHandler : IRuleConditionHandler<SelectionRule>
{
    private readonly ILogger<SelectionRuleConditionHandler> logger;

    public SelectionRuleConditionHandler(ILogger<SelectionRuleConditionHandler> logger)
    {
        this.logger = logger;
    }

    public bool EvaluateCondition(SelectionRule rule)
    {
        // TODO: evaluate all conditions of the rule (e.g. level requirement)
        logger.LogWarning("evaluation for selection rules not implemented, always evaluates to true");
        return true;
    }
}