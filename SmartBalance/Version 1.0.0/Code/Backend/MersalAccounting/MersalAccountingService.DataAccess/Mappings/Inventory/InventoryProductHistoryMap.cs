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
	public class InventoryProductHistoryMap : EntityTypeConfiguration<InventoryProductHistory>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// ProductMap.
		/// </summary>
		public InventoryProductHistoryMap()
		{
			//#region Configure Relations For Foreign Key ParentKeyProductId
			//this.HasMany(entity => entity.ChildTranslatedProducts)
			//		.WithOptional(entity => entity.ParentKeyProduct)
			//		.HasForeignKey(entity => entity.ParentKeyProductId);
			//#endregion
		}
		#endregion
	}
}
