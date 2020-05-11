#region Using ...
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.DataAccess.Mappings
{
	public class UserGroupMap : EntityTypeConfiguration<UserGroup>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// UserGroupMap.
		/// </summary>
		public UserGroupMap()
		{
			#region Configure Relations For Foreign Key ParentKeyUserGroupId
			this.HasMany(entity => entity.ChildTranslatedUserGroups)
					.WithOptional(entity => entity.ParentKeyUserGroup)
					.HasForeignKey(entity => entity.ParentKeyUserGroupId);
			#endregion
		}
		#endregion
	}
}
