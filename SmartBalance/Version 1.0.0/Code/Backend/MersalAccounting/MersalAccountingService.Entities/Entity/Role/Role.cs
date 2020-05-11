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
	/// Provides a Role entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * قاعدة
	 */
	public class Role : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Role.
		/// </summary>
		public Role()
		{
			this.UserRoles = new HashSet<UserRole>();
			this.RolePermissions = new HashSet<RolePermission>();
			this.ChildTranslatedRoles = new HashSet<Role>();
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
		public string Code { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }
		public DateTime? Date { get; set; }


		public virtual ICollection<UserRole> UserRoles { get; set; }
		public virtual ICollection<RolePermission> RolePermissions { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyRoleId { get; set; }
		public virtual Role ParentKeyRole { get; set; }


		public virtual ICollection<Role> ChildTranslatedRoles { get; set; }
		#endregion

		#endregion
	}
}
