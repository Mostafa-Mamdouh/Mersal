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
	public interface IBankReportsService : IBaseService
	{
		#region Methods
		IList<Transaction> VirtualPostBankMovement(long bankId, DateTime? toDate, Language lang, long? userId);
		IList<Transaction> VirtualPostPaymentMovement(long bankId, DateTime? toDate, Language lang, long? userId);
		//IList<Transaction> VirtualPostPurchaseInvoice(long bankId, DateTime? toDate, Language lang, long? userId);
		IList<Transaction> VirtualPostReceiptsMovement(long bankId, DateTime? toDate, Language lang, long? userId);
		IList<Transaction> VirtualPostSalesInvoice(long bankId, DateTime? toDate, Language lang, long? userId);
		IList<Transaction> VirtualPostSalesRebate(long bankId, DateTime? toDate, Language lang, long? userId);
		IList<Transaction> VirtualPostStoreMovement(long bankId, DateTime? toDate, Language lang, long? userId);

		IList<BankAccountReportViewModel> GetBankAccountReport(long bankId, DateTime? DateFrom, DateTime? DateTo);
        IList<BankAccountReportViewModel> GetBankBalanceReport(long bankId, DateTime? DateFrom, DateTime? DateTo);
        
        IList<BankAccountReportViewModel> GetBankAccountReportBeforeDate(long bankId, DateTime DateFrom, List<Transaction> source);
		#endregion
	}
}
