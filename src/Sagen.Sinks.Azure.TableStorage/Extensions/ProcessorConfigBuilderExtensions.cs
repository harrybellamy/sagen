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
            var source = new AzureTableStorageSink(connectionString, containerName);

            processorConfigBuilder.Source = source;

            return processorConfigBuilder;
        }
    }
}
