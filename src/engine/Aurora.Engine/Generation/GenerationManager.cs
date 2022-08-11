using Microsoft.Extensions.Logging;

namespace Aurora.Engine.Generation;

/// <summary>
/// Create an instance of the <see cref="GenerationManager"/> class that manages the registered elements for the character.
/// </summary>
public class GenerationManager : IElementAggregateManager
{
    private readonly ILogger<GenerationManager> logger;
    private readonly List<ElementAggregate> aggregates = new();

    public GenerationManager(ILogger<GenerationManager> logger)
    {
        this.logger = logger;
    }

    public void Register(ElementAggregate aggregate)
    {
        logger.LogInformation("Registering: {Aggregate}", aggregate);

        aggregates.Add(aggregate);
    }

    public bool Unregister(ElementAggregate aggregate)
    {
        logger.LogInformation("Unregistering: {Aggregate}", aggregate);

        return aggregates.Remove(aggregate);
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", aggregates.Select(x => x.Element.Name))}]";
    }
}
