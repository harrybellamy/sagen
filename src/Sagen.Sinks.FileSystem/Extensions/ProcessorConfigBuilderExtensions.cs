using Sagen.Core.Config;

namespace Sagen.Sinks.FileSystem.Extensions
{
    public static class ProcessorConfigBuilderExtensions
    {
        /// <summary>
        /// Adds a <see cref="FileSystemSink"/> to the config as the Sink.
        /// </summary>
        /// <param name="processorConfigBuilder">The config builder to add the sink to.</param>
        /// <param name="apiRoot">Path to the folder where the files are saved to.</param>
        /// <returns>The <see cref="ProcessorConfigBuilder"/>.</returns>
        public static ProcessorConfigBuilder AddFileSink(
            this ProcessorConfigBuilder processorConfigBuilder,
            string apiRoot)
        {
            var sink = new FileSystemSink(apiRoot);

            processorConfigBuilder.Sink = sink;

            return processorConfigBuilder;
        }
    }
}
