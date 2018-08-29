using JBWebAPI.Data.Models;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace JBWebAPI.Data
{
    public static class DataLoader
    {
        public static async Task<DataLoaderResult> LoadTestDataAsync (string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                var stringResult = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<DataLoaderResult>(stringResult);
            }
        }
    }
}
