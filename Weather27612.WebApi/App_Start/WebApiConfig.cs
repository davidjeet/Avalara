using System.Web.Http;
using Unity;
using Weather27612.Core;
using Weather27612.Core.Excel;

namespace Weather27612.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IWeatherEngine, WeatherEngine>();
            container.RegisterType<IExcelClient, ExcelFileClient>();
            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
