using Microsoft.Extensions.DependencyInjection;

namespace Aurora.Engine.Generation;

public interface IElementAggregateRegistrationManager
{
    /// <summary>
    /// Register the <see cref="ElementAggregate"/> with the manager.
    /// </summary>
    void Register(ElementAggregate aggregate);

    /// <summary>
    /// Unregister the <see cref="ElementAggregate"/> with the manager.
    /// </summary>
    bool Unregister(ElementAggregate aggregate);
}

public interface IAggregateRegistrationProvider
{
    IElementAggregateRegistrationManager GetAggregateRegistrationManager();
}

public sealed class AggregateRegistrationProvider : IAggregateRegistrationProvider
{
    private readonly IServiceProvider provider;

    public AggregateRegistrationProvider(IServiceProvider provider)
    {
        this.provider = provider;
    }

    public IElementAggregateRegistrationManager GetAggregateRegistrationManager()
    {
        return provider.GetRequiredService<IElementAggregateRegistrationManager>();
    }
}