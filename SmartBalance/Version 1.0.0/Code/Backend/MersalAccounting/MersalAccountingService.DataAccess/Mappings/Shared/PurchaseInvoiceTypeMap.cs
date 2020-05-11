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
	public class PurchaseInvoiceTypeMap : EntityTypeConfiguration<PurchaseInvoiceType>
	{
		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public PurchaseInvoiceTypeMap()
		{
			/*
			 * to ignore property from entity 
			 * to be not created in table in 
			 * data base, example:
			 * this.Ignore(entity => entity.Name);
			 */


			this.HasMany(entity => entity.ChildTranslatedPurchaseInvoiceTypes)
				.WithOptional(entity => entity.ParentKeyPurchaseInvoiceType)
				.HasForeignKey(entity => entity.ParentKeyPurchaseInvoiceTypeId);

		}
		#endregion
	}
}
