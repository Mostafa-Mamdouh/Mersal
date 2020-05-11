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
	[DebuggerDisplay("InventoryCode={InventoryCode}, InventoryName={InventoryName}, BrandCode={BrandCode}, BrandName={BrandName}, Price={Price}, Quantity={Quantity}, NetValue={NetValue}, Date={Date}")]
	public class InventoryBalanceReportViewModel
	{
		public string InventoryCode { get; set; }
		public string InventoryName { get; set; }


		public string BrandCode { get; set; }
		public string BrandName { get; set; }
		public decimal Price { get; set; }
		public double Quantity { get; set; }

		public decimal NetValue { get; set; }
		public DateTime? Date { get; set; }

        public string MeasurementUnitName { get; set; }
        public decimal? Discount { get; set; }
    }
}
