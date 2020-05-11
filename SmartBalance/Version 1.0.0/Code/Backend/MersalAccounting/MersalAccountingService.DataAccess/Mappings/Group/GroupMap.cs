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
	public class GroupMap : EntityTypeConfiguration<Group>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// GroupMap.
		/// </summary>
		public GroupMap()
		{
			#region Configure Relations For Foreign Key ParentKeyGroupId
			this.HasMany(entity => entity.ChildTranslatedGroups)
					.WithOptional(entity => entity.ParentKeyGroup)
					.HasForeignKey(entity => entity.ParentKeyGroupId);
			#endregion
		}
		#endregion
	}
}
