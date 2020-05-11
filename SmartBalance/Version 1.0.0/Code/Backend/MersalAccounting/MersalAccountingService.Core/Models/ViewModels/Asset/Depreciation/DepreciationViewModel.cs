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
	[DebuggerDisplay("Id={Id}")]
	public class DepreciationViewModel : BaseViewModel
	{
		#region Properties
		public long Id { get; set; }
		public long AssetId { get; set; }
		//public AccountChartViewModel AccountChart { get; set; }
		public string BrandName { get; set; }
		public string DepreciationRateName { get; set; }
		public decimal? CurrentValue { get; set; }
		public bool? Successed { get; set; }
		public DateTime? NextDepreciationDate { get; set; }
		#endregion
	}
}
