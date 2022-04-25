using Aurora.Engine.Data.Models;

namespace Aurora.Engine.Equipment.Interfaces
{
    public interface IEquipmentDataProvider
    {
        /// <summary>
        /// Gets an element by providing the identifier.
        /// </summary>
        /// <param name="identifier">The unique identifier for the element.</param>
        /// <returns>The element that has the specified identifier.</returns>
        ElementModel GetElementModel(string identifier);
    }
}