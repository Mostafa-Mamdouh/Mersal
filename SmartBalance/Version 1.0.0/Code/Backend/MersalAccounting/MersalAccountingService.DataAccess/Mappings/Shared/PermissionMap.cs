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
	public class PermissionMap : EntityTypeConfiguration<Permission>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// PermissionMap.
		/// </summary>
		public PermissionMap()
		{
			#region Configure Relations For Foreign Key ParentKeyPermissionId
			this.HasMany(entity => entity.ChildTranslatedPermissions)
					.WithOptional(entity => entity.ParentKeyPermission)
					.HasForeignKey(entity => entity.ParentKeyPermissionId);
			#endregion
		}
		#endregion
	}
}
