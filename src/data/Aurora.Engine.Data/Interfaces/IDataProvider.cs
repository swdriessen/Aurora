using Aurora.Engine.Data.Models;

namespace Aurora.Engine.Data.Interfaces
{
    public interface IDataProvider
    {
        /// <summary>
        /// Gets a list of elements loaded by this data provider.
        /// </summary>
        /// <returns>A list of elements.</returns>
        List<ElementModel> GetElements();

        /// <summary>
        /// Gets a list of elements of a certain type loaded by this data provider.
        /// </summary>
        /// <param name="type">The type of the elements.</param>
        /// <returns>A list of elements of the provided type.</returns>
        List<ElementModel> GetElements(string type);
    }
}
