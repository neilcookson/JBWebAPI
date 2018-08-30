using JBWebAPI.Data.Interfaces;
using JBWebAPI.Data.Models;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace JBWebAPI.Data
{
    public class TestDataService : IDataService
    {
        public async Task<T> LoadDataAsync<T> (IConfigurationSettings configSettings)
        {
            using (StreamReader reader = new StreamReader(configSettings.ConnectionString))
            {
                var stringResult = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<T>(stringResult);
            }
        }
    }
}
