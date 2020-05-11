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
	[RoutePrefix("api/FixedAssetReports")]

	public class FixedAssetReportsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IFixedAssetReportsService _ReportsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type TransactionController.
		/// </summary>
		/// <param name="">The injected service.</param>
		public FixedAssetReportsController(IFixedAssetReportsService ReportsService)
		{
			this._ReportsService = ReportsService;
		}
		#endregion

		#region Actions                		

		[Route("get-fixed-assets-depreciation-report")]
		[HttpGet]		
		public IList<FixedAssetDepreciationReportViewModel> GetFixedAssetsDepreciationReport(DateTime? dateFrom, DateTime? dateTo)
		{
			var result = this._ReportsService.GetFixedAssetsDepreciationReport(dateFrom, dateTo);
			return result;
		}

		[Route("get-fixed-assets-location-report")]
		[HttpGet]
		public IList<FixedAssetLocationReportViewModel> GetFixedAssetsLocationReport(long? locationId, DateTime? dateFrom, DateTime? dateTo)
		{
			var result = this._ReportsService.GetFixedAssetsLocationReport(locationId, dateFrom, dateTo);
			return result;
		}

		[Route("get-fixed-assets-excluded-report")]
		[HttpGet]
		public IList<FixedAssetExcludedReportViewModel> GetFixedAssetsExcludedReport(DateTime? dateFrom, DateTime? dateTo)
		{
			var result = this._ReportsService.GetFixedAssetsExcludedReport(dateFrom, dateTo);
			return result;
		}

        [Route("get-fixed-assets-inventory-report")]
        [HttpGet]
        public IList<FixedAssetInventoryReportViewModel> GetFixedAssetsInventoryReport(long? locationId, DateTime? dateFrom, DateTime? dateTo)
        {
            var result = this._ReportsService.GetFixedAssetsInventoryReport(locationId, dateFrom, dateTo);
            return result;
        }

        [Route("get-fixed-assets-lost-report")]
        [HttpGet]
        public IList<FixedAssetLostReportViewModel> GetFixedAssetsLostReport(long? locationId, DateTime? dateFrom, DateTime? dateTo)
        {
            var result = this._ReportsService.GetFixedAssetsLostReport(locationId, dateFrom, dateTo);
            return result;
        }

        #endregion
    }
}