using Aurora.Engine.Elements.Rules;

namespace Aurora.Engine.Scenarios.ElementSelection.Abstractions;

public interface IElementSelectionHandlerManager
{
    /// <summary>
    /// Create a selection handler for the specified selection rule.
    /// </summary>
    /// <param name="selectionRule">The selection rule for which to create a selection handler.</param>
    /// <returns>The created selection handler.</returns>
    [Obsolete("a selection rule can create multiple handlers if needed, use Create instead")]
    IElementSelectionHandler CreateHandler(SelectionRule selectionRule);


    /// <summary>
    /// Create the selection handlers for the specified selection rule. One or many will be created depending on the quantity specified in the rule.
    /// </summary>
    /// <param name="selectionRule">The selection rule for which to create the selection handlers.</param>
    /// <returns>The created selection handlers.</returns>
    List<IElementSelectionHandler> Create(SelectionRule selectionRule);

    /// <summary>
    /// Gets a value indicating whether there are handlers created for the specific selection rule.
    /// </summary>
    /// <param name="ruleIdentifier">The unique identifier of the selection rule.</param>
    /// <returns>True when there area handlers created for the rule.</returns>
    bool HandlerExistsForSelectionRule(Guid ruleIdentifier);
}