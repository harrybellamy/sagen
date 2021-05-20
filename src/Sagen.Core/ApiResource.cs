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

        /// <summary>
        /// The records under this resource.
        /// </summary>
        public IEnumerable<ApiRecord> Records { get; }
    }
}
