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