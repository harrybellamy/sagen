using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sagen.Core
{
    /// <summary>
    /// A sink for API data.
    /// </summary>
    public interface ISink
    {
        /// <summary>
        /// Save the <see cref="ApiResource"/> instances as an API.
        /// </summary>
        /// <param name="data">The data to save.</param>
        /// <returns>An awaitable task.</returns>
        Task SaveDataAsync(IEnumerable<ApiResource> data);
    }
}