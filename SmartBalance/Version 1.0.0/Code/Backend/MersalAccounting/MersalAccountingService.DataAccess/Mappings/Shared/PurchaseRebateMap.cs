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
	public class PurchaseRebateMap : EntityTypeConfiguration<PurchaseRebate>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// PurchaseRebateMap.
		/// </summary>
		public PurchaseRebateMap()
		{
			//#region Configure Relations For Foreign Key ParentKeyPurchaseRebateId
			//this.HasMany(entity => entity.ChildTranslatedPurchaseRebates)
			//		.WithOptional(entity => entity.ParentKeyPurchaseRebate)
			//		.HasForeignKey(entity => entity.ParentKeyPurchaseRebateId);
			//#endregion
		}
		#endregion
	}
}
