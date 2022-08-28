using Aurora.Engine.Elements.Abstractions;
using Aurora.Engine.Elements.Components.Level;
using Aurora.Engine.Elements.Components.Rules;
using Aurora.Engine.Elements.Rules;
using Aurora.Engine.Generation.Evaluation;
using Aurora.Engine.Scenarios.ElementSelection.Abstractions;
using Microsoft.Extensions.Logging;

namespace Aurora.Engine.Generation;

/// <summary>
/// Initializes a new instance of the <see cref="ProgressionManager"/> class for processing elements.
/// </summary>
public class ProgressionManager : IProgressionManager
{
    private readonly ILogger<ProgressionManager> logger;
    private readonly IRuleConditionHandler<SelectionRule> selectionConditionHandler;
    private readonly IElementSelectionHandlerManager selectionManager;

    private readonly List<ElementAggregate> aggregates = new();

    public ProgressionManager(ILogger<ProgressionManager> logger, IRuleConditionHandlerProvider ruleConditionHandlerProvider, IElementSelectionHandlerManager selectionManager)
    {
        this.logger = logger;
        this.selectionManager = selectionManager;

        logger.LogInformation("create the condition handler for selection rules");
        selectionConditionHandler = ruleConditionHandlerProvider.Create<SelectionRule>(this);
    }

    public int CurrentProgressionValue { get; private set; }

    public virtual void Process(ElementAggregate aggregate)
    {
        aggregates.Add(aggregate);

        logger.LogInformation("processing element: {Aggregate}", aggregate);
        logger.LogInformation("current progression value: {CurrentProgressionValue}", CurrentProgressionValue);

        #region Refactor Element Handlers

        // only set level once, not when reprocessing

        // TODO: create handlers for dealing with specifics for certain types, pre-processing and post-processing
        if (aggregate.Element.ElementType == "Level" && aggregate.Element.Components.TryGetComponent<LevelComponent>(out var levelComponent))
        {
            CurrentProgressionValue = levelComponent.Level;
            logger.LogInformation("progression value was set to: {CurrentProgressionValue}", CurrentProgressionValue);
        }

        #endregion

        ProcessInternal(aggregate);
    }

    public bool Remove(ElementAggregate aggregate)
    {
        #region Refactor Element Handlers

        // TODO: create handlers for dealing with specifics for certain types, pre-processing and post-processing
        if (aggregate.Element.ElementType == "Level" && aggregate.Element.Components.TryGetComponent<LevelComponent>(out var levelComponent))
        {
            // get last level prior to this one
            var lastLevel = aggregates.Where(x => x.Element.ElementType == "Level" && x.Element.Components.TryGetComponent<LevelComponent>(out var _))
                .Where(x => !x.Equals(aggregate))
                .Last();

            if (lastLevel.Element.Components.TryGetComponent<LevelComponent>(out var lastLevelComponent))
            {
                CurrentProgressionValue = lastLevelComponent.Level;
                logger.LogInformation("progression value was set to: {CurrentProgressionValue}", CurrentProgressionValue);
            }
            else
            {
                CurrentProgressionValue--; // TODO: check only last added levels can be removed, or just ++ it when a level gets registered for now?
                logger.LogInformation("progression value was decreased by 1 to: {CurrentProgressionValue}", CurrentProgressionValue);
            }
        }

        #endregion


        UnprocessInternal(aggregate);

        return aggregates.Remove(aggregate);
    }

    public void Reprocess()
    {
        foreach (var aggregate in aggregates)
        {
            ProcessInternal(aggregate);
        }
    }

    #region Processing

    private void ProcessInternal(ElementAggregate aggregate)
    {
        ProcessRules(aggregate);
        // process other things e.g. equipment or spellcasting
    }

    private void ProcessRules(ElementAggregate aggregate)
    {
        if (aggregate.Element.Components.TryGetComponent<RulesComponent>(out var rulesComponent))
        {
            logger.LogInformation("processing {RulesCount} rule(s)", rulesComponent.Rules.Count);

            foreach (var rule in rulesComponent.Rules)
            {
                // TODO: refactor after basic tests, only selection rule supported
                if (rule is SelectionRule selectionRule)
                {
                    logger.LogInformation("evaluating: {Rule}", selectionRule);
                    if (selectionConditionHandler.EvaluateCondition(selectionRule))
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
                            selectionManager.Remove(selectionRule);
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
    }

    #endregion

    #region Unprocessing

    private void UnprocessInternal(ElementAggregate aggregate)
    {
        RevertSelectionRules(aggregate);
    }

    private void RevertSelectionRules(ElementAggregate aggregate)
    {
        if (aggregate.Element.Components.TryGetComponent<RulesComponent>(out var rulesComponent))
        {
            foreach (var rule in rulesComponent.Rules)
            {
                // TODO: refactor after basic tests, only selection rule supported
                if (rule is SelectionRule selectionRule)
                {
                    if (selectionManager.HandlerExistsForSelectionRule(selectionRule.UniqueIdentifier))
                    {
                        logger.LogInformation("handler already exist for [{UniqueIdentifier}]", selectionRule.UniqueIdentifier);

                        // get handler to unregister what was registered
                        // or do we remove the handler and remove the element that was selected by this selection rule (aquisition data = selected etc...)
                        // aggregate.origin.rule.identifier
                        // or just let selection manager unregister it ?
                        // first step remove selection handlers that have no active selection made
                        selectionManager.Remove(selectionRule);
                    }
                }
                else
                {
                    logger.LogError("skipping unknown rule: {Rule}", rule);
                }
            }
        }
    }

    #endregion

}