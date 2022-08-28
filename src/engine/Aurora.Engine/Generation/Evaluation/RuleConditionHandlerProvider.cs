using Aurora.Engine.Elements.Abstractions;
using Aurora.Engine.Elements.Rules;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Aurora.Engine.Generation.Evaluation;

/// <summary>
/// Initializes a new instance of the <see cref="RuleConditionHandlerProvider"/> class.
/// </summary>
public sealed class RuleConditionHandlerProvider : IRuleConditionHandlerProvider
{
    private readonly ILogger<RuleConditionHandlerProvider> logger;
    private readonly IServiceProvider provider;

    public RuleConditionHandlerProvider(ILogger<RuleConditionHandlerProvider> logger, IServiceProvider provider)
    {
        this.logger = logger;
        this.provider = provider;
    }

    public IRuleConditionHandler<T> Create<T>(IProgressionManager progressionManager) where T : IElementRule
    {
        var handler = new RuleConditionHandler<T>();

        // TODO: when there is something generic for the rules, make it available on the IElementRule interface and create a generic evaluator
        // i.e. the level requirement is something that applies to all rules and is pulled from the progression manager

        if (typeof(T).Equals(typeof(SelectionRule)))
        {
            var progressionHandler = provider.GetRequiredService<ProgressionConditionHandler>();
            progressionHandler.Initialize(progressionManager);
            handler.AddHandler((IRuleConditionHandler<T>)progressionHandler);

            // create a handler for the equipped expression
            // create a handler for the requirements expression
            // create a handler for ...
        }

        return handler;
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

