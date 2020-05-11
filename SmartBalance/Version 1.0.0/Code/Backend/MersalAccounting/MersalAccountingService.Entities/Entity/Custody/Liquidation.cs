using Framework.Common.Interfaces;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Entities.Entity
{
    public class Liquidation : IEntityIdentity<long>, IEntityDateTimeSignature, IPostingSignature
    {
        public Liquidation()
        {
            this.LiquidationDetails = new HashSet<LiquidationDetail>();
        }

        #region Properties

        #region IEntityIdentity<T>
        public long Id { get; set; }
        #endregion

        #region IEntityDateTime
        public DateTime CreationDate { get; set; }
        public DateTime? FirstModificationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        #endregion

        #region IPostingSignature
        public bool IsPosted { get; set; }
        public DateTime? PostingDate { get; set; }
        public long? PostedByUserId { get; set; }
        #endregion

        public decimal TotalAmount { get; set; }

        public string Code { get; set; }

        public LiquidationTypeEnum? LiquidationType { get; set; }
        
        public virtual ICollection<LiquidationDetail> LiquidationDetails { get; set; }

        #endregion
    }
}
