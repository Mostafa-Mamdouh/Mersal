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
    public class DepreciationRateMap : EntityTypeConfiguration<DepreciationRate>
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of type
        /// DepreciationRateMap.
        /// </summary>
        public DepreciationRateMap()
        {
            #region Configure Relations For Foreign Key ParentKeyDepreciationRateId
            this.HasMany(entity => entity.ChildTranslatedDepreciationRates)
                    .WithOptional(entity => entity.ParentKeyDepreciationRate)
                    .HasForeignKey(entity => entity.ParentKeyDepreciationRateId);
            #endregion
        }
        #endregion
    }
}
