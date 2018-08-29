using JBWebAPI.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    class TestConfigurationSettings : IConfigurationSettings
    {
        public string ConnectionString => Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "JBWebAPI.Data", "test-data.json");
    }
}
