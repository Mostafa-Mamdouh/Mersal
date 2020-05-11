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
	/// Provides a InventoryOut entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * صادر مخزن
	 */
	public class InventoryOut : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryOut.
		/// </summary>
		public InventoryOut()
		{
			this.ChildTranslatedInventoryOuts = new HashSet<InventoryOut>();
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
		public Nullable<long> ExitPermissionId { get; set; }
		public virtual ExitPermission ExitPermission { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyInventoryOutId { get; set; }
		public virtual InventoryOut ParentKeyInventoryOut { get; set; }


		public virtual ICollection<InventoryOut> ChildTranslatedInventoryOuts { get; set; }
		#endregion

		#endregion
	}
}
