using Aurora.Engine.Models;
using Microsoft.Extensions.Logging;

namespace Aurora.Engine.Generation;

/// <summary>
/// Create an instance of the <see cref="CharacterGenerationManager"/> class that manages the registered elements for the character.
/// </summary>
public class CharacterGenerationManager : IElementAggregateRegistrationManager
{
    private readonly ILogger<CharacterGenerationManager> logger;
    private readonly IProgressionManager characterProgressionManager; //for now, a single progression

    public CharacterGenerationManager(ILogger<CharacterGenerationManager> logger, IProgressionManager characterProgressionManager)
    {
        this.logger = logger;
        this.characterProgressionManager = characterProgressionManager;
    }

    public Character Character { get; } = new();

    public void Register(ElementAggregate aggregate)
    {
        logger.LogInformation("Registering: {Aggregate}", aggregate);

        characterProgressionManager.Process(aggregate);

        Character.Level = characterProgressionManager.CurrentProgressionValue;
    }

    public bool Unregister(ElementAggregate aggregate)
    {
        logger.LogInformation("Unregistering: {Aggregate}", aggregate);

        return characterProgressionManager.Remove(aggregate);
    }
}