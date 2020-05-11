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
	public class RoleMap : EntityTypeConfiguration<Role>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// RoleMap.
		/// </summary>
		public RoleMap()
		{
			#region Configure Relations For Foreign Key ParentKeyRoleId
			this.HasMany(entity => entity.ChildTranslatedRoles)
					.WithOptional(entity => entity.ParentKeyRole)
					.HasForeignKey(entity => entity.ParentKeyRoleId);
			#endregion
		}
		#endregion
	}
}
