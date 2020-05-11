using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.DataAccess.Mappings
{
    public class UserBranchMap : EntityTypeConfiguration<UserBranch>
    {
        #region Constructors
        public UserBranchMap()
        {
            #region Configure Relations For Foreign Key BranchId
            //this.HasRequired(entity => entity.Branch)
            //        .WithMany(entity => entity.UserBranches)
            //        .HasForeignKey(entity => entity.BranchId);
            #endregion
        }
        #endregion
    }
}
