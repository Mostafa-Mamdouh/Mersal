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
	public class AssetCategoryMap : EntityTypeConfiguration<AssetCategory>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// AssetCategoryMap.
		/// </summary>
		public AssetCategoryMap()
		{
			#region Configure Relations For Foreign Key ParentKeyAssetCategoryId
			this.HasMany(entity => entity.ChildTranslatedAssetCategorys)
					.WithOptional(entity => entity.ParentKeyAssetCategory)
					.HasForeignKey(entity => entity.ParentKeyAssetCategoryId);
			#endregion
		}
		#endregion
	}
}
