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
	public class PurchaseRebateProductMap : EntityTypeConfiguration<PurchaseRebateProduct>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// PurchaseRebateProductMap.
		/// </summary>
		public PurchaseRebateProductMap()
		{
			//#region Configure Relations For Foreign Key ParentKeyPurchaseRebateProductId
			//this.HasMany(entity => entity.ChildTranslatedPurchaseRebateProducts)
			//		.WithOptional(entity => entity.ParentKeyPurchaseRebateProduct)
			//		.HasForeignKey(entity => entity.ParentKeyPurchaseRebateProductId);
			//#endregion
		}
		#endregion
	}
}
