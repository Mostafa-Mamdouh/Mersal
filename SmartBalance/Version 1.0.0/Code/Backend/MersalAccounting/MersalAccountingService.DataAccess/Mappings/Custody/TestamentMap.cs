using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.DataAccess.Mappings
{
    public class TestamentMap : EntityTypeConfiguration<Testament>
    {
        public TestamentMap()
        {
            #region Configure Relations For Foreign Key ParentKeyTestamentId
            this.HasMany(entity => entity.ChildTranslatedCustodies)
                    .WithOptional(entity => entity.ParentKeyTestament)
                    .HasForeignKey(entity => entity.ParentKeyTestamentId);
            #endregion
        }
    }
}
