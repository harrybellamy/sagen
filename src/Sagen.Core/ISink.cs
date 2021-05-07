using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sagen.Core
{
    public interface ISink
    {
        Task SaveDataAsync(IEnumerable<ApiResource> data);
    }
}