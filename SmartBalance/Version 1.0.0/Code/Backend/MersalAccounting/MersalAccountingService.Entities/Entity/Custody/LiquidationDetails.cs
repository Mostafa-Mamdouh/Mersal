using Framework.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Entities.Entity
{
    public class LiquidationDetail : IEntityIdentity<long>, IEntityDateTimeSignature
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
        public string LiquidationNumber { get; set; }

        public decimal? Amount { get; set; }

        public long? TestamentExtractionId { get; set; }
        public virtual TestamentExtraction TestamentExtraction { get; set; }

        public long? CostCenterId { get; set; }
        public virtual CostCenter CostCenter { get; set; }

        public string CaseCode { get; set; }

        public decimal? TaxDiscount { get; set; }

        public decimal? MedicineDiscount { get; set; }

        public long? AdvanceId { get; set; }

        public long? LiquidationId { get; set; }
        public virtual Liquidation Liquidation { get; set; }
        #endregion
    }
}
