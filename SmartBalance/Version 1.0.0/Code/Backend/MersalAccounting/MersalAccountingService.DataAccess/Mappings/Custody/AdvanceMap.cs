using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.DataAccess.Mappings
{
    public class AdvanceMap : EntityTypeConfiguration<Advance>
    {
        public AdvanceMap()
        {
            #region Configure Relations For Foreign Key ParentKeyAdvanceId
            this.HasMany(entity => entity.ChildTranslatedAdvances)
                    .WithOptional(entity => entity.ParentKeyAdvance)
                    .HasForeignKey(entity => entity.ParentKeyAdvanceId);
            #endregion
        }
    }
}
