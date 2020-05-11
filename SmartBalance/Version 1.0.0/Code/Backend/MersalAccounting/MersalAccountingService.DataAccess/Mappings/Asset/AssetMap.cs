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
	public class AssetMap : EntityTypeConfiguration<Asset>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// AssetMap.
		/// </summary>
		public AssetMap()
		{
            #region Configure Relations For AssetLocations
            this.HasMany(entity => entity.AssetLocations)
                .WithOptional(entity => entity.Asset)
                .HasForeignKey(entity => entity.AssetId);
            #endregion

            #region Configure Relations For Foreign Key ParentKeyAssetId
            this.HasMany(entity => entity.ChildTranslatedAssets)
					.WithOptional(entity => entity.ParentKeyAsset)
					.HasForeignKey(entity => entity.ParentKeyAssetId);
            #endregion


            #region Configure Relations For EffiencyRaiseHistory
            this.HasMany(entity => entity.EfficiencyRaiseHistories)
                .WithOptional(entity => entity.Asset)
                .HasForeignKey(entity => entity.AssetId);
            #endregion
        }
        #endregion
    }
}
