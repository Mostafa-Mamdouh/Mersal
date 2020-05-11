#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
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
	/// Provides a Vendor entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * الموردين
	 */
	public class Vendor : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Vendor.
		/// </summary>
		public Vendor()
		{
			this.ChildTranslatedVendors = new HashSet<Vendor>();
			this.PaymentMovments = new HashSet<PaymentMovment>();
			this.PurchaseInvoices = new HashSet<PurchaseInvoice>();
			this.PurchaseRebates = new HashSet<PurchaseRebate>();
			this.InventoryOpeningBalances = new HashSet<InventoryOpeningBalance>();
			this.InventoryMovements = new HashSet<InventoryMovement>();
            this.DonationVendors = new HashSet<DonationVendor>();
            this.PaymentMovmentVendors = new HashSet<PaymentMovmentVendor>();
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

		public string Code { get; set; }
		public string Name { get; set; }
		public DateTime? Date { get; set; }

		public decimal? OpeningCredit { get; set; }
		public bool? IsDebt { get; set; }

		public Nullable<long> VendorTypeId { get; set; }
		public virtual VendorType VendorType { get; set; }

		public string Description { get; set; }

		public long? AccountChartId { get; set; }
		public virtual AccountChart AccountChart { get; set; }

		public string CommercialRegister { get; set; }

		public string TaxCard { get; set; }

		public string PayeeName { get; set; }

		public bool? ExemptFromTax { get; set; }

		public string VATRegistrationCertificate { get; set; }

		public virtual ICollection<PaymentMovment> PaymentMovments { get; set; }
		public virtual ICollection<PurchaseInvoice> PurchaseInvoices { get; set; }
		public virtual ICollection<PurchaseRebate> PurchaseRebates { get; set; }
		public virtual ICollection<InventoryOpeningBalance> InventoryOpeningBalances { get; set; }
		public virtual ICollection<InventoryMovement> InventoryMovements { get; set; }
        public virtual ICollection<PaymentMovmentVendor> PaymentMovmentVendors { get; set; }
        public virtual ICollection<DonationVendor> DonationVendors { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyVendorId { get; set; }
		public virtual Vendor ParentKeyVendor { get; set; }

		public virtual ICollection<Vendor> ChildTranslatedVendors { get; set; }

		#endregion

		#endregion
	}
}
