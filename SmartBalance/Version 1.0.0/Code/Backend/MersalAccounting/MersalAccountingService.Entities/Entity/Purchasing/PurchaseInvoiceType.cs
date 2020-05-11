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
	/// Provides a PurchaseInvoiceType entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * 
	 */
	public class PurchaseInvoiceType : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type PurchaseInvoiceType.
		/// </summary>
		public PurchaseInvoiceType()
		{
			this.PurchaseInvoices = new HashSet<PurchaseInvoice>();
			this.PurchaseRebates = new HashSet<PurchaseRebate>();
			this.ChildTranslatedPurchaseInvoiceTypes = new HashSet<PurchaseInvoiceType>();
		}
		#endregion

		#region Properties

		#region IEntityIdentity<T>
		public long Id { get; set; }
		#endregion

		#region IEntityDateTimeSignature
		public DateTime CreationDate { get; set; }
		public DateTime? FirstModificationDate { get; set; }
		public DateTime? LastModificationDate { get; set; }
		#endregion

		public string Name { get; set; }

		public virtual ICollection<PurchaseInvoice> PurchaseInvoices { get; set; }
		public virtual ICollection<PurchaseRebate> PurchaseRebates { get; set; }

		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyPurchaseInvoiceTypeId { get; set; }
		public virtual PurchaseInvoiceType ParentKeyPurchaseInvoiceType { get; set; }


		public virtual ICollection<PurchaseInvoiceType> ChildTranslatedPurchaseInvoiceTypes { get; set; }
		#endregion

		#endregion
	}
}
