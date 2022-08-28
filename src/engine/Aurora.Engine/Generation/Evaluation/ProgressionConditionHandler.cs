using Aurora.Engine.Elements.Abstractions;
using Aurora.Engine.Elements.Rules;
using Microsoft.Extensions.Logging;

namespace Aurora.Engine.Generation.Evaluation;

/// <summary>
/// Initializes a new instance of the <see cref="ProgressionConditionHandler"/> class for evaluating the progression value for selection rules.
/// </summary>
public class ProgressionConditionHandler : IRuleConditionHandler<SelectionRule>
{
    private readonly ILogger<ProgressionConditionHandler> logger;
    private IProgressionManager? progressionManager;

    public ProgressionConditionHandler(ILogger<ProgressionConditionHandler> logger)
    {
        this.logger = logger;
        logger.LogInformation("create a {0} for the {1}", nameof(ProgressionConditionHandler), typeof(SelectionRule));
    }

    public void Initialize(IProgressionManager progressionManager)
    {
        this.progressionManager = progressionManager;
    }

    public bool EvaluateCondition(SelectionRule rule)
    {
        logger.LogInformation("evaluate: {0}", rule);

        if (progressionManager is null)
        {
            throw new InvalidOperationException($"Initialize the {nameof(ProgressionConditionHandler)} first by calling the Initialize method with a {nameof(IProgressionManager)}.");
        }

        // TODO: create a evaluation result to include messages on it in order to inform the user about certain prerequisites (non-level?)
        // e.g. when trying to select a feat you don't meet the [Strength 13] prerequisite for

        var result = rule.Level <= progressionManager.CurrentProgressionValue;

        logger.LogInformation("evaluate to {0}", result);

        return result;
    }
}