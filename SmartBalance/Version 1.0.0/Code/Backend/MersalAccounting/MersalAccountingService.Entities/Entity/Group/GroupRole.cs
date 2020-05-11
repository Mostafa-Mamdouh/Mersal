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
	/// Provides a GroupRole entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * قاعدة المجموعة
	 */
	public class GroupRole : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type GroupRole.
		/// </summary>
		public GroupRole()
		{
			this.ChildTranslatedGroupRoles = new HashSet<GroupRole>();
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

		public Nullable<long> GroupId { get; set; }
		public virtual Group Group { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyGroupRoleId { get; set; }
		public virtual GroupRole ParentKeyGroupRole { get; set; }


		public virtual ICollection<GroupRole> ChildTranslatedGroupRoles { get; set; }
		#endregion

		#endregion
	}
}
