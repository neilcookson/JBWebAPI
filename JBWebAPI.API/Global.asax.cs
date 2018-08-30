using Autofac;
using Autofac.Integration.WebApi;
using JBWebAPI.API.Helpers;
using JBWebAPI.Data;
using JBWebAPI.Data.Interfaces;
using JBWebAPI.Data.Models;
using JBWebAPI.Data.Repositories;
using System.Reflection;
using System.Web.Http;

namespace JBWebAPI.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ProductRepository>().As<IProductRepository>().SingleInstance();
            builder.RegisterType<TestDataService>().As<IDataService>().SingleInstance();
            builder.RegisterType<ApiConfigurationSettings>().As<IConfigurationSettings>().SingleInstance();
            builder.RegisterType<FilterParser<Product>>().As<IFilterParser<Product>>().SingleInstance();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
