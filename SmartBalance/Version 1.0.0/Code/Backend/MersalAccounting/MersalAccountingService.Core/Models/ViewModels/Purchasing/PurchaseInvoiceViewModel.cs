#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Core.Models.ViewModels.JournalEntries;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
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
	public class PurchaseInvoiceViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type PurchaseInvoiceViewModel.
        /// </summary>
        public PurchaseInvoiceViewModel()
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
		public virtual VendorViewModel Vendor { get; set; }

		public long? InventoryId { get; set; }
		public virtual InventoryViewModel Inventory { get; set; }

		public long? PurchaseInvoiceTypeId { get; set; }
		public virtual PurchaseInvoiceTypeViewModel PurchaseInvoiceType { get; set; }

		public long? SafeId { get; set; }
		public virtual SafeViewModel Safe { get; set; }

        public long? VisaBankId { get; set; }
        public virtual BankViewModel VisaBank { get; set; }

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

        #region payment 
        public string ChequeNumber { get; set; }
        //????? ?????????
        public DateTime? DueDate { get; set; }

        public long? FromBankId { get; set; }
        public long? ToBankId { get; set; }
        public long? ToBankAccountChartId { get; set; }
        #endregion

        public List<BrandLightViewModel> Brands { get; set; }

        public IList<PurchaseInvoiceCostCenterViewModel> PurchaseInvoiceCostCenters { get; set; }
		public IList<ProductViewModel> Products { get; set; }
		//public virtual ICollection<EntrancePermission> EntrancePermissions { get; set; }


		//#region Translation Functionality
		//public Language? Language { get; set; }

		//public long? ParentKeyPurchaseInvoiceId { get; set; }
		//public virtual PurchaseInvoice ParentKeyPurchaseInvoice { get; set; }


		//public virtual ICollection<PurchaseInvoice> ChildTranslatedPurchaseInvoices { get; set; }
		//#endregion


		public AddJournalEntriesViewModel Journal { get; set; }

		#endregion
	}
}
