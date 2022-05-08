using Aurora.Engine.Data.Models;

namespace Aurora.Engine.Data.Interfaces
{
    public interface IEquipmentDataProvider
    {
        /// <summary>
        /// Gets an element by providing the identifier.
        /// </summary>
        /// <param name="identifier">The unique identifier for the element.</param>
        /// <returns>The element that has the specified identifier.</returns>
        ElementModel GetElementModel(string identifier);

        /// <summary>
        /// Gets a collection of elements of the 'Item' type.
        /// </summary>
        IEnumerable<ElementModel> GetItems();

        /// <summary>
        /// Gets a collection of elements of the 'Weapon' type.
        /// </summary>
        IEnumerable<ElementModel> GetWeapons();

        /// <summary>
        /// Gets a collection of elements of the 'Armor' type.
        /// </summary>
        IEnumerable<ElementModel> GetArmor();

        /// <summary>
        /// Gets a collection of elements of the 'Magic Item' type.
        /// </summary>
        IEnumerable<ElementModel> GetMagicItems();
    }
}
