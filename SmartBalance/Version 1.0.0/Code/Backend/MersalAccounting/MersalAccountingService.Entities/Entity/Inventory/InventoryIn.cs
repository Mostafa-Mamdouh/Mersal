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
	/// Provides a InventoryIn entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * وارد مخزن
	 */
	public class InventoryIn : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryIn.
		/// </summary>
		public InventoryIn()
		{
			this.ChildTranslatedInventoryIns = new HashSet<InventoryIn>();
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
		public Nullable<long> EntrancePermissionId { get; set; }
		public virtual EntrancePermission EntrancePermission { get; set; }
		public string Description { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyInventoryInId { get; set; }
		public virtual InventoryIn ParentKeyInventoryIn { get; set; }

 
		public virtual ICollection<InventoryIn> ChildTranslatedInventoryIns { get; set; }
		#endregion

		#endregion
	}
}
