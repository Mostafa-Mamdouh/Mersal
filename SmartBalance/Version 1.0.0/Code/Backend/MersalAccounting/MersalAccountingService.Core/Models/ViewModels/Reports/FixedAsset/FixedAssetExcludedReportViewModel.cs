using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.Models.ViewModels.Reports
{
	[DebuggerDisplay("Id={Id}")]
	public class FixedAssetExcludedReportViewModel
	{
        public string VendorName { get; set; }
        public string BrandCode { get; set; }
        public string BrandName { get; set; }

        public string Code { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Amount { get; set; }
        public int? Quantity { get; set; }
        public decimal? CurrentValue { get; set; }
        public DateTime? LastDepreciationDate { get; set; }
        public string LocationName { get; set; }
        public string DepreciationRateName { get; set; }
        public decimal? DepreciationValue { get; set; }


        public bool? IsExcluded { get; set; }
        public DateTime? ExcludedDate { get; set; }


        public bool? IsSaled { get; set; }
        public decimal? SaleAmount { get; set; }
        public DateTime? SaleDate { get; set; }
    }
}
