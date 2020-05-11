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
	public class ExitPermissionMap : EntityTypeConfiguration<ExitPermission>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// ExitPermissionMap.
		/// </summary>
		public ExitPermissionMap()
		{
			#region Configure Relations For Foreign Key ParentKeyExitPermissionId
			this.HasMany(entity => entity.ChildTranslatedExitPermissions)
					.WithOptional(entity => entity.ParentKeyExitPermission)
					.HasForeignKey(entity => entity.ParentKeyExitPermissionId);
			#endregion
		}
		#endregion
	}
}
