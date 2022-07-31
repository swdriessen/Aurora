namespace Aurora.Engine.Elements.Rules;

/// <summary>
/// Initializes a new instance of the <see cref="IncludeRule"/> class.
/// </summary>
public class IncludeRule : ElementRuleBase
{
    public IncludeRule(string elementType, string elementIdentifier)
    {
        ElementType = elementType;
        ElementIdentifier = elementIdentifier;
    }

    /// <summary>
    /// Gets or sets the element type for the include rule.
    /// </summary>
    public string ElementType { get; set; }

    /// <summary>
    /// Gets or sets the element identifier for the element to include.
    /// </summary>
    public string ElementIdentifier { get; set; }
}