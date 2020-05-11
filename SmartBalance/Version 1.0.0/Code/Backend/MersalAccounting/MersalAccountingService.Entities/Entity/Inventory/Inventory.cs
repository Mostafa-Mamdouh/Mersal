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
	/// Provides a Inventory entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * المخزن
	 */
	public class Inventory : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Inventory.
		/// </summary>
		public Inventory()
		{
			this.ChildTranslatedInventorys = new HashSet<Inventory>();
			this.SalesBills = new HashSet<SalesBill>();
			this.Inventorys = new HashSet<DonationInventory>();
			this.PaymentMovmentInventorys = new HashSet<PaymentMovmentInventory>();
			this.PurchaseInvoices = new HashSet<PurchaseInvoice>();
			this.PurchaseRebates = new HashSet<PurchaseRebate>();
			this.Products = new HashSet<Product>();
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

		public string Name { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public DateTime? Date { get; set; }


		public long? LocationId { get; set; }
		public virtual Location Location { get; set; }


		public virtual ICollection<SalesBill> SalesBills { get; set; }

		public long? AccountChartId { get; set; }
		public virtual AccountChart AccountChart { get; set; }


		public virtual ICollection<Product> Products { get; set; }
		public virtual ICollection<DonationInventory> Inventorys { get; set; }
		public virtual ICollection<PaymentMovmentInventory> PaymentMovmentInventorys { get; set; }

		public virtual ICollection<PurchaseInvoice> PurchaseInvoices { get; set; }
		public virtual ICollection<PurchaseRebate> PurchaseRebates { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyInventoryId { get; set; }
		public virtual Inventory ParentKeyInventory { get; set; }

		public virtual ICollection<Inventory> ChildTranslatedInventorys { get; set; }
		#endregion

		#endregion
	}
}
