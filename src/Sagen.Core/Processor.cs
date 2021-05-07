using Sagen.Core.Config;
using System.Threading.Tasks;

namespace Sagen.Core
{
    public class Processor
    {
        public async Task ProcessAsync(ProcessorConfig config)
        {
            var data = await config.Source.GetDataAsync();
            await config.Sink.SaveDataAsync(data);
        }
    }
}
