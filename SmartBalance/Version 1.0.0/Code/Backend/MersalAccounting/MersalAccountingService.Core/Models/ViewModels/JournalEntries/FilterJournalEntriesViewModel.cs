#region Using ...
using MersalAccountingService.Core.Models.ViewModels.Donation;
using MersalAccountingService.Core.Models.ViewModels.Shared;
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
	[DebuggerDisplay("Code={Code}, DateFrom={DateFrom}, DateTo={DateTo}")]
	public class FilterJournalEntriesViewModel : BaseFilterViewModel
	{
		#region Properties
		public bool Preview { get; set; }


		public bool PostReceiptsMovement { get; set; }
		public bool PostPaymentMovement { get; set; }
		public bool PostBankMovement { get; set; }
		public bool PostPurchaseInvoice { get; set; }
		public bool PostPurchaseRebate { get; set; }
		public bool PostStoreMovement { get; set; }
		public bool PostSalesInvoice { get; set; }
		public bool PostSalesRebate { get; set; }




		public string Id { get; set; }

		public string Code { get; set; }

		public string DescriptionAr { get; set; }
		public string DescriptionEn { get; set; }
		public string DocumentNumber { get; set; }

		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }
		#endregion
	}
}
