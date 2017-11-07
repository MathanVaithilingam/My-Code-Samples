using System.Web.Http;
using System.Web.Http.Tracing;
using Unity;
using Unity.Lifetime;
using VechicleWebApp.Filters;
using VechicleWebApp.Helpers;
using VechicleWebApp.Resolver;
using VehiclesRepository.DataRepository;

namespace VehiclesWebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API dependency container configuration and services
            var container = new UnityContainer();
            container.RegisterType<IVehiclesDataRepository, VehiclesDataRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserDataRepository, UserDataRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITraceWriter, NLoggerHelper>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API Attribute routes
            config.MapHttpAttributeRoutes();

            // Web API Url routes
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "DefaultApi1",
               routeTemplate: "api/{controller}/{action}/{filterattribute}/{filterattributevalue}",
               defaults: new { filterattribute = RouteParameter.Optional, filterattributevalue = RouteParameter.Optional }
           );

            //Adding Formatters
            //config.Formatters.Add(new JsonDataFormatter());

            //Adding Filters
            config.Filters.Add(new CommonExceptionFilterAttribute());
            config.Filters.Add(new LoggingFilterAttribute());

        }
    }
}
