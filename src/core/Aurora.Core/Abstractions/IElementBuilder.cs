namespace Aurora.Engine.Abstractions;

public interface IElementBuilder
{
    /// <summary>
    /// Create a new element that already includes the rules component.
    /// </summary>
    /// <returns>A new element.</returns>
    IElement Create();

    /// <summary>
    /// Compose a new element with the default element from the <see cref="Create"/> method as a starting point.
    /// </summary>
    /// <param name="configureElement">The action with the element to compose.</param>
    /// <returns>The composed element.</returns>
    IElement Compose(Action<IElement> configureElement);
}