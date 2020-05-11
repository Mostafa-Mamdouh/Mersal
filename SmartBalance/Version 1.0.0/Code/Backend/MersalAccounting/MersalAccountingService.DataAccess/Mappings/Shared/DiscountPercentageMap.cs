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
    public class DiscountPercentageMap : EntityTypeConfiguration<DiscountPercentage>
    {
        #region Constructors
        /// <summary>
		/// Initialize a new instance of type
		/// DiscountPercentageMap.
		/// </summary>
        public DiscountPercentageMap()
        {
            #region Configure Relations For Foreign Key ParentKeyPaymentMovmentId
            this.HasMany(entity => entity.PaymentMovmentNotificationDiscounts)
                    .WithOptional(entity => entity.DiscountPercentage)
                    .HasForeignKey(entity => entity.DiscountPercentageId);
            #endregion
        }
        #endregion
    }
}
