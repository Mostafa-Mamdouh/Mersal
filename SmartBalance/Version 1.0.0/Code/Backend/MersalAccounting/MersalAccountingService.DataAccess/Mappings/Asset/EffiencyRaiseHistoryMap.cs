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
   public class EffiencyRaiseHistoryMap : EntityTypeConfiguration<EfficiencyRaiseHistory>
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of type
        /// AssetMap.
        /// </summary>
        public EffiencyRaiseHistoryMap()
        {

            #region Configure Relations For Foreign Key AssetId
            this.HasOptional(entity => entity.Asset)
                    .WithMany(entity => entity.EfficiencyRaiseHistories)
                    .HasForeignKey(entity => entity.AssetId);
            #endregion
        }
        #endregion
    }
}
