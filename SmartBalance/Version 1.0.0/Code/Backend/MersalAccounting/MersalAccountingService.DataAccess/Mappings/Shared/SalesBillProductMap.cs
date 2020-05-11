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
	public class SalesBillProductMap : EntityTypeConfiguration<SalesBillProduct>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// SalesBillProductMap.
		/// </summary>
		public SalesBillProductMap()
		{
			#region Configure Relations For Foreign Key ParentKeySalesBillProductId
			this.HasMany(entity => entity.ChildTranslatedSalesBillProducts)
					.WithOptional(entity => entity.ParentKeySalesBillProduct)
					.HasForeignKey(entity => entity.ParentKeySalesBillProductId);
			#endregion
		}
		#endregion
	}
}
