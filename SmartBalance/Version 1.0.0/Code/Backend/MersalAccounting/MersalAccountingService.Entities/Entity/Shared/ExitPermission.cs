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
	/// Provides a ExitPermission entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * إذن خروج
	 */
	public class ExitPermission : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type ExitPermission.
		/// </summary>
		public ExitPermission()
		{
			this.InventoryOuts = new HashSet<InventoryOut>();
			this.ChildTranslatedExitPermissions = new HashSet<ExitPermission>();
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
		public virtual ICollection<InventoryOut> InventoryOuts { get; set; }
		public string Description { get; set; }
		public Nullable<DateTime> Date { get; set; }
		public bool IsApproved { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyExitPermissionId { get; set; }
		public virtual ExitPermission ParentKeyExitPermission { get; set; }


		public virtual ICollection<ExitPermission> ChildTranslatedExitPermissions { get; set; }
		#endregion

		#endregion
	}
}
