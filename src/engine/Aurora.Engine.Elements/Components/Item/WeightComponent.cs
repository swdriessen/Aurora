using Aurora.Engine.Elements.Abstractions;

namespace Aurora.Engine.Elements.Components.Item;

public class WeightComponent : IElementComponent
{
    public WeightComponent(string weightUnit = "lb.") // TODO: get default from engine configuration
    {
        WeightUnit = weightUnit;
    }

    /// <summary>
    /// Gets or sets the value of the weight.
    /// </summary>
    public decimal WeightValue { get; set; }

    /// <summary>
    /// Gets or sets the value of the unit in which the weight is displayed.
    /// </summary>
    public string WeightUnit { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether or not to ignore the weight in the weight calculations.
    /// </summary>
    public bool IsWeightIgnore { get; set; }
}
