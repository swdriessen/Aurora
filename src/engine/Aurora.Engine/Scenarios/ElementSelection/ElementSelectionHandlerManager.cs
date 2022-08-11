using Aurora.Engine.Elements.Rules;
using Aurora.Engine.Generation;
using Aurora.Engine.Scenarios.ElementSelection.Abstractions;

namespace Aurora.Engine.Scenarios.ElementSelection;

public class ElementSelectionHandlerManager : IElementSelectionHandlerManager
{
    private readonly IElementSelectionDataProvider dataProvider;
    private readonly IElementAggregateManager aggregateManager;
    private readonly IElementSelectionPresenterFactory presenterFactory;
    private readonly IElementSelectionHandlerFactory handlerFactory;

    private readonly Dictionary<string, IElementSelectionHandler> handlers = new();

    public ElementSelectionHandlerManager(IElementSelectionDataProvider dataProvider, IElementAggregateManager aggregateManager, IElementSelectionPresenterFactory presenterFactory, IElementSelectionHandlerFactory handlerFactory)
    {
        this.dataProvider = dataProvider;
        this.aggregateManager = aggregateManager;
        this.presenterFactory = presenterFactory;
        this.handlerFactory = handlerFactory;
    }

    public IElementSelectionHandler CreateHandler(SelectionRule selectionRule)
    {
        var context = ElementSelectionHandlerContext.Create(selectionRule);

        var handler = handlerFactory.Create(context);

        handlers.Add(context.Identifier, handler);

        return handler;
    }
}
