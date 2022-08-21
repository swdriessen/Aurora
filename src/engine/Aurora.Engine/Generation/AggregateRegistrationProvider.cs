using Microsoft.Extensions.DependencyInjection;

namespace Aurora.Engine.Generation;

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