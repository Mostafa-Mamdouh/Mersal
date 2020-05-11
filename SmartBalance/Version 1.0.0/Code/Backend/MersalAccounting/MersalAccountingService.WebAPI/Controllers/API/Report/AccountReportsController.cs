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

namespace MersalAccountingService.WebAPI.Controllers.API.Report
{
    [RoutePrefix("api/AccountReports")]
    public class AccountReportsController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IAccountReportsService _ReportsService;
        #endregion

        #region Constructors

        /// <param name="ReportsService">The injected service.</param>
        public AccountReportsController(IAccountReportsService ReportsService)
        {
            this._ReportsService = ReportsService;
        }
        #endregion

        #region Actions
        [Route("get-accounts-report/{AccountChartId}")]
        [HttpGet]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountReport/get-accounts-report
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountReport/get-accounts-report
		 */
        public IList<AccountsReportViewModel> GetByFilter(long AccountChartId, long? currencyId, DateTime? DateFrom, DateTime? DateTo)
        {
            var result = this._ReportsService.GetAccountsReport(AccountChartId, currencyId, DateFrom, DateTo);
            return result;
        }

        [Route("get-accounts-balance-report/{AccountChartId}")]
        [HttpGet]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountReport/get-accounts-balance-report
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountReport/get-accounts-balance-report
		 */
        public IList<AccountsReportViewModel> GetAccountBalanceReport(long AccountChartId, long? currencyId, DateTime? DateFrom, DateTime? DateTo)
        {
            var result = this._ReportsService.GetAccountBalanceReport(AccountChartId, currencyId, DateFrom, DateTo);
            return result;
        }


        [Route("get-balance-sheet-report/{level}")]
        [HttpGet]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountReport/get-balance-sheet-report/{level}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountReport/get-balance-sheet-report/1
		 */
        public IList<BalanceSheetReportViewModel> GetByFilter(int level, DateTime? DateFrom, DateTime? DateTo)
        {
            var result = this._ReportsService.GetBalanceSheetReport(level, DateFrom, DateTo);
            return result;
        }




   //     [Route("get-AccReport-before-date")]
   //     [HttpGet]
   //     /*
		 //* HttpVerb: POST
		 //* URL Pattern: http[s]://IPAddress:PortNumber/api/AccountReport/get-AccReport-before-date
		 //* Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountReport/get-AccReport-before-date
		 //*/
   //     public IList<AccountsReportViewModel> GetAccReportBeforeDate(long AccountChartId, long? currencyId, DateTime DateFrom)
   //     {
   //         var result = this._ReportsService.GetAccReportBeforeDate(AccountChartId, currencyId, DateFrom);
   //         return result;
   //     }
        #endregion
    }
}
