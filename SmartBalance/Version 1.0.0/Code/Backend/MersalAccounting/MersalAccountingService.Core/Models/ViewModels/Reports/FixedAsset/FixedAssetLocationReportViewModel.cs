#region Using ...
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace MersalAccountingService.Core.Models.ViewModels.Reports
{
	[DebuggerDisplay("VendorName={VendorName}, BrandCode={BrandCode}, BrandName={BrandName}, Date={Date}, Quantity={Quantity}, Amount={Amount}, CurrentValue={CurrentValue}")]
	public class FixedAssetLocationReportViewModel
	{
        public string VendorName { get; set; }
        public string BrandCode { get; set; }
        public string BrandName { get; set; }

        public string Code { get; set; }
        public DateTime? Date { get; set; }
        public int? Quantity { get; set; }
        public decimal? Amount { get; set; }
        public decimal? CurrentValue { get; set; }     
        public string LocationName { get; set; }
        public string Description { get; set; }
    }
}
