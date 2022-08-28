using Aurora.Engine.Elements.Abstractions;

namespace Aurora.Engine.Generation.Evaluation;

public interface IRuleConditionHandlerProvider
{
    /// <summary>
    /// Creates a new condition handler for the specified rule using the provided progression manager.
    /// </summary>
    /// <typeparam name="T">The type of the element rule.</typeparam>
    /// <param name="manager">The progress manager instance connected to the evaluation.</param>
    /// <returns>A new instance of a condition handler to evaluate rules.</returns>
    IRuleConditionHandler<T> Create<T>(IProgressionManager progressionManager) where T : IElementRule;
}