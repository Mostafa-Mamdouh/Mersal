#region Using ...
using MersalAccountingService.Entities.Entity;
using System.Data.Entity.ModelConfiguration;
#endregion

namespace MersalAccountingService.DataAccess.Mappings
{
    public class AssetLocationMap : EntityTypeConfiguration<AssetLocation>
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of type
        /// AssetLocationMap.
        /// </summary>
        public AssetLocationMap()
        {
            #region Configure Relations For Foreign Key ParentKeyAssetLocationId
            this.HasMany(entity => entity.ChildTranslatedAssetLocations)
                    .WithOptional(entity => entity.ParentKeyAssetLocation)
                    .HasForeignKey(entity => entity.ParentKeyAssetLocationId);
            #endregion
        }
        #endregion
    }
}
