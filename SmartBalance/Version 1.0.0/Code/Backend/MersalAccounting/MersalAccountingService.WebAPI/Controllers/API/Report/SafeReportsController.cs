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
    [RoutePrefix("api/SafeReports")]
    public class SafeReportsController : Base.BaseAPIController
    {
        #region Data Members
        private readonly ISafeReportsService _ReportsService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type TransactionController.
        /// </summary>
        /// <param name="TransactionsService">The injected service.</param>
        public SafeReportsController(ISafeReportsService ReportsService)
        {
            this._ReportsService = ReportsService;
        }
        #endregion

        #region Actions                

        [Route("get-Safe-report/{SafeId}")]
        [HttpGet]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SafeReport/get-Safe-report/{SafeId}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SafeReport/get-Safe-report/1
		 */
        public IList<SafeReportViewModel> GetVendorAccountReport(long? SafeId, DateTime? DateFrom, DateTime? DateTo)
        {
            var result = this._ReportsService.GetSafeReport(SafeId.Value, DateFrom, DateTo);
            return result;
        }

        [Route("get-Safe-balance-report/{SafeId}")]
        [HttpGet]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SafeReport/get-Safe-balance-report/{SafeId}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SafeReport/get-Safe-balance-report/1
		 */
        public IList<SafeReportViewModel> GetSafeBalanceReport(long? SafeId, DateTime? DateFrom, DateTime? DateTo)
        {
            var result = this._ReportsService.GetSafeBalanceReport(SafeId.Value, DateFrom, DateTo);
            return result;
        }


        //     [Route("get-vendor-account-report-before-date")]
        //     [HttpGet]
        //     /*
        //* HttpVerb: POST
        //* URL Pattern: http[s]://IPAddress:PortNumber/api/SafeReport/get-AccountsReport
        //* Usage: http://localhost/MersalAccountingService.WebAPI/api/SafeReport/get-vendor-report-before-date
        //*/
        //     public IList<AccountsReportViewModel> GetVendorReportBeforeDate(long vendorId, DateTime DateFrom)
        //     {
        //         var result = this._ReportsService.GetVendorReportBeforeDate(vendorId, DateFrom);
        //         return result;
        //     }
        #endregion
    }
}