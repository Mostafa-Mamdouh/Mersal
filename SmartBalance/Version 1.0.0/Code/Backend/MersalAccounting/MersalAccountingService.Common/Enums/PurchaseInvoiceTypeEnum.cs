#region Using ...
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Common.Enums
{
    public enum PurchaseInvoiceTypeEnum : Byte
    {
        /// <summary>
        /// كاش
        /// </summary>
        Cash = 1,
        /// <summary>
        /// آجل
        /// </summary>
        Postpone = 4,
        /// <summary>
        /// شيك
        /// </summary>
        Check = 7
    }
}
