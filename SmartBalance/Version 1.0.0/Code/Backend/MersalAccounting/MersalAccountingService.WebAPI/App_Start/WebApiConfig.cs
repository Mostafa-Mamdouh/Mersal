#region Using ...
using Newtonsoft.Json.Serialization;
using MersalAccountingService.WebAPI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using Framework.Core.Common;
using MersalAccountingService.DependancyInjection.App_Start;
using MersalAccountingService.Core.Common;
using Newtonsoft.Json.Converters;
#endregion

namespace MersalAccountingService.WebAPI
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();

			#region Set JsonMediaTypeFormatter As a Default Formatter
			JsonMediaTypeFormatter json = new JsonMediaTypeFormatter();

			json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
			json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
			json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
			json.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
			json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-ddTHH:mmZ" });

            config.Formatters.Clear();
			config.Formatters.Add(json);
			#endregion

			#region Register Http Filters
			//config.Filters.Add(new AuthenticationFilter(SimpleInjectorWebApiInitializer.Resolve<ICurrentUserService>()));
			config.Filters.Add(new ExceptionHandlingAttribute(SimpleInjectorWebApiInitializer.Resolve<ILoggerService>()));
			#endregion

			#region EnableCors
			EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
			config.EnableCors(cors);
			#endregion

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{action}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
