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
    [RoutePrefix("api/VendorReports")]
    public class VendorReportsController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IVendorReportsService _ReportsService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type TransactionController.
        /// </summary>
        /// <param name="TransactionsService">The injected service.</param>
        public VendorReportsController(IVendorReportsService ReportsService)
        {
            this._ReportsService = ReportsService;
        }
        #endregion

        #region Actions                

        [Route("get-vendor-account-report/{vendorId}")]
        [HttpGet]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/VendorAccountReport/get-vendor-account-report/{vendorId}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/VendorAccountReport/get-vendor-account-report/1
		 */
        public IList<VendorAccountReportViewModel> GetVendorAccountReport(long? vendorId, DateTime? DateFrom, DateTime? DateTo)
        {
            var result = this._ReportsService.GetVendorAccountReport(vendorId.Value, DateFrom, DateTo);
            return result;
        }

        [Route("get-vendor-balance-report/{vendorId}")]
        [HttpGet]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/VendorAccountReport/get-vendor-balance-report/{vendorId}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/VendorAccountReport/get-vendor-balance-report/1
		 */
        public IList<VendorAccountReportViewModel> GetVendorBalanceReport(long? vendorId, DateTime? DateFrom, DateTime? DateTo)
        {
            var result = this._ReportsService.GetVendorBalanceReport(vendorId.Value, DateFrom, DateTo);
            return result;
        }


        //     [Route("get-vendor-account-report-before-date")]
        //     [HttpGet]
        //     /*
        //* HttpVerb: POST
        //* URL Pattern: http[s]://IPAddress:PortNumber/api/VendorAccountReport/get-AccountsReport
        //* Usage: http://localhost/MersalAccountingService.WebAPI/api/VendorAccountReport/get-vendor-report-before-date
        //*/
        //     public IList<AccountsReportViewModel> GetVendorReportBeforeDate(long vendorId, DateTime DateFrom)
        //     {
        //         var result = this._ReportsService.GetVendorReportBeforeDate(vendorId, DateFrom);
        //         return result;
        //     }
        #endregion
    }
}