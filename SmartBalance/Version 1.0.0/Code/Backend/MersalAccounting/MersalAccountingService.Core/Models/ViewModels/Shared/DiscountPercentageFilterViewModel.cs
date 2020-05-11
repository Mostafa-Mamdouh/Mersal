using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.Models.ViewModels
{
    public class DiscountPercentageFilterViewModel
    {
        public long? Id { get; set; }
        public string Name { get; set; }

        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public List<FilterViewModel> Filters { get; set; }
        public List<OrderViewModel> Sort { get; set; }
    }
}
