using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.Models.ViewModels.Reports
{
    [DebuggerDisplay("FullCode={FullCode}, Name={Name}, OpeningCredit={OpeningCredit}, OpeningDebit={OpeningDebit}, CreditorValue={CreditorValue}, DebtorValue={DebtorValue}")]
    public class BalanceSheetReportViewModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string FullCode { get; set; }
        public int Level { get; set; }

        //public DateTime? CreationDate { get; set; }
        public string DocumentCode { get; set; }
        public decimal? OpeningCredit { get; set; }
        public decimal? OpeningDebit { get; set; }
        public decimal? CreditorValue { get; set; }
        public decimal? DebtorValue { get; set; }

		public decimal? TotalCreditValue { get; set; }
		public decimal? TotalDebtValue { get; set; }

	}
}
