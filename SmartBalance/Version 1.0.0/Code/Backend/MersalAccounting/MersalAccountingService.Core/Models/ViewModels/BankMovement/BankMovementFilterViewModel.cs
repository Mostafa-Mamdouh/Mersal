#region Using ...
using Framework.Common.Enums;
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
	[DebuggerDisplay("Id={Id}, Code={Code}, Bank={Bank}, DateFrom={DateFrom}, DateTo={DateTo}, AmountFrom={AmountFrom}, AmountTo={AmountTo}")]
	public class BankMovementFilterViewModel : BaseFilterViewModel
	{
		#region Properties
		public string Id { get; set; }
		public string Code { get; set; }
		public long? Bank { get; set; }
		public long? JournalType { get; set; }

		public decimal? AmountFrom { get; set; }
		public decimal? AmountTo { get; set; }

		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }
		#endregion
	}
}
