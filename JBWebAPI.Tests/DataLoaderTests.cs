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
        public void LoadData_ReturnsValidData_FileExists()
        {
            var dataLoader = new TestDataService();
            var config = new TestConfigurationSettings();

            var result = dataLoader.LoadData<DataLoaderResult>(config);

            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(DataLoaderResult), result.GetType());
        }
    }
}
