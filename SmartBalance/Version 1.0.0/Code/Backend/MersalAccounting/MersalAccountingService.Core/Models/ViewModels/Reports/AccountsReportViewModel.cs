using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.Models.ViewModels.Reports
{
	[DebuggerDisplay("FullCode={FullCode}, Name={Name}, MovementType={MovementType}, CreditorValue={CreditorValue}, DebtorValue={DebtorValue}")]
	public class AccountsReportViewModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string FullCode { get; set; }

        public DateTime? CreationDate { get; set; }
        public string DocumentCode { get; set; }
        public string Description { get; set; }
        public string MovementType { get; set; }

        public decimal? CreditorValue { get; set; }
        public decimal? DebtorValue { get; set; }

        public decimal? OriginalCreditorValue { get; set; }
        public decimal? OriginalDebtorValue { get; set; }

        public string AccountCurrencyName { get; set; }
        public string ExchangeCurrencyName { get; set; }
        public string PriceValue { get; set; }
    }
}
