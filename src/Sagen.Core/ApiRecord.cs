namespace Sagen.Core
{
    /// <summary>
    /// A record under an <see cref="ApiResource"/>.
    /// </summary>
    public class ApiRecord
    {
        public ApiRecord(string identifier, dynamic data)
        {
            Identifier = identifier;
            Data = data;
        }

        /// <summary>
        /// The identifier to retrieve this resource.
        /// </summary>
        public string Identifier { get; }

        /// <summary>
        /// The data contained within the record.
        /// </summary>
        public dynamic Data { get; }
    }
}
