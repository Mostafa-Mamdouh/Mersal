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
	public class ExcludeViewModel : BaseViewModel
	{
		#region Properties
		public long Id { get; set; }

		public long AssetId { get; set; }

		public bool? IsSpeculation { get; set; }
		public bool? IsSaled { get; set; }
		public decimal? Amount { get; set; }

		public long AccountChartId { get; set; }
		#endregion
	}
}
