#region Using ...
using Framework.Common.Exceptions.Base;
using MersalAccountingService.DependancyInjection.App_Start;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing; 
#endregion

namespace MersalAccountingService.WebAPI
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			MersalAccountingService.Core.AutoMapperConfig.Configuration.Initialize();
			SimpleInjectorWebApiInitializer.Initialize(GlobalConfiguration.Configuration);

			
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);


			#region Update Database Here
			var configuration = SimpleInjectorWebApiInitializer.Resolve<DbMigrationsConfiguration>();
			DbMigrator dbMigrator = new DbMigrator(configuration);
			dbMigrator.Update(null); 
			#endregion
		}

        //protected void Application_Error()
        //{
        //    var exception = Server.GetLastError();
        //    if (exception is BaseException)
        //    {
        //        var baseException = (BaseException)exception;
        //        Response.StatusCode = baseException.ErrorCode;
        //    }
        //}

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public static string ApplicationName
		{
			get { return "MersalAccounting"; }
		}
		#endregion
	}
}
