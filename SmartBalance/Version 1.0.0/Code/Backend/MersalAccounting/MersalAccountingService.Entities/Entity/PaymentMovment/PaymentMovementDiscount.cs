using Framework.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Entities.Entity
{
    public class PaymentMovementDiscount : IEntityIdentity<long>, IEntityDateTimeSignature
    {
        #region Properties
        #region IEntityIdentity<T>
        public long Id { get; set; }
        #endregion

        #region IEntityDateTime
        public DateTime CreationDate { get; set; }
        public DateTime? FirstModificationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        #endregion

        public long PaymentMovementId { get; set; }
        public virtual PaymentMovment PaymentMovment { get; set; }

        public long? DiscountPercentageId { get; set; }
        public virtual DiscountPercentage DiscountPercentage { get; set; }

        public decimal? DiscountAmount { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public decimal? NotificationReceiptNumber { get; set; }

        #endregion
    }
}
