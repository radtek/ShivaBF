using Newtonsoft.Json.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using SHF.Web.Filters;

namespace SHF
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
          
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();

            // Switch from PascalCase to CamelCase
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
