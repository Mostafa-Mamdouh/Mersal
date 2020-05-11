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
	/// Provides a GroupPermission entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * 
	 */
	public class GroupPermission : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type GroupPermission.
		/// </summary>
		public GroupPermission()
		{
			this.ChildTranslatedGroupPermissions = new HashSet<GroupPermission>();
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

		public Nullable<long> GroupId { get; set; }
		public virtual Group Group { get; set; }

		public Nullable<long> PermissionId { get; set; }
		public virtual Permission Permission { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyGroupPermissionId { get; set; }
		public virtual GroupPermission ParentKeyGroupPermission { get; set; }


		public virtual ICollection<GroupPermission> ChildTranslatedGroupPermissions { get; set; }
		#endregion

		#endregion
	}
}
