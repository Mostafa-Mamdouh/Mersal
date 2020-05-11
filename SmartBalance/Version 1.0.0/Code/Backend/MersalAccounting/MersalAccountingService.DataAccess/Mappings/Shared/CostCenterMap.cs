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
	public class CostCenterMap : EntityTypeConfiguration<CostCenter>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// CostCenterMap.
		/// </summary>
		public CostCenterMap()
		{
			#region Configure Relations For Foreign Key ParentKeyCostCenterId
			this.HasMany(entity => entity.ChildTranslatedCostCenters)
					.WithOptional(entity => entity.ParentKeyCostCenter)
					.HasForeignKey(entity => entity.ParentKeyCostCenterId);
            #endregion

            #region Configure Relations For Foreign Key ParentKeyBankMovementId
            this.HasMany(entity => entity.BankMovementCostCenters)
                    .WithOptional(entity => entity.CostCenter)
                    .HasForeignKey(entity => entity.CostCenterId);
            #endregion
        }
        #endregion
    }
}
