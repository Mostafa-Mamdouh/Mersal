#region Using ...
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Common.Enums
{
    /// <summary>
    /// 
    /// </summary>
    public enum ReceivingMethodEnum : byte
    {
        Cash = 1,
        Cheque = 4,
        Visa = 7
    }
}
