namespace Aurora.Engine.Elements.Rules;

/// <summary>
/// Initializes a new instance of the <see cref="StatisticRule"/> class.
/// </summary>
public class StatisticRule : ElementRuleBase
{
    public StatisticRule(string name, string value)
    {
        Name = name;
        Value = value;
    }

    /// <summary>
    /// Gets or sets the name of the statistic.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the value of the statistic.
    /// </summary>
    public string Value { get; set; }
}