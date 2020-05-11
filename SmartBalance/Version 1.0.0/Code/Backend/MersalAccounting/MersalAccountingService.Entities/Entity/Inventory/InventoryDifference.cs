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
	/// Provides a InventoryDifference entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * فروق جرد
	 */
	public class InventoryDifference : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryDifference.
		/// </summary>
		public InventoryDifference()
		{
			this.ChildTranslatedInventoryDifferences = new HashSet<InventoryDifference>();
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
		public Nullable<long> InventoryMovementId { get; set; }
		public virtual InventoryMovement InventoryMovement { get; set; }
		public Nullable<long> ProductId { get; set; }
		public virtual Product Product { get; set; }
		public byte Type { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyInventoryDifferenceId { get; set; }
		public virtual InventoryDifference ParentKeyInventoryDifference { get; set; }


		public virtual ICollection<InventoryDifference> ChildTranslatedInventoryDifferences { get; set; }
		#endregion

		#endregion
	}
}
