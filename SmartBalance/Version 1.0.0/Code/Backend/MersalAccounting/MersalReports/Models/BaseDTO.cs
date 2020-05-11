using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MersalReports.Models
{
    public class BaseDTO
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
    }
}