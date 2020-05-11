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
    [RoutePrefix("api/CostCenterReports")]
    public class CostCenterReportsController : Base.BaseAPIController
    {
        #region Data Members
        private readonly ICostCenterReportsService _ReportsService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type TransactionController.
        /// </summary>
        /// <param name="TransactionsService">The injected service.</param>
        public CostCenterReportsController(ICostCenterReportsService ReportsService)
        {
            this._ReportsService = ReportsService;
        }
        #endregion

        #region Actions                

        [Route("get-cost-center-account-report/{costCenterId}")]
        [HttpGet]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenterReports/get-cost-center-account-report/{costCenterId}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenterReports/get-Cost-center-account-report/1
		 */
        public IList<CostCenterAccountReportViewModel> GetCostCenterAccountReport(long? costCenterId, DateTime? DateFrom, DateTime? DateTo)
        {
            var result = this._ReportsService.GetCostCenterAccountReport(costCenterId.Value, DateFrom, DateTo);
            return result;
        }

        [Route("get-cost-center-balance-report/{costCenterId}")]
        [HttpGet]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenterReports/get-cost-center-balance-report/{costCenterId}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenterReports/get-cost-center-balance-report/1
		 */
        public IList<CostCenterAccountReportViewModel> GetCostCenterBalanceReport(long? costCenterId, DateTime? DateFrom, DateTime? DateTo)
        {
            var result = this._ReportsService.GetCostCenterBalanceReport(costCenterId.Value, DateFrom, DateTo);
            return result;
        }

        //     [Route("get-cost-center-account-report-before-date")]
        //     [HttpGet]
        //     /*
        //* HttpVerb: POST
        //* URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenterReports/get-AccountsReport
        //* Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenterReports/get-cost-center-report-before-date
        //*/
        //     public IList<AccountsReportViewModel> GetCostCenterReportBeforeDate(long costCenterId, DateTime DateFrom)
        //     {
        //         var result = this._ReportsService.GetCostCenterReportBeforeDate(costCenterId, DateFrom);
        //         return result;
        //     }
        #endregion
    }
}
