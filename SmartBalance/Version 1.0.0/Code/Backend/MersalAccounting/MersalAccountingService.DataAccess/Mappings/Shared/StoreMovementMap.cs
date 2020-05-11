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
    public class StoreMovementMap : EntityTypeConfiguration<StoreMovement>
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of type
        /// StoreMovementMap.
        /// </summary>
        public StoreMovementMap()
        {
            #region Configure Relations For Foreign Key ParentKeyStoreMovementId
            this.HasMany(entity => entity.ChildTranslatedStoreMovements)
                    .WithOptional(entity => entity.ParentKeyStoreMovement)
                    .HasForeignKey(entity => entity.ParentKeyStoreMovementId);
            #endregion
        }
        #endregion
    }
}
