using Aurora.Engine.Elements.Abstractions;

namespace Aurora.Engine.Generation.Evaluation;

public interface IRuleConditionHandlerProvider
{
    /// <summary>
    /// Creates a new condition handler for the specified rule using the provided progression manager.
    /// </summary>
    /// <typeparam name="T">The type of the element rule.</typeparam>
    /// <param name="manager">The progress manager instance connected to the evaluation.</param>
    /// <returns>A new instance of a condition handler to evaluate rules.</returns>
    IRuleConditionHandler<T> Create<T>(IProgressionManager progressionManager) where T : IElementRule;
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

