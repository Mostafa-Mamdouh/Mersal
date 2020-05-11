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
	/// Provides a Permission entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * 
	 */
	public class Permission : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Permission.
		/// </summary>
		public Permission()
		{
			this.ChildTranslatedPermissions = new HashSet<Permission>();
			this.RolePermissions = new HashSet<RolePermission>();
			this.UserPermissions = new HashSet<UserPermission>();
			this.GroupPermissions = new HashSet<GroupPermission>();
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
		public int? Code { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }


		public virtual ICollection<RolePermission> RolePermissions { get; set; }
		public virtual ICollection<UserPermission> UserPermissions { get; set; }
		public virtual ICollection<GroupPermission> GroupPermissions { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyPermissionId { get; set; }
		public virtual Permission ParentKeyPermission { get; set; }


		public virtual ICollection<Permission> ChildTranslatedPermissions { get; set; }
		#endregion

		#endregion
	}
}
