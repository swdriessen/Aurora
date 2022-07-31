namespace Aurora.Engine.Elements.Rules;

/// <summary>
/// Initializes a new instance of the <see cref="SelectionRule"/> class.
/// </summary>
public class SelectionRule : ElementRuleBase
{
    public SelectionRule(string elementType)
    {
        ElementType = elementType;
    }

    /// <summary>
    /// Gets or sets the element type for the selection rule.
    /// </summary>
    public string ElementType { get; set; }
}
