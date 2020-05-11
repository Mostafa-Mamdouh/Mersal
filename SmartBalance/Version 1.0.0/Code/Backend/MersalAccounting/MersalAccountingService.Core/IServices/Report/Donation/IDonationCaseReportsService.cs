#region Using ...
using Framework.Common.Enums;
using Framework.Core.Filters;
using Framework.Core.IServices.Base;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Core.Models.ViewModels.Reports;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.IServices
{
    public interface IDonationCaseReportsService : IBaseService
    {
        #region Methods
        IList<DonatorCasesHistoryReportViewModel> GetDonatorCasesHistoryReport(long? donatorId, DateTime? DateFrom, DateTime? DateTo);
        IList<DonationCasesBalanceReportViewModel> GetDonationCasesBalanceReport(long? caseId, DateTime? DateFrom, DateTime? DateTo);
        #endregion
    }
}
