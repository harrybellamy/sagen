using Azure.Storage.Blobs;
using Newtonsoft.Json;
using Sagen.Core;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Sagen.Sinks.Azure.BlobStorage
{
    /// <summary>
    /// Sink to save API data to an Azure Blob Storage container.
    /// </summary>
    public class AzureBlobStorageSink : ISink
    {
        private readonly string connectionString;
        private readonly string containerName;

        public AzureBlobStorageSink(string connectionString, string containerName)
        {
            this.connectionString = connectionString;
            this.containerName = containerName;
        }

        /// <summary>
        /// Save the <see cref="ApiResource"/> instances to the Blob Storage container.
        /// </summary>
        /// <param name="data">The data to save.</param>
        /// <returns>An awaitable task.</returns>
        public async Task SaveDataAsync(IEnumerable<ApiResource> data)
        {
            var blobContainerClient = GetBlobContainerClient();
            
            foreach (var resource in data)
            {
                await SaveResourceAsync(resource, blobContainerClient);
            }
        }

        private async Task SaveResourceAsync(
            ApiResource resource, 
            BlobContainerClient blobContainerClient)
        {
            foreach (var item in resource.Records)
            {
                string filePath = FormatPath(resource, item);

                var blobClient = blobContainerClient.GetBlobClient(filePath);

                var json = JsonConvert.SerializeObject(item.Data);
                using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

                await blobClient.UploadAsync(ms);
            }
        }

        private string FormatPath(ApiResource resource, ApiRecord record) 
            => $"{resource.Name}/{record.Identifier}/data.json";

        private BlobContainerClient GetBlobContainerClient() 
            => new BlobContainerClient(connectionString, containerName);
    }
}
