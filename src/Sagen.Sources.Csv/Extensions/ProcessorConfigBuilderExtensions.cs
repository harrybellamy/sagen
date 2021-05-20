using Sagen.Core.Config;

namespace Sagen.Sources.Csv.Extensions
{
    public static class ProcessorConfigBuilderExtensions
    {
        /// <summary>
        /// Adds a <see cref="CsvSource"/> to the config as the Sink.
        /// </summary>
        /// <param name="processorConfigBuilder">The config builder to add the sink to.</param>
        /// <param name="filePath">Path to the CSV file.</param>
        /// <param name="resourceName">The name of the resource to be saved.</param>
        /// <param name="identifierField">The name of the field to use as the identifier.</param>
        /// <returns>The <see cref="ProcessorConfigBuilder"/>.</returns>
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
