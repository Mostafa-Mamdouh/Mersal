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
	public class CurrencyMap : EntityTypeConfiguration<Currency>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// CurrencyMap.
		/// </summary>
		public CurrencyMap()
		{
			#region Configure Relations For Foreign Key ParentKeyCurrencyId
			this.HasMany(entity => entity.ChildTranslatedCurrencys)
					.WithOptional(entity => entity.ParentKeyCurrency)
					.HasForeignKey(entity => entity.ParentKeyCurrencyId);
            #endregion

            #region Configure Relations For Foreign Key ParentKeyCurrencyId
            this.HasMany(entity => entity.CurrencyRates)
                    .WithOptional(entity => entity.Currency)
                    .HasForeignKey(entity => entity.CurrencyId);
            #endregion

            //#region Configure Relations For Foreign Key ParentKeyCurrencyId
            //this.HasMany(entity => entity.ChildTranslatedCurrencys)
            //        .WithOptional(entity => entity.ParentKeyCurrency)
            //        .HasForeignKey(entity => entity.ParentKeyCurrencyId);
            //#endregion
        }
        #endregion
    }
}
