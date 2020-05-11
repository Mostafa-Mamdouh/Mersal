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
	/// Provides a UserGroup entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * مجموعة المستخدم
	 */
	public class UserGroup : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type UserGroup.
		/// </summary>
		public UserGroup()
		{
			this.ChildTranslatedUserGroups = new HashSet<UserGroup>();
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
		public Nullable<long> UserId { get; set; }
		public virtual User User { get; set; }
		public Nullable<long> GroupId { get; set; }
		public virtual Group Group { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyUserGroupId { get; set; }
		public virtual UserGroup ParentKeyUserGroup { get; set; }

 
		public virtual ICollection<UserGroup> ChildTranslatedUserGroups { get; set; }
		#endregion

		#endregion
	}
}
