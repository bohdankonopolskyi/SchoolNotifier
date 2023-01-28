using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace SchoolNotifier.FileReader.JSON
{
    public class JSONSerializer<T>
    {
        private T _data;

        public T Data
        {
            get { return _data; }   
            set { _data = value; }  
        }

        public JSONSerializer(T data)
        {
            _data = data;
        }

        public async Task Serialize(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (_data != null)
                {
                    await JsonSerializer.SerializeAsync(fs, _data);
                }
            }
        }

        public async Task<T> Deserialize(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (_data != null)
                {
                    _data = await JsonSerializer.DeserializeAsync<T>(fs);
                }
            }

            return _data;
        }
    }
}
