using JBWebAPI.Data.Interfaces;
using System.IO;

namespace JBWebAPI.API
{
    class ApiConfigurationSettings : IConfigurationSettings
    {
        public string ConnectionString => Path.Combine(
            Directory.GetParent(System.Web.Hosting.HostingEnvironment.MapPath("~")).Parent.FullName,
            "JBWebAPI.Data",
            "test-data.json");
    }
}
