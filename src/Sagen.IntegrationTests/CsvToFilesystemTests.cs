using Sagen.Core;
using Sagen.Core.Config;
using Sagen.Sinks.FileSystem.Extensions;
using Sagen.Sources.Csv.Extensions;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Sagen.IntegrationTests
{
    public class CsvToFilesystemTests
    {
        [Fact]
        public async Task CsvToFilesystem_Test()
        {
            var folderPath = @".\Output";

            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
            }

            var configBuilder = new ProcessorConfigBuilder();
            configBuilder
                .AddCsvSource(@"./TestData/TestData.csv", "Cars", "Id")
                .AddFileSink(@"./Output");

            var config = configBuilder.Build();

            var processor = new Processor();
            await processor.ProcessAsync(config);

            Assert.True(File.Exists(@"./Output/Cars/1/data.json"));
            Assert.True(File.Exists(@"./Output/Cars/2/data.json"));
            Assert.True(File.Exists(@"./Output/Cars/3/data.json"));
        }
    }
}
