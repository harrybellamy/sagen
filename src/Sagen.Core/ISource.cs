using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sagen.Core
{
    public interface ISource
    {
        /// <summary>
        /// Get data from the source.
        /// </summary>
        /// <returns>The data from the source.</returns>
        Task<IEnumerable<ApiResource>> GetDataAsync();
    }
}