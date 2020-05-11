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
	[DebuggerDisplay("Id={Id}, Code={Code}, Name={Name}, DateFrom={DateFrom}, DateTo={DateTo}")]
	public class UserFilterViewModel : BaseFilterViewModel
	{
		#region Properties
		public string Id { get; set; }
		public string Name { get; set; }
		public bool? IsActive { get; set; }

		public string UserName { get; set; }
		public int? Gender { get; set; }

		public decimal? MaxPaymentLimitFrom { get; set; }
		public decimal? MaxPaymentLimitTo { get; set; }

		public DateTime? BirthDateFrom { get; set; }
		public DateTime? BirthDateTo { get; set; }
		#endregion
	}
}
