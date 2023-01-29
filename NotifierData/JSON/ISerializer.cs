using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifierData.JSON
{
    public interface ISerializer<T> where T : class
    {
        public T Data { get; set; }
        public Task SerializeAsync(string fileName);
        public Task<T> DeserializeAsync(string fileName);
    }
}
