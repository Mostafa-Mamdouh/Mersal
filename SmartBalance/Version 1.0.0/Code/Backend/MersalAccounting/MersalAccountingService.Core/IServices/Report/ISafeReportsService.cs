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
    public interface ISafeReportsService : IBaseService
    {
        #region Methods
        IList<Transaction> VirtualPostPaymentMovement(long safeId, DateTime? toDate, Language lang, long? userId);
        IList<Transaction> VirtualPostPurchaseInvoice(long safeId, DateTime? toDate, Language lang, long? userId);
        IList<Transaction> VirtualPostPurchaseRebate(long safeId, DateTime? toDate, Language lang, long? userId);
        IList<Transaction> VirtualPostReceiptsMovement(long safeId, DateTime? toDate, Language lang, long? userId);
        IList<Transaction> VirtualPostSalesInvoice(long safeId, DateTime? toDate, Language lang, long? userId);
        IList<Transaction> VirtualPostSalesRebate(long safeId, DateTime? toDate, Language lang, long? userId);
        IList<Transaction> VirtualPostStoreMovement(long safeId, DateTime? toDate, Language lang, long? userId);

        IList<SafeReportViewModel> GetSafeReport(long safeId, DateTime? DateFrom, DateTime? DateTo);
        IList<SafeReportViewModel> GetSafeBalanceReport(long safeId, DateTime? DateFrom, DateTime? DateTo);        
        IList<SafeReportViewModel> GetSafeReportBeforeDate(long safeId, DateTime DateFrom, List<Transaction> source);               
        #endregion
    }
}
