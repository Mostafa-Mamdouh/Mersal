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
    public interface ICostCenterReportsService : IBaseService
    {
        #region Methods
        IList<Transaction> VirtualPostBankMovement(long costCenterId, DateTime? toDate, Language lang, long? userId);
        IList<Transaction> VirtualPostPaymentMovement(long costCenterId, DateTime? toDate, Language lang, long? userId);
        IList<Transaction> VirtualPostPurchaseInvoice(long costCenterId, DateTime? toDate, Language lang, long? userId);
        IList<Transaction> VirtualPostPurchaseRebate(long costCenterId, DateTime? toDate, Language lang, long? userId);
        IList<Transaction> VirtualPostReceiptsMovement(long costCenterId, DateTime? toDate, Language lang, long? userId);
        IList<Transaction> VirtualPostSalesInvoice(long costCenterId, DateTime? toDate, Language lang, long? userId);
        IList<Transaction> VirtualPostSalesRebate(long costCenterId, DateTime? toDate, Language lang, long? userId);
        IList<Transaction> VirtualPostStoreMovement(long costCenterId, DateTime? toDate, Language lang, long? userId);

        IList<CostCenterAccountReportViewModel> GetCostCenterAccountReport(long costCenterId, DateTime? DateFrom, DateTime? DateTo);
        IList<CostCenterAccountReportViewModel> GetCostCenterBalanceReport(long costCenterId, DateTime? DateFrom, DateTime? DateTo);

        IList<CostCenterAccountReportViewModel> GetCostCenterAccountReportBeforeDate(long costCenterId, DateTime DateFrom, List<Transaction> source);
        #endregion
    }
}
