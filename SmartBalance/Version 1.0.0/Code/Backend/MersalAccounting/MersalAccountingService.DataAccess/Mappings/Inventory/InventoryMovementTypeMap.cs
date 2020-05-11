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
	public class InventoryMovementTypeMap : EntityTypeConfiguration<InventoryMovementType>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// InventoryMovementTypeMap.
		/// </summary>
		public InventoryMovementTypeMap()
		{
			#region Configure Relations For Foreign Key ParentKeyInventoryMovementTypeId
			this.HasMany(entity => entity.ChildTranslatedInventoryMovementTypes)
					.WithOptional(entity => entity.ParentKeyInventoryMovementType)
					.HasForeignKey(entity => entity.ParentKeyInventoryMovementTypeId);
            #endregion

            #region Configure Relations For Foreign Key ParentInventoryMovementTypeId
            this.HasMany(entity => entity.ChildInventoryMovementTypes)
                    .WithOptional(entity => entity.ParentInventoryMovementType)
                    .HasForeignKey(entity => entity.ParentInventoryMovementTypeId);
            #endregion
        }
        #endregion
    }
}
