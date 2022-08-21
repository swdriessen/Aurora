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