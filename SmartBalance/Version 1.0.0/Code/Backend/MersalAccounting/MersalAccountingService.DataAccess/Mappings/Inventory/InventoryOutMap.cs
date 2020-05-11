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
	public class InventoryOutMap : EntityTypeConfiguration<InventoryOut>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// InventoryOutMap.
		/// </summary>
		public InventoryOutMap()
		{
			#region Configure Relations For Foreign Key ParentKeyInventoryOutId
			this.HasMany(entity => entity.ChildTranslatedInventoryOuts)
					.WithOptional(entity => entity.ParentKeyInventoryOut)
					.HasForeignKey(entity => entity.ParentKeyInventoryOutId);
			#endregion
		}
		#endregion
	}
}
