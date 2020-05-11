using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.Models.ViewModels
{
    public class AdvanceViewModel
    {
        public string LiquidationNumber { get; set; }
        public decimal? Amount { get; set; }


        public long? CostCenterId { get; set; }

        public string CaseCode { get; set; }

        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }

        public int? PaymentMethodId { get; set; }

        public long? AccountChartId { get; set; }

        public long? BankId { get; set; }
    }
}
