using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.DataAccess.Mappings
{
    public class AdvancesTypeMap : EntityTypeConfiguration<AdvancesType>
    {
        public AdvancesTypeMap()
        {
            #region Configure Relations For Foreign Key ParentKeyAdvancesTypeId
            this.HasMany(entity => entity.ChildTranslatedAdvancesTypes)
                    .WithOptional(entity => entity.ParentKeyAdvancesTypes)
                    .HasForeignKey(entity => entity.ParentKeyAdvancesTypeId);
            #endregion
        }
    }
}
