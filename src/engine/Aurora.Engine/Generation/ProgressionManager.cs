using Aurora.Engine.Elements.Abstractions;
using Aurora.Engine.Elements.Components.Rules;
using Aurora.Engine.Elements.Rules;
using Aurora.Engine.Scenarios.ElementSelection.Abstractions;
using Microsoft.Extensions.Logging;

namespace Aurora.Engine.Generation;

/// <summary>
/// Initializes a new instance of the <see cref="ProgressionManager"/> class for processing elements.
/// </summary>
public class ProgressionManager : IProgressionManager
{
    private readonly ILogger<ProgressionManager> logger;
    private readonly IRuleConditionHandler<SelectionRule> conditionHandler;
    private readonly IElementSelectionHandlerManager selectionManager;

    public ProgressionManager(ILogger<ProgressionManager> logger, IRuleConditionHandler<SelectionRule> conditionHandler, IElementSelectionHandlerManager selectionManager)
    {
        this.logger = logger;
        this.conditionHandler = conditionHandler;
        this.selectionManager = selectionManager;
    }

    public int CurrentProgressionValue { get; }

    public void Process(ElementAggregate aggregate)
    {
        logger.LogInformation("processing element: {Aggregate}", aggregate);
        logger.LogInformation("current progression value: {CurrentProgressionValue}", CurrentProgressionValue);

        // process rules
        if (aggregate.Element.Components.TryGetComponent<RulesComponent>(out var rulesComponent))
        {
            logger.LogInformation("processing {RulesCount} rule(s)", rulesComponent.Rules.Count);

            foreach (var rule in rulesComponent.Rules)
            {
                // TODO: refactor after basic tests, only selection rule supported
                if (rule is SelectionRule selectionRule)
                {
                    logger.LogInformation("evaluating: {Rule}", selectionRule);
                    if (conditionHandler.EvaluateCondition(selectionRule))
                    {
                        logger.LogInformation("evaluated... OK");

                        // TODO: check on the selectionManager if it already exists

                        foreach (var handler in selectionManager.Create(selectionRule))
                        {
                            if (handler is null)
                            {
                                logger.LogError("handler is null");
                                continue;
                            }

                            logger.LogInformation("created handler: [{UniqueIdentifier}]", handler.UniqueIdentifier);
                            _ = handler.Initialize();

                            logger.LogInformation("handler [{UniqueIdentifier}] initialized", handler.UniqueIdentifier);
                        }
                    }
                    else
                    {
                        logger.LogInformation("evaluated... NOK");

                        // TODO: check on the selectionManager if it already exists
                        // if it does, undo it
                    }
                }
                else
                {
                    logger.LogError("skipping unknown rule: {Rule}", rule);
                }
            }
        }
        else
        {
            logger.LogWarning("The element did not have a rules component to process.");
        }

        // process other things e.g. equipment or spellcasting
    }
}