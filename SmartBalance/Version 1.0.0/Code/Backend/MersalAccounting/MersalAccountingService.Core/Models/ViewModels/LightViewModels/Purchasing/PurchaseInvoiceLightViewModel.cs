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

namespace MersalAccountingService.Core.Models.ViewModels.LightViewModels
{
	/// <summary>
	/// Provides a lite model for entity 
	/// PurchaseInvoice, and this lite model 
	/// do not contains a children 
	/// relations for speeding up the 
	/// retrivement process.
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class PurchaseInvoiceLightViewModel : BaseViewModel
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type PurchaseInvoiceLightViewModel.
		/// </summary>
		public PurchaseInvoiceLightViewModel()
		{

		}
		#endregion

		#region Properties

		#region IEntityIdentity<T>
		public long Id { get; set; }
		#endregion

		#region IEntityDateTime
		public DateTime CreationDate { get; set; }
		public DateTime? FirstModificationDate { get; set; }
		public DateTime? LastModificationDate { get; set; }
		#endregion

		#region IEntityUserSignature		
		public long? CreatedByUserId { get; set; }
		public long? FirstModifiedByUserId { get; set; }
		public long? LastModifiedByUserId { get; set; }
        #endregion

        #region IPostingSignature
        public bool IsPosted { get; set; }
        public DateTime? PostingDate { get; set; }
        public long? PostedByUserId { get; set; }
        #endregion

        public string Code { get; set; }
		public string VendorInvoiceCode { get; set; }
		public DateTime Date { get; set; }
		//public string Description { get; set; }

		public Nullable<long> VendorId { get; set; }
		public virtual VendorLightViewModel Vendor { get; set; }

		public long? InventoryId { get; set; }
		public virtual InventoryLightViewModel Inventory { get; set; }

		public long? PurchaseInvoiceTypeId { get; set; }
		public virtual PurchaseInvoiceTypeLightViewModel PurchaseInvoiceType { get; set; }

		public long? SafeId { get; set; }
		public virtual SafeLightViewModel Safe { get; set; }

        public long? VisaBankId { get; set; }
        public virtual BankLightViewModel VisaBank { get; set; }

        public string VisaNumber { get; set; }

        public bool HasAdditionalExpenses { get; set; }
		public decimal? AdditionalExpensesAmount { get; set; }

		public bool HasDiscount { get; set; }
		public decimal? DiscountAmount { get; set; }

		public decimal TotalAmountBeforeTax { get; set; }
		public decimal TaxAmount { get; set; }
        public decimal TotalAmountAfterTax { get; set; }
        public decimal TotalExpenses { get; set; }
		public decimal TotalDiscount { get; set; }
		public decimal NetAmount { get; set; }		

		#endregion
	}
}
