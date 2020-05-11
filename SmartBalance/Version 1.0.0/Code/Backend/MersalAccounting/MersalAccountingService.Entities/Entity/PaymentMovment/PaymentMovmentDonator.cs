using Framework.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Entities.Entity
{
    public class PaymentMovmentDonator : IEntityIdentity<long>, IEntityDateTimeSignature
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

        public long? PaymentMovmentnId { get; set; }
        public virtual PaymentMovment PaymentMovment { get; set; }

        public long? DonatorId { get; set; }
        public virtual Donator Donator { get; set; }


        #endregion
    }
}
