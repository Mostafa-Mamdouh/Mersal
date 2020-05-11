#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using MersalAccountingService.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Entities.Entity
{
	/// <summary>
	/// Provides a PurchaseInvoice entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * فاتورة المشتريات
	 */
	public class PurchaseInvoice : IEntityIdentity<long>, IEntityDateTimeSignature, IEntityUserSignature, IPostingSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type PurchaseInvoice.
		/// </summary>
		public PurchaseInvoice()
		{
			this.PurchaseInvoiceCostCenters = new HashSet<PurchaseInvoiceCostCenter>();
			this.Products = new HashSet<Product>();
			//this.EntrancePermissions = new HashSet<EntrancePermission>();
			//this.ChildTranslatedPurchaseInvoices = new HashSet<PurchaseInvoice>();
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
		public virtual Vendor Vendor { get; set; }

		public long? InventoryId { get; set; }
		public virtual Inventory Inventory { get; set; }

		public long? PurchaseInvoiceTypeId { get; set; }
		public virtual PurchaseInvoiceType PurchaseInvoiceType { get; set; }

		public long? SafeId { get; set; }
		public virtual Safe Safe { get; set; }
		public long? ToBankAccountChartId { get; set; }
		public virtual BankAccountChart BankAccountChart { get; set; }

		public long? VisaBankId { get; set; }
		public virtual Bank VisaBank { get; set; }

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
		//تاريخ الاستحقاق
		public DateTime? Duedate { get; set; }

		public long? FromBankId { get; set; }
		public long? ToBankId { get; set; }
		#endregion

		public virtual ICollection<PurchaseInvoiceCostCenter> PurchaseInvoiceCostCenters { get; set; }
		public virtual ICollection<Product> Products { get; set; }
		//public virtual ICollection<EntrancePermission> EntrancePermissions { get; set; }


		//#region Translation Functionality
		//public Language? Language { get; set; }

		//public long? ParentKeyPurchaseInvoiceId { get; set; }
		//public virtual PurchaseInvoice ParentKeyPurchaseInvoice { get; set; }


		//public virtual ICollection<PurchaseInvoice> ChildTranslatedPurchaseInvoices { get; set; }
		//#endregion

		#endregion
	}
}
