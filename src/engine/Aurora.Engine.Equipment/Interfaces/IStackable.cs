namespace Aurora.Engine.Equipment.Interfaces
{
    public interface IStackable
    {
        /// <summary>
        /// Gets or sets a value indicating wether multiple quantities of the same item can be stacked.
        /// </summary>
        bool IsStackable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the item quantity.
        /// </summary>
        int Quantity { get; set; }
    }
}