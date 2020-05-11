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
	public class AccountChartMap : EntityTypeConfiguration<AccountChart>
	{
		#region Constructors
		public AccountChartMap()
		{
			#region Configure Relations For Foreign Key ParentAccountChartId
			this.HasMany(entity => entity.ChildAccountCharts)
					.WithOptional(entity => entity.ParentAccountChart)
					.HasForeignKey(entity => entity.ParentAccountChartId);
			#endregion

			#region Configure Relations For Foreign Key ParentKeyAccountChartId
			this.HasMany(entity => entity.ChildTranslatedAccountCharts)
					.WithOptional(entity => entity.ParentKeyAccountChart)
					.HasForeignKey(entity => entity.ParentKeyAccountChartId);
            #endregion

            #region Configure Relations For SafeAccountCharts
            //this.HasMany(entity => entity.SafeAccountCharts)
            //        .WithOptional(entity => entity.AccountChart)
            //        .HasForeignKey(entity => entity.AccountChartId);
            #endregion
        }
        #endregion
    }
}
