using JBWebAPI.Data.Interfaces;
using JBWebAPI.Data.Models;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace JBWebAPI.Data
{
    public class TestDataService : IDataService
    {
        public T LoadData<T> (IConfigurationSettings configSettings)
        {
            using (StreamReader reader = new StreamReader(configSettings.ConnectionString))
            {
                var stringResult = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(stringResult);
            }
        }
    }
}
