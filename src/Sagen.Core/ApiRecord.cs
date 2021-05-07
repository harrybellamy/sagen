namespace Sagen.Core
{
    public class ApiRecord
    {
        public ApiRecord(string identifier, dynamic data)
        {
            Identifier = identifier;
            Data = data;
        }

        public string Identifier { get; }

        public dynamic Data { get; }
    }
}
