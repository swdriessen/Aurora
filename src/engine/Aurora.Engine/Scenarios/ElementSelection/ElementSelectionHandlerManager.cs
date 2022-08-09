using Aurora.Engine.Elements.Rules;
using Aurora.Engine.Scenarios.ElementSelection.Abstractions;

namespace Aurora.Engine.Scenarios.ElementSelection;

public class ElementSelectionHandlerManager : IElementSelectionHandlerManager
{
    private readonly IElementSelectionDataProvider dataProvider;
    private readonly IElementRegistration registration;
    private readonly IElementSelectionPresenterFactory presenterFactory;
    private readonly IElementSelectionHandlerFactory handlerFactory;

    private readonly Dictionary<string, IElementSelectionHandler> handlers = new();

    public ElementSelectionHandlerManager(IElementSelectionDataProvider dataProvider, IElementRegistration registration, IElementSelectionPresenterFactory presenterFactory, IElementSelectionHandlerFactory handlerFactory)
    {
        this.dataProvider = dataProvider;
        this.registration = registration; // char manager or another manager based on selection rule
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
