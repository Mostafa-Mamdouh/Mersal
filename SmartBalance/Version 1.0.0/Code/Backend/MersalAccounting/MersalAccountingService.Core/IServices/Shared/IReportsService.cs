#region Using ...
using Framework.Core.Filters;
using Framework.Core.IServices.Base;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
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
    /// <summary>
    /// 
    /// </summary>
    public interface IReportsService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(JournalPostingViewModel model);

        IList<AccountsReportViewModel> SafeReport(long SafeId, DateTime DateFrom, DateTime DateTo);
        IList<AccountsReportViewModel> SafeBankMovement(long SafeId, DateTime DateFrom, DateTime DateTo);
        IList<AccountsReportViewModel> SafePaymentMovement(long SafeId, DateTime DateFrom, DateTime DateTo);
        IList<AccountsReportViewModel> SafePurchaseInvoice(long SafeId, DateTime DateFrom, DateTime DateTo);
        IList<AccountsReportViewModel> SafePurchaseRebate(long SafeId, DateTime DateFrom, DateTime DateTo);
        IList<AccountsReportViewModel> SafeReceiptsMovement(long SafeId, DateTime DateFrom, DateTime DateTo);
        IList<AccountsReportViewModel> SafeSalesInvoice(long SafeId, DateTime DateFrom, DateTime DateTo);
        IList<AccountsReportViewModel> SafeSalesRebate(long SafeId, DateTime DateFrom, DateTime DateTo);
        IList<AccountsReportViewModel> SafeStoreMovement(long SafeId, DateTime DateFrom, DateTime DateTo);

        IList<AccountsReportViewModel> SafeChecksUnderCollectionOfReceiptsMovement(IList<long> idCollection);

        #endregion
    }
}
