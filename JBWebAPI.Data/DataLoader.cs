using System.IO;
using System.Threading.Tasks;

namespace JBWebAPI.Data
{
    public static class DataLoader
    {
        public static async Task<string> ReadJsonDataAsync(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
