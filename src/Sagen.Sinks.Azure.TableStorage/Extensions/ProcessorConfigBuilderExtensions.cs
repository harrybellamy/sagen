using Sagen.Core.Config;

namespace Sagen.Sinks.Azure.TableStorage.Extensions
{
    public static class ProcessorConfigBuilderExtensions
    {
        public static ProcessorConfigBuilder AddAzureTableStorageSink(
            this ProcessorConfigBuilder processorConfigBuilder,
            string connectionString,
            string containerName)
        {
            var sink = new AzureTableStorageSink(connectionString, containerName);

            processorConfigBuilder.Sink = sink;

            return processorConfigBuilder;
        }
    }
}
