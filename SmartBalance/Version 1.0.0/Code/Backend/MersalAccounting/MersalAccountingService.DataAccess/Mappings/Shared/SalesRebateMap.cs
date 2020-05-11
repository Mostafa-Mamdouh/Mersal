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
	public class SalesRebateMap : EntityTypeConfiguration<SalesRebate>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// SalesRebateMap.
		/// </summary>
		public SalesRebateMap()
		{
			#region Configure Relations For Foreign Key ParentKeySalesRebateId
			this.HasMany(entity => entity.ChildTranslatedSalesRebates)
					.WithOptional(entity => entity.ParentKeySalesRebate)
					.HasForeignKey(entity => entity.ParentKeySalesRebateId);
			#endregion
		}
		#endregion
	}
}
