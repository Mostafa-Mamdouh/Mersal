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
	public class InventoryMap : EntityTypeConfiguration<Inventory>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// InventoryMap.
		/// </summary>
		public InventoryMap()
		{
			#region Configure Relations For Foreign Key ParentKeyInventoryId
			this.HasMany(entity => entity.ChildTranslatedInventorys)
					.WithOptional(entity => entity.ParentKeyInventory)
					.HasForeignKey(entity => entity.ParentKeyInventoryId);
			#endregion
		}
		#endregion
	}
}
