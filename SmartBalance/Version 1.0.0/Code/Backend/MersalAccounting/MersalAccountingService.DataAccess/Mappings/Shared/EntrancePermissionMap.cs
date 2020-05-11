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
	public class EntrancePermissionMap : EntityTypeConfiguration<EntrancePermission>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// EntrancePermissionMap.
		/// </summary>
		public EntrancePermissionMap()
		{
			#region Configure Relations For Foreign Key ParentKeyEntrancePermissionId
			this.HasMany(entity => entity.ChildTranslatedEntrancePermissions)
					.WithOptional(entity => entity.ParentKeyEntrancePermission)
					.HasForeignKey(entity => entity.ParentKeyEntrancePermissionId);
			#endregion
		}
		#endregion
	}
}
