#region Using ...
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
	[DebuggerDisplay("Id={Id}, BrandName={BrandName}, Amount={Amount}, CurrentValue={CurrentValue}, Date={Date}, DepreciationValue={DepreciationValue}")]
	public class ListAssetLightViewModel : BaseViewModel
	{
		#region Properties
		public long Id { get; set; }
		//public DateTime? Date { get; set; }
		public string BrandName { get; set; }
		public string LocationName { get; set; }
		public string AccountChartName { get; set; }
		public string DepreciationRateName { get; set; }
		public string DepreciationTypeName { get; set; }
		public string PurchaseInvoiceCode { get; set; }
		public decimal? DepreciationValue { get; set; }
		public decimal? Amount { get; set; }
		public DateTime? Date { get; set; }
		public decimal? CurrentValue { get; set; }
		#endregion
	}
}
