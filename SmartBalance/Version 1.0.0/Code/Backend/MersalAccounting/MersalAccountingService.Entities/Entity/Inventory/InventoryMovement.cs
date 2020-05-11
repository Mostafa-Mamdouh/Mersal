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
	/// Provides a InventoryMovement entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * حركة المخزون
	 */
	public class InventoryMovement : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryMovement.
		/// </summary>
		public InventoryMovement()
		{
			this.InventoryDifferences = new HashSet<InventoryDifference>();
            this.InventoryMovementCostCenter = new HashSet<InventoryMovementCostCenter>();
            this.ChildTranslatedInventoryMovements = new HashSet<InventoryMovement>();
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

        #region IPostingSignature
        public bool IsPosted { get; set; }
        public DateTime? PostingDate { get; set; }
        public long? PostedByUserId { get; set; }
        #endregion

        public string Code { get; set; }
		public Nullable<DateTime> Date { get; set; }
		public string Description { get; set; }
 
        public long ReferenceNumber { get; set; }

        public virtual Nullable<long> InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }

        public virtual Nullable<long> InventoryMovementTypeId { get; set; }
        public virtual InventoryMovementType InventoryMovementType { get; set; }

        public long? OutgoingTypeId { get; set; }
        public virtual InventoryMovementType OutgoingType { get; set; }


        public string BillNumber { get; set; }

        public virtual long? VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }


        public virtual ICollection<InventoryDifference> InventoryDifferences { get; set; }
        public virtual ICollection<InventoryMovementCostCenter> InventoryMovementCostCenter { get; set; }

        public virtual ICollection<InventoryProductHistory> InventoryProductHistorys { get; set; }

        #region Translation Functionality
        public Language? Language { get; set; }

		public long? ParentKeyInventoryMovementId { get; set; }
		public virtual InventoryMovement ParentKeyInventoryMovement { get; set; }

 
		public virtual ICollection<InventoryMovement> ChildTranslatedInventoryMovements { get; set; }
		#endregion

		#endregion
	}
}
