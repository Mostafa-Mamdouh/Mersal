#region Using ...
using System.Web;
using System.Web.Mvc; 
#endregion

namespace MersalAccountingService.WebAPI
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
