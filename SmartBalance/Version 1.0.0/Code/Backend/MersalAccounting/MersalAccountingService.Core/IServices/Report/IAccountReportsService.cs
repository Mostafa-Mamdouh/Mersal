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
    public interface IAccountReportsService
    {
        #region Methods
        IList<AccountsReportViewModel> GetAccountsReport(long AccountChartId, long? currencyId, DateTime? DateFrom, DateTime? DateTo);
        IList<AccountsReportViewModel> GetAccountBalanceReport(long AccountChartId, long? currencyId, DateTime? DateFrom, DateTime? DateTo);        
        IList<BalanceSheetReportViewModel> GetBalanceSheetReport(int level, DateTime? DateFrom, DateTime? DateTo);
		BalanceSheetReportViewModel GetOpeningBalance(BalanceSheetReportViewModel source, long accountChartId, DateTime? dateFrom, DateTime? dateTo, AccountChart accountChart = null);



		IList<AccountsReportViewModel> GetAccReportBeforeDate(long AccountChartId, long? currencyId, DateTime DateFrom);
        #endregion
    }
}
