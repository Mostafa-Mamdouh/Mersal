#region Using ...
using System.Collections.Generic;
using System.Diagnostics;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class ApprovedRejectedCollectionViewModel
	{
		#region Properties
		public IList<long> ApprovedCollection { get; set; }
		public IList<long> RejectedCollection { get; set; }
		#endregion
	}
}
