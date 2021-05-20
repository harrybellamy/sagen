using Sagen.Core.Config;
using System.Threading.Tasks;

namespace Sagen.Core
{
    public class Processor
    {
        /// <summary>
        /// Process the data from the source and save to the sink.
        /// </summary>
        /// <param name="config">The source and sink configuration.</param>
        /// <returns>An awaitable task.</returns>
        public async Task ProcessAsync(ProcessorConfig config)
        {
            var data = await config.Source.GetDataAsync();
            await config.Sink.SaveDataAsync(data);
        }
    }
}
