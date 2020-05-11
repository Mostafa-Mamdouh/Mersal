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
	public class ProductPriceMap : EntityTypeConfiguration<ProductPrice>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// ProductPriceMap.
		/// </summary>
		public ProductPriceMap()
		{
			#region Configure Relations For Foreign Key ParentKeyProductPriceId
			this.HasMany(entity => entity.ChildTranslatedProductPrices)
					.WithOptional(entity => entity.ParentKeyProductPrice)
					.HasForeignKey(entity => entity.ParentKeyProductPriceId);
			#endregion
		}
		#endregion
	}
}
