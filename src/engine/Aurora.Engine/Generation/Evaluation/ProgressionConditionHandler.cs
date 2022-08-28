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

        var result = true;

        if (rule.Level == 0)
        {
            result = true;
        }
        else
        {
            result = rule.Level <= progressionManager.CurrentProgressionValue;
        }

        logger.LogInformation("evaluate to {0}", result);

        return result;
    }
}










/*
/// <summary>
/// Initializes a new instance of the <see cref="SelectionRuleConditionHandler"/> class.
/// </summary>
public sealed class SelectionRuleConditionHandler : IRuleConditionHandler<SelectionRule>
{
    private readonly ILogger<SelectionRuleConditionHandler> logger;
    private readonly ProgressionConditionHandler levelConditionHandler;

    private readonly List<IRuleConditionHandler<SelectionRule>> handlers = new();

    public SelectionRuleConditionHandler(ILogger<SelectionRuleConditionHandler> logger, ProgressionConditionHandler levelConditionHandler)
    {
        this.logger = logger;
        this.levelConditionHandler = levelConditionHandler;

        handlers.Add(this.levelConditionHandler);
    }

    public bool EvaluateCondition(SelectionRule rule)
    {
        var evaluation = true;

        // evaluate level requirements again the progression manager that contains the rule (character / class)
        //levelConditionHandler.CurrentProgressionValue = 0; // TODO: get the progression value from the correct progression manager
        logger.LogInformation("evaluating with progression value: {CurrentProgressionValue}", levelConditionHandler.CurrentProgressionValue);

        foreach (var handler in handlers)
        {
            evaluation = evaluation && handler.EvaluateCondition(rule);

            if (!evaluation)
            {
                logger.LogInformation("break when evaluation has not been satisfied, no need to keep processing");
                break;
            }
        }

        logger.LogInformation("evaluating to {Evaluation}", evaluation);
        return evaluation;
    }
}
*/




// get progression manager based on the rule.UniqueIdentifier
// how...
// IProgressionManager GetProgressionManager(Guid ruleIdentifier);

// also, get the character generation manager to get all the elements from all the progression mananagers
// how...
// IEnumerable<IProgressionManager> GetProgressionManagers();

// IProgressionManagerProvider
// can the char manager be the provider?
// it has access to them all
// 

