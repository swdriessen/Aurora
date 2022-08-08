using Aurora.Engine.Elements.Rules;

namespace Aurora.Engine.Scenarios.ElementSelection.Abstractions;

public interface IElementSelectionHandlerManager
{
    IElementSelectionHandler CreateHandler(SelectionRule selectionRule);
}