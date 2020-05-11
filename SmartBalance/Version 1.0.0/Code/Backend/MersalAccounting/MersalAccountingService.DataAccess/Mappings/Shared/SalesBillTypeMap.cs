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
	public class SalesBillTypeMap : EntityTypeConfiguration<SalesBillType>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// SalesBillTypeMap.
		/// </summary>
		public SalesBillTypeMap()
		{
			#region Configure Relations For Foreign Key ParentKeySalesBillTypeId
			this.HasMany(entity => entity.ChildTranslatedSalesBillTypes)
					.WithOptional(entity => entity.ParentKeySalesBillType)
					.HasForeignKey(entity => entity.ParentKeySalesBillTypeId);
			#endregion
		}
		#endregion
	}
}
