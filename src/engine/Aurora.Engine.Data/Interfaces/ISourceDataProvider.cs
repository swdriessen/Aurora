using Aurora.Engine.Data.Models;

namespace Aurora.Engine.Data.Interfaces
{
    public interface ISourceDataProvider
    {
        /// <summary>
        /// Gets a collection of elements of the 'Source' type.
        /// </summary>
        IEnumerable<ElementModel> GetSources();
    }
}
