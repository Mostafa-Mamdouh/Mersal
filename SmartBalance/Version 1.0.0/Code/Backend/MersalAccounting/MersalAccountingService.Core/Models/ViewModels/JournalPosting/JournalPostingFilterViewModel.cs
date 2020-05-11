#region Using ...
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Common.Enums;
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
	public class JournalPostingFilterViewModel : BaseFilterViewModel
	{
		#region Properties

		#region IEntityIdentity<T>
		public string Id { get; set; }
		#endregion

		public bool? IsAutomaticPosting { get; set; }
		public bool? IsBulkPosting { get; set; }
		public MovementType MovementType { get; set; }

		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }
		#endregion
	}
}
