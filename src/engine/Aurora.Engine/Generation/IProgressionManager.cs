namespace Aurora.Engine.Generation;

public interface IProgressionManager
{
    /// <summary>
    /// Adds the element aggregate to the internal list of the progression manager and processes it.
    /// </summary>
    /// <param name="aggregate">The element aggregate to process.</param>
    void Process(ElementAggregate aggregate);
}