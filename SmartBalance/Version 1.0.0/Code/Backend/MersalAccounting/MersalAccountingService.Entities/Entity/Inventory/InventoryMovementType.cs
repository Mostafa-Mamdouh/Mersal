#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using MersalAccountingService.Common.Enums;
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
	/// Provides a InventoryMovementType entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}, Type={Type}")]
	/*
	 * @EntityDescription: 
	 * انواع الحركات المخزنية
	 */
	public class InventoryMovementType : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryMovementType.
		/// </summary>
		public InventoryMovementType()
		{
			this.ChildTranslatedInventoryMovementTypes = new HashSet<InventoryMovementType>();
			this.ChildInventoryMovementTypes = new HashSet<InventoryMovementType>();
			this.InventoryMovements = new HashSet<InventoryMovement>();
			this.OutgoingTypes = new HashSet<InventoryMovement>();
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
		public string Description { get; set; }
		public InventoryMovementTypeEnum? Type { get; set; }

		public long? ParentInventoryMovementTypeId { get; set; }
		public virtual InventoryMovementType ParentInventoryMovementType { get; set; }

		public virtual ICollection<InventoryMovement> InventoryMovements { get; set; }

		public virtual ICollection<InventoryMovement> OutgoingTypes { get; set; }

		public virtual ICollection<InventoryMovementType> ChildInventoryMovementTypes { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyInventoryMovementTypeId { get; set; }
		public virtual InventoryMovementType ParentKeyInventoryMovementType { get; set; }


		public virtual ICollection<InventoryMovementType> ChildTranslatedInventoryMovementTypes { get; set; }
		#endregion

		#endregion
	}
}
