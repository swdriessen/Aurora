using Aurora.Engine.Elements.Abstractions;
using Aurora.Engine.Elements.Components.Level;
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

    private readonly List<ElementAggregate> aggregates = new();

    public ProgressionManager(ILogger<ProgressionManager> logger, IRuleConditionHandler<SelectionRule> conditionHandler, IElementSelectionHandlerManager selectionManager)
    {
        this.logger = logger;
        this.conditionHandler = conditionHandler;
        this.selectionManager = selectionManager;
    }

    public int CurrentProgressionValue { get; private set; }

    public virtual void Process(ElementAggregate aggregate)
    {
        logger.LogInformation("processing element: {Aggregate}", aggregate);
        logger.LogInformation("current progression value: {CurrentProgressionValue}", CurrentProgressionValue);

        // add to a collection to keep track and re-process 
        aggregates.Add(aggregate);

        #region Refactor Element Handlers

        // TODO: create handlers for dealing with specifics for certain types, pre-processing and post-processing
        if (aggregate.Element.ElementType == "Level" && aggregate.Element.Components.TryGetComponent<LevelComponent>(out var levelComponent))
        {
            CurrentProgressionValue = levelComponent.Level;
            logger.LogInformation("progression value was set to: {CurrentProgressionValue}", CurrentProgressionValue);
        }

        #endregion

        #region Rules Processing

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

                        if (selectionManager.HandlerExistsForSelectionRule(selectionRule.UniqueIdentifier))
                        {
                            logger.LogInformation("handler already exist for [{UniqueIdentifier}]", selectionRule.UniqueIdentifier);
                            continue;
                        }

                        var handlers = selectionManager.Create(selectionRule);


                        handlers.ForEach(handler =>
                        {
                            logger.LogInformation("created handler: [{UniqueIdentifier}]", handler.UniqueIdentifier);
                            _ = handler.Initialize(); // TODO: check where to initialize handlers (outside of direct processing unless there is a default selection?)
                            logger.LogInformation("handler [{UniqueIdentifier}] initialized", handler.UniqueIdentifier);
                        });
                    }
                    else
                    {
                        logger.LogInformation("evaluated... NOK");

                        if (selectionManager.HandlerExistsForSelectionRule(selectionRule.UniqueIdentifier))
                        {
                            logger.LogInformation("handler already exist for [{UniqueIdentifier}], remove it as it is no longer valid", selectionRule.UniqueIdentifier);
                            // TODO: remove handler for selection rule
                        }
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

        #endregion


        // process other things e.g. equipment or spellcasting
    }

    public void Remove(ElementAggregate aggregate) => throw new NotImplementedException();
}