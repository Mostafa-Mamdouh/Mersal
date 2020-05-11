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
	public class InventoryOpeningBalanceMap : EntityTypeConfiguration<InventoryOpeningBalance>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// InventoryMap.
		/// </summary>
		public InventoryOpeningBalanceMap()
		{
			#region Configure Relations For Foreign Key ParentKeyInventoryId
			this.HasMany(entity => entity.ChildTranslatedInventoryOpeningBalance)
					.WithOptional(entity => entity.ParentKeyInventoryOpeningBalance)
					.HasForeignKey(entity => entity.ParentKeyInventoryOpeningBalanceId);
			#endregion
		}
		#endregion
	}
}
