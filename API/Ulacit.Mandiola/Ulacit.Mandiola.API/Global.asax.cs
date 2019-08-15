using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json.Serialization;
using Ulacit.Mandiola.IoC.Abstract;
using Ulacit.Mandiola.IoC.Concrete;
using WebApi.StructureMap;

namespace Ulacit.Mandiola.API
{
    /// <summary>A web API application.</summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>Application start.</summary>
        protected void Application_Start()
        {
            var container = StructureMapBootstrapper.Bootstrap("Ulacit.*");
            var iMapper = AutoMapperBoostrapper.Bootstrap("Ulacit.*");
            var dependencyRegister = container.GetInstance<IDependencyRegister>();
            dependencyRegister.Register(iMapper);
            GlobalConfiguration.Configuration.UseStructureMap(container);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}