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
	public class InventoryDifferenceMap : EntityTypeConfiguration<InventoryDifference>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// InventoryDifferenceMap.
		/// </summary>
		public InventoryDifferenceMap()
		{
			#region Configure Relations For Foreign Key ParentKeyInventoryDifferenceId
			this.HasMany(entity => entity.ChildTranslatedInventoryDifferences)
					.WithOptional(entity => entity.ParentKeyInventoryDifference)
					.HasForeignKey(entity => entity.ParentKeyInventoryDifferenceId);
			#endregion
		}
		#endregion
	}
}
