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
    /// <summary>
    /// JournalPostings Controller
    /// </summary>
    [RoutePrefix("api/MersalReports")]
    public class ReportsController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IReportsService _ReportsService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type JournalPostingController.
        /// </summary>
        /// <param name="JournalPostingsService">The injected service.</param>
        public ReportsController(IReportsService ReportsService)
        {
            this._ReportsService = ReportsService;
        }
        #endregion

        #region Actions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("safe-report")]
        [HttpGet]
        public IList<AccountsReportViewModel> SafeReport(long SafeId, DateTime DateFrom, DateTime DateTo)
        {
            var result = this._ReportsService.SafeReport(SafeId,DateFrom,DateTo);
            return result;
        }
       


        #endregion
    }
}
