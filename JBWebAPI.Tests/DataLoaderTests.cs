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
            var dataLoader = new TestDataLoader();
            var config = new TestConfigurationSettings();

            var result = dataLoader.LoadDataAsync<DataLoaderResult>(config).GetAwaiter().GetResult();

            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(DataLoaderResult), result.GetType());
        }
    }
}
