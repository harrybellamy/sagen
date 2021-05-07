using Newtonsoft.Json;
using Sagen.Core;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Sagen.Sinks.FileSystem
{
    public class FileSystemSink : ISink
    {
        private readonly string apiRoot;

        public FileSystemSink(string apiRoot)
        {
            this.apiRoot = apiRoot;
        }

        public async Task SaveDataAsync(IEnumerable<ApiResource> data)
        {
            foreach (var resource in data)
            {
                await SaveResourceAsync(resource);
            }
        }

        private async Task SaveResourceAsync(ApiResource resource)
        {
            foreach (var item in resource.Records)
            {
                var json = JsonConvert.SerializeObject(item.Data);
                var filePath = FormatPath(resource, item);

                Directory.CreateDirectory(Path.GetDirectoryName(filePath));          

                await File.WriteAllTextAsync(filePath, json);
            }
        }

        private string FormatPath(ApiResource resource, ApiRecord record) 
            => $"{apiRoot}/{resource.Name}/{record.Identifier}/data.json";
    }
}
