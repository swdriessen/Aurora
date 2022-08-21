namespace Aurora.Engine.Generation;

public interface IAggregateRegistrationProvider
{
    IElementAggregateRegistrationManager GetAggregateRegistrationManager();
}
