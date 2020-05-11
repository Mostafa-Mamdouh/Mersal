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
    public class PaymentMovmentMap : EntityTypeConfiguration<PaymentMovment>
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of type
        /// PaymentMovmentMap.
        /// </summary>
        public PaymentMovmentMap()
        {
            #region Configure Relations For Foreign Key ParentKeyPaymentMovmentId
            this.HasMany(entity => entity.ChildTranslatedPaymentMovments)
                    .WithOptional(entity => entity.ParentKeyPaymentMovment)
                    .HasForeignKey(entity => entity.ParentKeyPaymentMovmentId);
            #endregion
            #region Configure Relations For Foreign Key ParentKeyPaymentMovmentId
            this.HasMany(entity => entity.PaymentMovementDonators)
                    .WithOptional(entity => entity.PaymentMovment)
                    .HasForeignKey(entity => entity.PaymentMovementId);
            #endregion	#region Configure Relations For Foreign Key ParentKeyPaymentMovmentId
            this.HasMany(entity => entity.PaymentMovmentAccountCharts)
                   .WithOptional(entity => entity.PaymentMovment)
                    .HasForeignKey(entity => entity.PaymentMovmentId);
            #endregion
            #region Configure Relations For Foreign Key ParentKeyPaymentMovmentId
            this.HasMany(entity => entity.PaymentMovmentVendors)
                      .WithOptional(entity => entity.PaymentMovment)
                    .HasForeignKey(entity => entity.PaymentMovmentId);
            #endregion

            #region Configure Relations For Foreign Key ParentKeyPaymentMovmentId
            this.HasMany(entity => entity.PaymentMovmentNotificationDiscounts)
                      .WithOptional(entity => entity.PaymentMovment)
                    .HasForeignKey(entity => entity.PaymentMovmentId);
            #endregion


        }

    }
}
