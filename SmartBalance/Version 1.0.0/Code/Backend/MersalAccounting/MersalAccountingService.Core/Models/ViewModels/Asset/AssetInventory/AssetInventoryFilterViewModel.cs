#region Using ...
using MersalAccountingService.Core.Models.ViewModels.Shared;
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
	[DebuggerDisplay("Id={Id}, LocationId={LocationId}, DateFrom={DateFrom}, DateTo={DateTo}")]
	public class AssetInventoryFilterViewModel : BaseFilterViewModel
	{
		#region Properties
		public string Id { get; set; }
		public long? LocationId { get; set; }

		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }
		#endregion
	}
}
