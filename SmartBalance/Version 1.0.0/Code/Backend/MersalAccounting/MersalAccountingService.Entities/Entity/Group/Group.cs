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
	/// Provides a Group entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * مجموعة
	 */
	public class Group : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Group.
		/// </summary>
		public Group()
		{
			this.GroupRoles = new HashSet<GroupRole>();
			this.GroupPermissions = new HashSet<GroupPermission>();
			this.UserGroups = new HashSet<UserGroup>();
			this.ChildTranslatedGroups = new HashSet<Group>();
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

		public virtual ICollection<GroupRole> GroupRoles { get; set; }
		public virtual ICollection<GroupPermission> GroupPermissions { get; set; }
		public virtual ICollection<UserGroup> UserGroups { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyGroupId { get; set; }
		public virtual Group ParentKeyGroup { get; set; }


		public virtual ICollection<Group> ChildTranslatedGroups { get; set; }
		#endregion

		#endregion
	}
}
