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
	public class BankMap : EntityTypeConfiguration<Bank>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// BankMap.
		/// </summary>
		public BankMap()
		{
			#region Configure Relations For Foreign Key ParentKeyBankId
			this.HasMany(entity => entity.ChildTranslatedBanks)
					.WithOptional(entity => entity.ParentKeyBank)
					.HasForeignKey(entity => entity.ParentKeyBankId);
            #endregion

            #region Configure Relations For Foreign Key PaymentMovmentBanks
            //this.HasMany(entity => entity.PaymentMovments)
            //        .WithOptional(entity => entity.Bank)
            //        .HasForeignKey(entity => entity.BankId);
            #endregion

            #region Configure Relations For Foreign Key DonationsFromBanks
            //this.HasMany(entity => entity.DonationsfromBanks)
            //        .WithOptional(entity => entity.Bank)
            //        .HasForeignKey(entity => entity.BankId);
            #endregion

            #region Configure Relations For Foreign Key DonationsToBanks
            //this.HasMany(entity => entity.DonationstoBanks)
            //        .WithOptional(entity => entity.ChequeToBank)
            //        .HasForeignKey(entity => entity.ChequeToBankId);
            #endregion

            #region Configure Relations For unique constraint
            //this.HasIndex(entity => entity.Code)
            //    .IsUnique();
            #endregion

        }
        #endregion
    }
}
