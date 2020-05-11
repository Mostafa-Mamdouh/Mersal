using Framework.Common.Enums;
using Framework.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Entities.Entity
{
    public class Advance : IEntityIdentity<long>, IEntityDateTimeSignature
    {
        #region Constructors
        public Advance()
        {
            this.ChildTranslatedAdvances = new HashSet<Advance>();
        }
        #endregion

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


        public long? CostCenterId { get; set; }
        public virtual CostCenter CostCenter { get; set; }

        public string CaseCode { get; set; }

        public string Description { get; set; }

        public int? PaymentMethodId { get; set; }
        public virtual ReceivingMethod PaymentMethod { get; set; }

        public long? AccountChartId { get; set; }
        public virtual AccountChart AccountChart { get; set; }

        public long? BankId { get; set; }
        public virtual Bank Bank { get; set; }

        public long? TestamentId { get; set; }
        public virtual Testament Testament { get; set; }

        public decimal? CurrentAmount { get; set; }

        public bool? IsClosed { get; set; }

        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyAdvanceId { get; set; }
        public virtual Advance ParentKeyAdvance { get; set; }


        public virtual ICollection<Advance> ChildTranslatedAdvances { get; set; }
        #endregion
        #endregion
    }
}
