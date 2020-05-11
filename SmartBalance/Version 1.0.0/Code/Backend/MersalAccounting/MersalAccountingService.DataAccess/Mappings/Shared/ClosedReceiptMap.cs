using MersalAccountingService.Entities.Entity;
#region useing...
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.DataAccess.Mappings
{
    public class ClosedReceiptMap : EntityTypeConfiguration<ClosedReceipt>
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of type
        /// AttachmentMap.
        /// </summary>
        public ClosedReceiptMap()
        {
            
        }
        #endregion
    }
}
