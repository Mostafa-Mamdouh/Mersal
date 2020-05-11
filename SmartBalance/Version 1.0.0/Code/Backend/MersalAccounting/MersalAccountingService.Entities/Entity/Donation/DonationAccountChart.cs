using Framework.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Entities.Entity
{
    public class DonationAccountChart : IEntityIdentity<long>, IEntityDateTimeSignature
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

        public long DonationId { get; set; }
        public virtual Donation Donation { get; set; }

        public long AccountChartId { get; set; }
        public virtual AccountChart AccountChart { get; set; }

        #endregion
    }
}
