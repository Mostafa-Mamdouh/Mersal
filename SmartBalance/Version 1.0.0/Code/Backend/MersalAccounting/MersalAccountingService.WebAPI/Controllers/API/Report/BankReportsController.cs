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
	[RoutePrefix("api/BankReports")]
	public class BankReportsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IBankReportsService _ReportsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type TransactionController.
		/// </summary>
		/// <param name="TransactionsService">The injected service.</param>
		public BankReportsController(IBankReportsService ReportsService)
		{
			this._ReportsService = ReportsService;
		}
		#endregion

		#region Actions                

		[Route("get-bank-account-report/{bankId}")]
		[HttpGet]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankAccountReport/get-bank-account-report/{bankId}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankAccountReport/get-bank-account-report/1
		 */
		public IList<BankAccountReportViewModel> GetBankAccountReport(long? bankId, DateTime? DateFrom, DateTime? DateTo)
		{
			var result = this._ReportsService.GetBankAccountReport(bankId.Value, DateFrom, DateTo);
			return result;
		}

        [Route("get-bank-balance-report/{bankId}")]
        [HttpGet]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankAccountReport/get-bank-balance-report/{bankId}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankAccountReport/get-bank-balance-report/1
		 */
        public IList<BankAccountReportViewModel> GetBankBalanceReport(long? bankId, DateTime? DateFrom, DateTime? DateTo)
        {
            var result = this._ReportsService.GetBankBalanceReport(bankId.Value, DateFrom, DateTo);
            return result;
        }

        //     [Route("get-bank-account-report-before-date")]
        //     [HttpGet]
        //     /*
        //* HttpVerb: POST
        //* URL Pattern: http[s]://IPAddress:PortNumber/api/BankAccountReport/get-AccountsReport
        //* Usage: http://localhost/MersalAccountingService.WebAPI/api/BankAccountReport/get-bank-report-before-date
        //*/
        //     public IList<AccountsReportViewModel> GetBankReportBeforeDate(long bankId, DateTime DateFrom)
        //     {
        //         var result = this._ReportsService.GetBankReportBeforeDate(bankId, DateFrom);
        //         return result;
        //     }
        #endregion
    }
}