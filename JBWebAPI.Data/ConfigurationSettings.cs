using JBWebAPI.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBWebAPI.Data
{
    class ConfigurationSettings : IConfigurationSettings
    {
        public string ConnectionString => Path.Combine(Directory.GetCurrentDirectory(), "test.json");
    }
}
