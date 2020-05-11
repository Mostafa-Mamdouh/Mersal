#region Using ...
using Framework.Core.Models.ViewModels.Base;
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
	[DebuggerDisplay("Id={Id}")]
	public class ChecksUnderCollectionFilterViewModel : BaseFilterViewModel
	{
		#region Properties
		//public string Id { get; set; }
		public string Code { get; set; }
		public long? Bank { get; set; }
		public decimal? Amount { get; set; }

		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; } 
		#endregion
    }
}
