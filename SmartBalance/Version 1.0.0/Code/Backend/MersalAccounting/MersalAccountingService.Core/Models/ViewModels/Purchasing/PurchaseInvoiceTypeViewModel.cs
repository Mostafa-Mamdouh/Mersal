#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
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
	public class PurchaseInvoiceTypeViewModel : BaseViewModel
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type PurchaseInvoiceTypeViewModel.
		/// </summary>
		public PurchaseInvoiceTypeViewModel()
		{

		}
		#endregion

		#region Properties

		#region IEntityIdentity<T>
		public long Id { get; set; }
		#endregion

		#region IEntityDateTimeSignature
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreationDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? FirstModificationDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastModificationDate { get; set; }
		#endregion

		public string Name { get; set; }
		public IList<PurchaseInvoiceViewModel> PurchaseInvoices { get; set; }
		public IList<PurchaseRebateViewModel> PurchaseRebates { get; set; }

		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyPurchaseInvoiceTypeId { get; set; }
		public PurchaseInvoiceTypeViewModel ParentKeyPurchaseInvoiceType { get; set; }


		public IList<PurchaseInvoiceTypeViewModel> ChildTranslatedPurchaseInvoiceTypes { get; set; }
		#endregion

		#endregion
	}
}
