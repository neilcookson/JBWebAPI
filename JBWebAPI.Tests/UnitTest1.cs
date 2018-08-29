using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JBWebAPI.Data;
using System.Threading.Tasks;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class DataLoaderTests
    {
        [TestMethod]
        public void LoadJsonData_ReturnsString_FileExists()
        {
            var filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "JBWebAPI.Data", "test-data.json");
            var stringResult = Task.FromResult(DataLoader.ReadJsonDataAsync(filePath));
        }
    }
}
