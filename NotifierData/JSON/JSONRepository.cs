using System.Text.Json;

namespace NotifierData.JSON
{
    public class JSONRepository<T> : ISerializer<T> where T : class
    {
        private T _data;
        private static JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true,
            AllowTrailingCommas = true

        };
        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public JSONRepository()
        {

        }

        public JSONRepository(T data)
        {
            _data = data;
        }

        public async Task SerializeAsync(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (_data != null)
                {
                    await JsonSerializer.SerializeAsync(fs, _data, _options);
                }
            }
        }

        public async Task<T>DeserializeAsync(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                _data = await JsonSerializer.DeserializeAsync<T>(fs);
            }

            return _data;
        }
    }
}
