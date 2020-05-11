using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.DataAccess.Mappings
{
    public class DepreciationMap : EntityTypeConfiguration<Depreciation>
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of type
        /// AssetMap.
        /// </summary>
        public DepreciationMap()
        {
            //#region Configure Relations For Foreign Key ParentKeyDepreciationId
            //this.HasMany(entity => entity.ChildTranslatedDepreciation)
            //        .WithOptional(entity => entity.ParentKeyDepreciation)
            //        .HasForeignKey(entity => entity.ParentKeyDepreciationId);
            //#endregion

            #region Configure Relations For Foreign Key AssetId

            #endregion
        }
        #endregion
    }
}
