using NotifierData.Models;
using System.Text.Json;

namespace NotifierData.JSON
{
    public class JSONRepository : IJSONRepository<List<Notification>>
    {
        private List<Notification> _data;
        private string _fileName;
        private static JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true,
            AllowTrailingCommas = true

        };
        public List<Notification> Data
        {
            get {
                if (_data == null)
                {
                    _data = new List<Notification>();
                    return Deserialize();
                }
                return _data; 
            }
            set { _data = value; }
        }

        public JSONRepository(string file)
        {
            _fileName = file;
        }

        public JSONRepository(List<Notification> data)
        {
            _data = data;
        }

        public async Task SerializeAsync()
        {
            using (FileStream fs = new FileStream(_fileName, FileMode.OpenOrCreate))
            {
                if (_data != null)
                {
                    await JsonSerializer.SerializeAsync(fs, _data, _options);
                }
            }
        }

        public async Task<List<Notification>> DeserializeAsync()
        {
            using (FileStream fs = new FileStream(_fileName, FileMode.OpenOrCreate))
            {
                _data = await JsonSerializer.DeserializeAsync<List<Notification>>(fs);
            }

            return _data;
        }

        public  List<Notification> Deserialize()
        {
            using (FileStream fs = new FileStream(_fileName, FileMode.OpenOrCreate))
            {
                _data =  JsonSerializer.Deserialize<List<Notification>>(fs);
            }

            return _data;
        }
    }
}
