#region Using ...
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Common.Enums
{
    public enum JournalTypeEnum : byte
    {
        /// <summary>
        /// تحويلات بنكية
        /// </summary>
        BankTransfers = 1,
        ///// <summary>
        ///// سحب
        ///// </summary>
        //Withdrawal = 4,
        /// <summary>
        /// ايداع
        /// </summary>
        Deposit = 7,
        /// <summary>
        /// مصروفات بنكية
        /// </summary>
        BankingExpenses = 10,
        /// <summary>
        /// أوراق الدفع
        /// </summary>
        PaymentPapers = 13,
        /// <summary>
        /// أوراق القبض
        /// </summary>
        CapturePapers = 16,
        /// <summary>
        /// تبرعات مباشرة
        /// </summary>
        DirectDonations = 19,

        /// <summary>
        /// أوراق دفع مرتدة
        /// </summary>
        RepatedPaymentPapers = 22
    }
}
