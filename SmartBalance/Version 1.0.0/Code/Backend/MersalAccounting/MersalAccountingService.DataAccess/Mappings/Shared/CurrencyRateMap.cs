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
	public class CurrencyRateMap : EntityTypeConfiguration<CurrencyRate>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// CurrencyRateMap.
		/// </summary>
		public CurrencyRateMap()
		{
			#region Configure Relations For Foreign Key ParentKeyCurrencyRateId
			this.HasMany(entity => entity.ChildTranslatedCurrencyRates)
					.WithOptional(entity => entity.ParentKeyCurrencyRate)
					.HasForeignKey(entity => entity.ParentKeyCurrencyRateId);
            #endregion

            //#region Configure Relations For Foreign Key Currency
            //this.HasOptional(entity => entity.Currency)
            //        .WithMany(entity => entity.CurrencyRates)
            //        .HasForeignKey(entity => entity.ParentKeyCurrencyRateId);
            //#endregion

            //#region Configure Relations For Foreign Key Exchange Currency
            //this.HasOptional(entity => entity.ExchangeCurrency)
            //        .WithMany(entity => entity.CurrencyRates)
            //        .HasForeignKey(entity => entity.ParentKeyCurrencyRateId);
            //#endregion
        }
        #endregion
    }
}
