using Aurora.Engine.Elements.Abstractions;
using Aurora.Engine.Elements.Rules;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Aurora.Engine.Generation;

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
