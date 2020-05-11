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
    public class AssetInventoryMap : EntityTypeConfiguration<AssetInventory>
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of type
        /// AssetMap.
        /// </summary>
        public AssetInventoryMap()
        {
            #region Configure Relations For Foreign Key ParentKeyAssetInventoryId
            this.HasMany(entity => entity.ChildTranslatedAssetInventorys)
                    .WithOptional(entity => entity.ParentKeyAssetInventory)
                    .HasForeignKey(entity => entity.ParentKeyAssetInventoryId);
            #endregion
        }
        #endregion
    }
}
