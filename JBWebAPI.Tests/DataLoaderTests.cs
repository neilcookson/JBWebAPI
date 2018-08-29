using JBWebAPI.Data;
using JBWebAPI.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class DataLoaderTests
    {
        [TestMethod]
        public void LoadJsonData_ReturnsValidData_FileExists()
        {
            var filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "JBWebAPI.Data", "test-data.json");
            var result = DataLoader.LoadTestDataAsync(filePath).GetAwaiter().GetResult();
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(DataLoaderResult), result.GetType());
        }
    }
}
