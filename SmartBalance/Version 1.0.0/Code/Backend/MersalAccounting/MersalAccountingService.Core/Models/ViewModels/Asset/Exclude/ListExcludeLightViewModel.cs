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
	public class ListExcludeLightViewModel : BaseViewModel
	{
		#region Properties
		public long Id { get; set; }
		public string BrandCode { get; set; }
		public string BrandName { get; set; }
		public string AccountChartName { get; set; }
		public decimal CurrentValue { get; set; }
		public decimal DepreciationValue { get; set; }
		#endregion
	}
}
