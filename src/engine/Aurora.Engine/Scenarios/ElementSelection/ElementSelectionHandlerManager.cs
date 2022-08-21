using Aurora.Engine.Elements.Rules;
using Aurora.Engine.Scenarios.ElementSelection.Abstractions;

namespace Aurora.Engine.Scenarios.ElementSelection;

public class ElementSelectionHandlerManager : IElementSelectionHandlerManager
{
    private readonly IElementSelectionHandlerFactory handlerFactory;

    private readonly Dictionary<Guid, IElementSelectionHandler> handlers = new();

    public ElementSelectionHandlerManager(IElementSelectionHandlerFactory handlerFactory)
    {
        this.handlerFactory = handlerFactory;
    }

    public List<IElementSelectionHandler> Create(SelectionRule selectionRule)
    {
        var newHandlers = new List<IElementSelectionHandler>();

        foreach (var orderIdentifier in Enumerable.Range(1, selectionRule.Quantity))
        {
            var context = ElementSelectionHandlerContext.Create(selectionRule, orderIdentifier);
            var handler = handlerFactory.Create(context);
            newHandlers.Add(handler);

            handlers.Add(handler.UniqueIdentifier, handler);
        }

        return newHandlers;
    }

    public bool HandlerExistsForSelectionRule(Guid ruleIdentifier)
    {
        return handlers.Values.Any(handler => handler.SelectionRule.UniqueIdentifier.Equals(ruleIdentifier));
    }
}
