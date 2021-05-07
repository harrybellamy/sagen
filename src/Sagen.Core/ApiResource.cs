using System.Collections.Generic;

namespace Sagen.Core
{
    public class ApiResource
    {
        public ApiResource(string name, IEnumerable<ApiRecord> records)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new System.ArgumentException(
                    $"'{nameof(name)}' cannot be null or whitespace.", 
                    nameof(name));
            }

            Name = name;
            Records = records;
        }

        public string Name { get; }

        public IEnumerable<ApiRecord> Records { get; }
    }
}
