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
    public interface IVendorReportsService : IBaseService
    {
        #region Methods
        IList<Transaction> VirtualPostPaymentMovement(long vendorId, DateTime? toDate, Language lang, long? userId);
        IList<Transaction> VirtualPostPurchaseInvoice(long vendorId, DateTime? toDate, Language lang, long? userId);
        IList<Transaction> VirtualPostPurchaseRebate(long vendorId, DateTime? toDate, Language lang, long? userId);
        IList<Transaction> VirtualPostReceiptsMovement(long vendorId, DateTime? toDate, Language lang, long? userId);
        IList<Transaction> VirtualPostSalesInvoice(long vendorId, DateTime? toDate, Language lang, long? userId);
        IList<Transaction> VirtualPostSalesRebate(long vendorId, DateTime? toDate, Language lang, long? userId);
        IList<Transaction> VirtualPostStoreMovement(long vendorId, DateTime? toDate, Language lang, long? userId);

        IList<VendorAccountReportViewModel> GetVendorAccountReport(long vendortId, DateTime? DateFrom, DateTime? DateTo);
        IList<VendorAccountReportViewModel> GetVendorBalanceReport(long vendortId, DateTime? DateFrom, DateTime? DateTo);       
        IList<VendorAccountReportViewModel> GetVendorAccountReportBeforeDate(long vendorId, DateTime DateFrom, List<Transaction> source);               
        #endregion
    }
}
