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
	/// Provides a RolePermission entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * 
	 */
	public class RolePermission : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type RolePermission.
		/// </summary>
		public RolePermission()
		{
			this.ChildTranslatedRolePermissions = new HashSet<RolePermission>();
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
		public Nullable<long> RoleId { get; set; }
		public virtual Role Role { get; set; }
		public Nullable<long> PermissionId { get; set; }
		public virtual Permission Permission { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyRolePermissionId { get; set; }
		public virtual RolePermission ParentKeyRolePermission { get; set; }


		public virtual ICollection<RolePermission> ChildTranslatedRolePermissions { get; set; }
		#endregion

		#endregion
	}
}
