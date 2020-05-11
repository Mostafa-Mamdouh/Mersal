#region Using ...
using MersalAccountingService.Core.Models.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels.Reports
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class ReportFiltersViewModel : BaseFilterViewModel
	{
		#region Properties
		public long? AccountChartId { get; set; }

		public DateTime? dateFrom { get; set; }
		public DateTime? DateTo { get; set; }
		#endregion
	}
}
