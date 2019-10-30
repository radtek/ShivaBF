using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SHF.Helper;

namespace SHF
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            //ConfigureViewEngines();

            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BusMapper.RegisterMapper();
            SHF.Business.busCache.LoadCache();

            var jsonFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            var jSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateTimeZoneHandling = DateTimeZoneHandling.Local
            };
            jSettings.Converters.Add(new MyDateTimeConvertor());
            jsonFormatter.SerializerSettings = jSettings;

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }

        protected void Session_End()
        {

        }
        public class MyDateTimeConvertor : DateTimeConverterBase
        {
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                return reader.Value != null ? DateTime.Parse(reader.Value.ToString()) : reader.Value;
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                //writer.WriteValue(((DateTime)value).ToString("MM/dd/yyyy hh:mm:ss tt"));
                writer.WriteValue(((DateTime)value).ToString("MM/dd/yyyy hh:mm tt")); //Removed Seconds
            }
        }

        /// <summary>
        /// Configures the view engines. By default, Asp.Net MVC includes the Web Forms (WebFormsViewEngine) and 
        /// Razor (RazorViewEngine) view engines. You can remove view engines you are not using here for better
        /// performance.
        /// </summary>
        private static void ConfigureViewEngines()
        {
            // Only use the RazorViewEngine.
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}
