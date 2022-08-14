using Aurora.Engine.Elements.Components.Rules;
using Aurora.Engine.Elements.Rules;
using Aurora.Engine.Scenarios.ElementSelection.Abstractions;
using Microsoft.Extensions.Logging;

namespace Aurora.Engine.Generation;

public class ProgressionManager : IProgressionManager
{
    private readonly ILogger<ProgressionManager> logger;
    private readonly IElementSelectionHandlerManager selectionManager;

    public ProgressionManager(ILogger<ProgressionManager> logger, IElementSelectionHandlerManager selectionManager)
    {
        this.logger = logger;
        this.selectionManager = selectionManager;
    }

    public void Process(ElementAggregate aggregate)
    {
        logger.LogInformation("Processing: {Aggregate}", aggregate);

        if (aggregate.Element.Components.TryGetComponent<RulesComponent>(out var component))
        {
            foreach (var rule in component.Rules)
            {
                if (rule is SelectionRule selectionRule)
                {
                    logger.LogInformation("Processing: {Rule}", selectionRule);
                    var handler = selectionManager.CreateHandler(selectionRule);
                    _ = handler.Initialize();
                }
                else
                {
                    logger.LogError("Unknown Rule: {Rule}", rule);
                }
            }
        }
    }
}
