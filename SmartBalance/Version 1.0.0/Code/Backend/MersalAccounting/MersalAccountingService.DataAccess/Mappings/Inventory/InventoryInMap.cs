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
	public class InventoryInMap : EntityTypeConfiguration<InventoryIn>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// InventoryInMap.
		/// </summary>
		public InventoryInMap()
		{
			#region Configure Relations For Foreign Key ParentKeyInventoryInId
			this.HasMany(entity => entity.ChildTranslatedInventoryIns)
					.WithOptional(entity => entity.ParentKeyInventoryIn)
					.HasForeignKey(entity => entity.ParentKeyInventoryInId);
			#endregion
		}
		#endregion
	}
}
