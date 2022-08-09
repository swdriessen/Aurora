using Aurora.Engine.Elements.Abstractions;
using Aurora.Engine.Scenarios.ElementSelection.Abstractions;

namespace Aurora.Engine.Scenarios.ElementSelection;

/// <summary>
/// Initializes a new instance of the <see cref="ElementSelectionHandler"/> class.
/// </summary>
public class ElementSelectionHandler : IElementSelectionHandler, IElementSelectionInteractor
{
    private readonly ElementSelectionHandlerContext context;
    private readonly IElementSelectionDataProvider dataProvider;
    private readonly IElementRegistration registration;
    private readonly IElementSelectionPresenter presenter;

    private List<IElement>? elementsCollection;
    private List<ISelectionOption>? selectionOptions;
    private IElement? currentSelection;

    public ElementSelectionHandler(ElementSelectionHandlerContext context, IElementSelectionDataProvider dataProvider, IElementRegistration registration, IElementSelectionPresenter presenter)
    {
        this.context = context;
        this.dataProvider = dataProvider;
        this.registration = registration;
        this.presenter = presenter;
    }

    //TODO: check if action<options> configure is needed e.g. for selection number if multiple selections from single rule (order identifier)
    public Task Initialize()
    {
        // create a list of elements for this selection rule
        elementsCollection = new(dataProvider.GetElements(context.SelectionRule));

        // create a list of light weight selection options for the presenter
        selectionOptions = new(elementsCollection.Select(element => new SelectionOption(element.Identifier, element.Name)));

        // update the presenter
        presenter.UpdateHeader($"SELECTION: [type={context.SelectionRule.ElementType}, id={context.Identifier}, count={selectionOptions.Count}]");
        presenter.UpdateSelectionOptions(selectionOptions);

        return Task.CompletedTask;
    }

    public Task Register(string identifier)
    {
        if (elementsCollection is null)
        {
            throw new InvalidOperationException("Initialize the handler before trying to register an element.");
        }

        currentSelection = elementsCollection.First(x => x.Identifier == identifier);

        registration.Register(currentSelection);

        return Task.CompletedTask;
    }

    public Task Unregister()
    {
        if (elementsCollection is null)
        {
            throw new InvalidOperationException("Initialize the handler before trying to unregister an element.");
        }

        if (currentSelection is null)
        {
            throw new InvalidOperationException("Unable to unregister when no selection is made.");
        }

        registration.Unregister(currentSelection);

        return Task.CompletedTask;
    }

    public bool HasActiveSelection() => currentSelection is not null;
}