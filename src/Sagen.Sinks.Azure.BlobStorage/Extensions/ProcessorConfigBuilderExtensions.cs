using Sagen.Core.Config;

namespace Sagen.Sinks.Azure.BlobStorage.Extensions
{
    public static class ProcessorConfigBuilderExtensions
    {
        /// <summary>
        /// Adds a <see cref="AzureBlobStorageSink"/> to the config as the Sink.
        /// </summary>
        /// <param name="processorConfigBuilder">The config builder to add the sink to.</param>
        /// <param name="connectionString">The connection string for the Storage Account.</param>
        /// <param name="containerName">The name of the container to save the API data to.</param>
        /// <returns>The <see cref="ProcessorConfigBuilder"/>.</returns>
        public static ProcessorConfigBuilder AddAzureBlobStorageSink(
            this ProcessorConfigBuilder processorConfigBuilder,
            string connectionString,
            string containerName)
        {
            var sink = new AzureBlobStorageSink(connectionString, containerName);

            processorConfigBuilder.Sink = sink;

            return processorConfigBuilder;
        }
    }
}
