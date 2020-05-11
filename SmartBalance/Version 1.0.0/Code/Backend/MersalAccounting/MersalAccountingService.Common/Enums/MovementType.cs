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
    public enum MovementType : byte
    {
        General = 0,      
        ReceiptsMovement = 1,
        PaymentMovement = 2,
        BankMovement = 3,
        PurchaseInvoice = 4,
        PurchaseRebate = 5,
        StoreMovement = 6,
        SalesInvoice = 7,
        SalesRebate = 8,
        Testament = 9,
        Liquidation = 10
    }
}
