using Sagen.Core.Config;

namespace Sagen.Sinks.Azure.BlobStorage.Extensions
{
    public static class ProcessorConfigBuilderExtensions
    {
        public static ProcessorConfigBuilder AddAzureblobstorageSink(
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
