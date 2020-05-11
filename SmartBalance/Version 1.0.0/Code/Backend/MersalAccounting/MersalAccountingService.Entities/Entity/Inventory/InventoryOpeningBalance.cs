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
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	public class InventoryOpeningBalance : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public InventoryOpeningBalance()
		{
			this.Products = new HashSet<Product>();
			this.ChildTranslatedInventoryOpeningBalance = new HashSet<InventoryOpeningBalance>();
			this.InventoryOpeningBalanceCostCenter = new HashSet<InventoryOpeningBalanceCostCenter>();
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

		public Nullable<DateTime> Date { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }

		public virtual Nullable<long> InventoryId { get; set; }
		public virtual Inventory Inventory { get; set; }


		public string BillNumber { get; set; }

		public virtual long? VendorId { get; set; }
		public virtual Vendor Vendor { get; set; }


		public virtual ICollection<Product> Products { get; set; }
		public virtual ICollection<InventoryOpeningBalanceCostCenter> InventoryOpeningBalanceCostCenter { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyInventoryOpeningBalanceId { get; set; }
		public virtual InventoryOpeningBalance ParentKeyInventoryOpeningBalance { get; set; }

		public virtual ICollection<InventoryOpeningBalance> ChildTranslatedInventoryOpeningBalance { get; set; }
		#endregion

		#endregion


	}
}
