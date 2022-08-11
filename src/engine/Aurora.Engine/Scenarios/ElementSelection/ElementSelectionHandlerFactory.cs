using Aurora.Engine.Generation;
using Aurora.Engine.Scenarios.ElementSelection.Abstractions;

namespace Aurora.Engine.Scenarios.ElementSelection;

public class ElementSelectionHandlerFactory : IElementSelectionHandlerFactory
{
    private readonly IElementSelectionDataProvider dataProvider;
    private readonly IElementAggregateManager aggregateManager;
    private readonly IElementSelectionPresenterFactory presenterFactory;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dataProvider">selection data provider for getting rule elements</param>
    /// <param name="registration">where to register the element once it has been selection, e.g. the character manager</param>
    /// <param name="presenterFactory">create a presenter for the handler, the implementation will be something like a view model in the presentation/ui layer of the app</param>
    public ElementSelectionHandlerFactory(IElementSelectionDataProvider dataProvider, IElementAggregateManager aggregateManager, IElementSelectionPresenterFactory presenterFactory)
    {
        this.dataProvider = dataProvider;
        this.aggregateManager = aggregateManager;
        this.presenterFactory = presenterFactory;
    }

    public IElementSelectionHandler Create(ElementSelectionHandlerContext context)
    {
        var presenter = presenterFactory.CreatePresenter(configuration => { configuration.ElementType = context.SelectionRule.ElementType; });

        return new ElementSelectionHandler(context, dataProvider, aggregateManager, presenter);
    }
}
