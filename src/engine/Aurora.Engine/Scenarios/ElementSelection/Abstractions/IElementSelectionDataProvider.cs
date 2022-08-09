using Aurora.Engine.Elements.Abstractions;
using Aurora.Engine.Elements.Rules;

namespace Aurora.Engine.Scenarios.ElementSelection.Abstractions;

public interface IElementSelectionDataProvider
{
    IEnumerable<IElement> GetElements(SelectionRule rule);
}