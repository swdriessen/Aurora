using Aurora.Engine.Models;
using Microsoft.Extensions.Logging;

namespace Aurora.Engine.Generation;

/// <summary>
/// Create an instance of the <see cref="CharacterGenerationManager"/> class that manages the registered elements for the character.
/// </summary>
public class CharacterGenerationManager : IElementAggregateManager
{
    private readonly ILogger<CharacterGenerationManager> logger;
    private readonly List<ElementAggregate> aggregates = new();

    public CharacterGenerationManager(ILogger<CharacterGenerationManager> logger)
    {
        this.logger = logger;
    }

    public Character Character { get; } = new();

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
