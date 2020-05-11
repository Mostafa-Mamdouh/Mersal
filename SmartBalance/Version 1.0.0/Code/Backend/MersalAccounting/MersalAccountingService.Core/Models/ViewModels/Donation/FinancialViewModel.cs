#region Using ...
using MersalAccountingService.Core.Models.ViewModels.Shared;
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
	public class FinancialViewModel : BaseFilterViewModel
	{
		#region Properties
		public string Id { get; set; }
		public string Code { get; set; }

		public int? Branch { get; set; }
		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }

		public int? Payment { get; set; }
		public decimal? AmountFrom { get; set; }
		public decimal? AmountTo { get; set; }

		public string DelegateManReciptNumber { get; set; }
		#endregion
	}
}

