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
	public class BranchMap : EntityTypeConfiguration<Branch>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// BranchMap.
		/// </summary>
		public BranchMap()
		{
			#region Configure Relations For Foreign Key ParentKeyBranchId
			this.HasMany(entity => entity.ChildTranslatedBranchs)
					.WithOptional(entity => entity.ParentKeyBranch)
					.HasForeignKey(entity => entity.ParentKeyBranchId);
            #endregion

            #region Configure Relations For AccountCharts
            this.HasMany(entity => entity.AccountCharts)
                    .WithOptional(entity => entity.Branch)
                    .HasForeignKey(entity => entity.BranchId);
            #endregion

            #region Configure Relations For AccountCharts
            this.HasMany(entity => entity.UserBranches)
                    .WithOptional(entity => entity.Branch)
                    .HasForeignKey(entity => entity.BranchId);
            #endregion
        }
        #endregion
    }
}
