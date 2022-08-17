namespace Aurora.Engine.Generation;

public interface IProgressionManager
{
    /// <summary>
    /// Gets the value of the current progression.
    /// <para>e.g. the level of the character or class depending on the type of manager</para>
    /// </summary>
    int CurrentProgressionValue { get; }

    /// <summary>
    /// Adds the element aggregate to the internal list of the progression manager and processes it.
    /// </summary>
    /// <param name="aggregate">The element aggregate to process.</param>
    void Process(ElementAggregate aggregate);
}