#region Using ..
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace MersalAccountingService.Core.Models.ViewModels.JournalEntries
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class AddJournalEntriesViewModel : BaseViewModel
    {
		#region Properties
		public long DocId { get; set; }
		public long Id { get; set; }
		public long Code { get; set; }
		public DateTime Date { get; set; }
		public string DescriptionAr { get; set; }
		public string DescriptionEn { get; set; }
		public string DocumentNumber { get; set; }
		public MovementType? MovementType { get; set; }
		public string MovementTypeName { get; set; }

		public long? ObjectId { get; set; }
		public bool IsAutomaticPosting { get; set; }
		public bool IsBulkPosting { get; set; }

		public bool IsReversed { get; set; }
		public long? ReversedFromId { get; set; }
		public long? ReversedToId { get; set; }

		public PostingStatus PostingStatus { get; set; }

		public virtual ICollection<JournalDetailsViewModel> journalDetails { get; set; } 
		#endregion
	}
}
