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
	public class SalesRebateProductMap : EntityTypeConfiguration<SalesRebateProduct>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// SalesRebateProductMap.
		/// </summary>
		public SalesRebateProductMap()
		{
			#region Configure Relations For Foreign Key ParentKeySalesRebateProductId
			this.HasMany(entity => entity.ChildTranslatedSalesRebateProducts)
					.WithOptional(entity => entity.ParentKeySalesRebateProduct)
					.HasForeignKey(entity => entity.ParentKeySalesRebateProductId);
			#endregion
		}
		#endregion
	}
}
