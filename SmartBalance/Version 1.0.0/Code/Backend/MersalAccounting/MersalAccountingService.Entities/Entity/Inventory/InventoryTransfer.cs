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
	/// Provides a InventoryTransfer entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * التحويلات المخزنية
	 */
	public class InventoryTransfer : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryTransfer.
		/// </summary>
		public InventoryTransfer()
		{
            this.InventoryTransferCostCenter = new HashSet<InventoryTransferCostCenter>();
            this.ChildTranslatedInventoryTransfers = new HashSet<InventoryTransfer>();
            this.InventoryProductHistorys = new HashSet<InventoryProductHistory>();
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

        public DateTime? Date { get; set; }

        public string Description { get; set; }

        public virtual Nullable<long> InventoryFromId { get; set; }
        public virtual Inventory InventoryFrom { get; set; }

        public virtual Nullable<long> InventoryToId { get; set; }
        public virtual Inventory InventoryTo { get; set; }


        public virtual ICollection<InventoryTransferCostCenter> InventoryTransferCostCenter { get; set; }


        #region Translation Functionality
        public Language? Language { get; set; }

		public long? ParentKeyInventoryTransferId { get; set; }
		public virtual InventoryTransfer ParentKeyInventoryTransfer { get; set; }
        public virtual ICollection<InventoryProductHistory> InventoryProductHistorys { get; set; }

        public virtual ICollection<InventoryTransfer> ChildTranslatedInventoryTransfers { get; set; }
		#endregion

		#endregion
	}
}
