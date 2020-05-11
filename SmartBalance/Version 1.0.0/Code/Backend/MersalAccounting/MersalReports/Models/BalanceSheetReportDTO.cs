using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MersalReports.Models
{
    public class BalanceSheetReportDTO
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string FullCode { get; set; }

        //public DateTime? CreationDate { get; set; }
        //public string DocumentCode { get; set; }
        public decimal? OpeningCredit { get; set; }
        public decimal? OpeningDebit { get; set; }
        public decimal? CreditorValue { get; set; }
        public decimal? DebtorValue { get; set; }

		public decimal? TotalCreditValue { get; set; }
		public decimal? TotalDebtValue { get; set; }
	}
}