using Aurora.Engine.Elements.Abstractions;
using Aurora.Engine.Elements.Rules;
using Aurora.Engine.Scenarios.ElementSelection.Abstractions;

namespace Aurora.Engine.Scenarios.ElementSelection;

public class ElementSelectionDataProvider : IElementSelectionDataProvider
{
    private readonly Dictionary<string, List<IElement>> data = new();
    private readonly IElementDataProvider dataProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="ElementSelectionDataProvider"/> class with a data provider for all elements.
    /// </summary>
    /// <param name="dataProvider">The data provider for all elements.</param>
    public ElementSelectionDataProvider(IElementDataProvider dataProvider)
    {
        this.dataProvider = dataProvider;
    }

    public IEnumerable<IElement> GetElements(SelectionRule rule)
    {
        if (!data.ContainsKey(rule.ElementType))
        {
            data.Add(rule.ElementType, dataProvider.GetElements(e => e.ElementType == rule.ElementType).ToList());
        }

        return data[rule.ElementType].AsReadOnly();
    }
}