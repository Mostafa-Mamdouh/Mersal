using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.Models.ViewModels
{
    public class LiquidationDetailViewModel
    {
        public long? AdvanceId { get; set; }
        public string LiquidationNumber { get; set; }

        public decimal Amount { get; set; }

        public long TestamentExtractionId { get; set; }

        public long? CostCenterId { get; set; }

        public string CaseCode { get; set; }

        public decimal? TaxDiscount { get; set; }

        public decimal? MedicineDiscount { get; set; }
    }
}
