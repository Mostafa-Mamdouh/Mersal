#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class InventoryOpeningBalanceProductViewModel
	{
		#region Properties
		public long Id { get; set; }
		public long? BrandId { get; set; }
		public string BrandName { get; set; }
		public BrandViewModel Brand { get; set; }

		public string Code { get; set; }
		//public string Name { get; set; }
		public decimal Price { get; set; }
		public double Quantity { get; set; }
		public Nullable<decimal> Discount { get; set; }

		public decimal Expenses { get; set; }
		public decimal TotalDiscount { get; set; }
		public decimal NetValue { get; set; }

		public decimal Total { get; set; }
		public Nullable<long> ProductTypeId { get; set; }
		public virtual ProductTypeViewModel ProductType { get; set; }

		public virtual Nullable<long> MeasurementUnitId { get; set; }
		public virtual MeasurementUnitViewModel MeasurementUnit { get; set; }

		public long? AccountChartId { get; set; }
		public virtual AccountChartViewModel AccountChart { get; set; } 
		#endregion
	}
}
