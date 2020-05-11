using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.Models.ViewModels
{
    public class TestamentFilterViewModel
    {
        public string Code { get; set; }

        public int? AdvancesTypeId { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public decimal? TotalValueFrom { get; set; }
        public decimal? TotalValueTo { get; set; }

        public bool? IsClosed { get; set; }

        public string Description { get; set; }

        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public List<FilterViewModel> Filters { get; set; }
        public List<OrderViewModel> Sort { get; set; }
    }
}
