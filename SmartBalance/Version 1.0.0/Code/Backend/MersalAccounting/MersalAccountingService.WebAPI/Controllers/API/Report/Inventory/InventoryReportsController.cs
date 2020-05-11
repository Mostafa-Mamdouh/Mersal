#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Core.Models.ViewModels.Reports;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
#endregion

namespace MersalAccountingService.WebAPI.Controllers.API
{
	[RoutePrefix("api/InventoryReports")]

	public class InventoryReportsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IInventoryReportsService _ReportsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type TransactionController.
		/// </summary>
		/// <param name="">The injected service.</param>
		public InventoryReportsController(IInventoryReportsService ReportsService)
		{
			this._ReportsService = ReportsService;
		}
		#endregion

		#region Actions                		

		[Route("get-inventory-balance-report/{inventoryId}")]
		[HttpGet]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryReports/get-inventory-balance-report/{inventoryId}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryReports/get-inventory-balance-report/1
		 */
		public IList<InventoryBalanceReportViewModel> GetInventoryBalanceReport(long? inventoryId, DateTime? dateFrom, DateTime? dateTo)
		{
			var result = this._ReportsService.GetInventoryBalanceReport(inventoryId.Value, dateFrom, dateTo);
			return result;
		}
		
		#endregion
	}
}