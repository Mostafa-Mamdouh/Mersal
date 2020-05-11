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
	public class InventoryMovementMap : EntityTypeConfiguration<InventoryMovement>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// InventoryMovementMap.
		/// </summary>
		public InventoryMovementMap()
		{
			#region Configure Relations For Foreign Key ParentKeyInventoryMovementId
			this.HasMany(entity => entity.ChildTranslatedInventoryMovements)
					.WithOptional(entity => entity.ParentKeyInventoryMovement)
					.HasForeignKey(entity => entity.ParentKeyInventoryMovementId);
            #endregion

            #region Configure Relations For Foreign Key InventoryMovementTypeId
            this.HasOptional(entity => entity.InventoryMovementType)
                .WithMany(entity => entity.InventoryMovements)
                .HasForeignKey(entity => entity.InventoryMovementTypeId);
            #endregion

            #region Configure Relations For Foreign Key OutgoingTypeId
            this.HasOptional(entity => entity.OutgoingType)
                .WithMany(entity => entity.OutgoingTypes)
                .HasForeignKey(entity => entity.OutgoingTypeId);
            #endregion
        }
        #endregion
    }
}
