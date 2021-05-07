using CsvHelper;
using CsvHelper.Configuration;
using Sagen.Core;
using Sagen.Sources.Csv.Helpers;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sagen.Sources.Csv
{
    public class CsvSource : ISource
    {
        private readonly string filePath;
        private readonly string resourceName;
        private readonly string identifierField;

        public CsvSource(string filePath, string resourceName, string identifierField)
        {
            this.filePath = filePath;
            this.resourceName = resourceName;
            this.identifierField = identifierField;
        }

        public async Task<IEnumerable<ApiResource>> GetDataAsync()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture);

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, config);

            List<dynamic> records = new List<dynamic>();

            await foreach (var item in csv.GetRecordsAsync<dynamic>())
            {
                records.Add(item);
            }
            
            var resourceRecords = GetRecords(records);

            var apiResource = new ApiResource(resourceName, resourceRecords);

            return new[]
            {
                apiResource
            }; 
        }

        private IEnumerable<ApiRecord> GetRecords(IEnumerable<dynamic> csvRecords) => csvRecords
            .Select(s =>
            {
                var uid = DynamicHelpers.GetPropertyValueAs<string>(s, identifierField);
                return new ApiRecord(uid, s);
            });
    }
}
