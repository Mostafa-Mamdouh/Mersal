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
	public class ProductTypeMap : EntityTypeConfiguration<ProductType>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// ProductTypeMap.
		/// </summary>
		public ProductTypeMap()
		{
			#region Configure Relations For Foreign Key ParentKeyProductTypeId
			this.HasMany(entity => entity.ChildTranslatedProductTypes)
					.WithOptional(entity => entity.ParentKeyProductType)
					.HasForeignKey(entity => entity.ParentKeyProductTypeId);
			#endregion
		}
		#endregion
	}
}
