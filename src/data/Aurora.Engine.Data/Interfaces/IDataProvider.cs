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
    }
}
