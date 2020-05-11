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
	public class SafeMap : EntityTypeConfiguration<Safe>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// SafeMap.
		/// </summary>
		public SafeMap()
		{
            #region Configure Relations For SafeAccountCharts
            //this.HasMany(entity => entity.SafeAccountCharts)
            //        .WithOptional(entity => entity.Safe)
            //        .HasForeignKey(entity => entity.SafeId);
            #endregion
        }
        #endregion
    }
}
