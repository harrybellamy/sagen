using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sagen.Core
{
    public interface ISource
    {
        Task<IEnumerable<ApiResource>> GetDataAsync();
    }
}