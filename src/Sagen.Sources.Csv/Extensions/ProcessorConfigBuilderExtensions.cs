using Sagen.Core.Config;

namespace Sagen.Sources.Csv.Extensions
{
    public static class ProcessorConfigBuilderExtensions
    {
        public static ProcessorConfigBuilder AddCsvSource(
            this ProcessorConfigBuilder processorConfigBuilder,
            string filePath,
            string resourceName,
            string identifierField)
        {
            var source = new CsvSource(filePath, resourceName, identifierField);

            processorConfigBuilder.Source = source;

            return processorConfigBuilder;
        }
    }
}
