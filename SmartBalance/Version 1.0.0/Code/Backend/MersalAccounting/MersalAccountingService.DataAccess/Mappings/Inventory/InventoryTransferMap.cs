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
	public class InventoryTransferMap : EntityTypeConfiguration<InventoryTransfer>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// InventoryTransferMap.
		/// </summary>
		public InventoryTransferMap()
		{
			#region Configure Relations For Foreign Key ParentKeyInventoryTransferId
			this.HasMany(entity => entity.ChildTranslatedInventoryTransfers)
					.WithOptional(entity => entity.ParentKeyInventoryTransfer)
					.HasForeignKey(entity => entity.ParentKeyInventoryTransferId);
			#endregion
		}
		#endregion
	}
}
