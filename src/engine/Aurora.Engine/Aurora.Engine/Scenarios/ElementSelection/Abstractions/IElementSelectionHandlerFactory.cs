namespace Aurora.Engine.Scenarios.ElementSelection.Abstractions;

public interface IElementSelectionHandlerFactory
{
    IElementSelectionHandler Create(ElementSelectionHandlerContext context);
}