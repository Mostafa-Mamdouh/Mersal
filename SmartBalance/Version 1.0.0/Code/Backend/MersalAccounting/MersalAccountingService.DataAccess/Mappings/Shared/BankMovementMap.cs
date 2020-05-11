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
	public class BankMovementMap : EntityTypeConfiguration<BankMovement>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// BankMovementMap.
		/// </summary>
		public BankMovementMap()
		{
			#region Configure Relations For Foreign Key ParentKeyBankMovementId
			this.HasMany(entity => entity.ChildTranslatedBankMovements)
					.WithOptional(entity => entity.ParentKeyBankMovement)
					.HasForeignKey(entity => entity.ParentKeyBankMovementId);
            #endregion

            #region Configure Relations For Foreign Key ParentKeyBankMovementId
            this.HasMany(entity => entity.BankMovementCostCenters)
                    .WithOptional(entity => entity.BankMovement)
                    .HasForeignKey(entity => entity.BankMovementId);
            #endregion


        }
        #endregion
    }
}
