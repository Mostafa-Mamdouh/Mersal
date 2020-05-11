#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Core.Models.ViewModels.Reports;
using MersalAccountingService.Entities.Entity;
using MersalAccountingService.WebAPI.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
#endregion

namespace MersalAccountingService.WebAPI.Controllers.API
{
    [RoutePrefix("api/DonationCaseReports")]
    public class DonationCaseReportsController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IDonationCaseReportsService _ReportsService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type TransactionController.
        /// </summary>
        /// <param name="TransactionsService">The injected service.</param>
        public DonationCaseReportsController(IDonationCaseReportsService ReportsService)
        {
            this._ReportsService = ReportsService;
        }
        #endregion

        #region Actions                

        [Route("get-donator-cases-history-report/{donatorId}")]
        [HttpGet]       
        //[JwtAuthentication(Permissions.DonatorCasesHistoryReport)]
        public IList<DonatorCasesHistoryReportViewModel> GetDonatorCasesHistoryReport(long? donatorId, DateTime? DateFrom, DateTime? DateTo)
        {
            var result = this._ReportsService.GetDonatorCasesHistoryReport(donatorId.Value, DateFrom, DateTo);
            return result;
        }

        [Route("get-donation-cases-balance-report")]
        [HttpGet]
        //[JwtAuthentication(Permissions.DonationCasesBalanceReport)]
        public IList<DonationCasesBalanceReportViewModel> GetDonationCasesBalanceReport(long? caseId, DateTime? DateFrom, DateTime? DateTo)
        {
            var result = this._ReportsService.GetDonationCasesBalanceReport(caseId, DateFrom, DateTo);
            return result;
        }
        
        #endregion
    }
}