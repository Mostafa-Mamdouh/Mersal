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
	public class UserMap : EntityTypeConfiguration<User>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// UserMap.
		/// </summary>
		public UserMap()
		{
			#region Configure Relations For Foreign Key ParentKeyUserId
			this.HasMany(entity => entity.ChildTranslatedUsers)
					.WithOptional(entity => entity.ParentKeyUser)
					.HasForeignKey(entity => entity.ParentKeyUserId);
            #endregion

            #region Configure Relations For AccountCharts
            this.HasMany(entity => entity.UserBranches)
                    .WithOptional(entity => entity.User)
                    .HasForeignKey(entity => entity.UserId);
            #endregion
        }
        #endregion
    }
}
