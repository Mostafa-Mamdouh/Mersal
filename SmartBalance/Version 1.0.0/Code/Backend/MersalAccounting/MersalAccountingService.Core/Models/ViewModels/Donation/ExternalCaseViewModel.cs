#region Using ...
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels.Donation
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class ExternalCaseViewModel
	{
		#region Properties
		public int CaseId { get; set; }
		public long PaidAmount { get; set; }
		#endregion
	}
}
