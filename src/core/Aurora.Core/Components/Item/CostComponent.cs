using Aurora.Engine.Abstractions;

namespace Aurora.Engine.Components.Item;

public class CostComponent : IElementComponent
{
    public CostComponent(string costCurrency = "gp") // TODO: get default from engine configuration
    {
        CostCurrency = costCurrency;
    }

    /// <summary>
    /// Gets or sets the value of the cost.
    /// </summary>
    public int Cost { get; set; }

    /// <summary>
    /// Gets or sets the currency in which the cost is displayed.
    /// </summary>
    public string CostCurrency { get; set; }
}