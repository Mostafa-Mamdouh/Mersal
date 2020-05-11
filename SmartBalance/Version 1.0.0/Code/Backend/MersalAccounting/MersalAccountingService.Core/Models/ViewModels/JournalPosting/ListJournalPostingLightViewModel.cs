#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class ListJournalPostingLightViewModel : BaseViewModel
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

        #region IEntityUserSignature		
        public long? CreatedByUserId { get; set; }
        public long? FirstModifiedByUserId { get; set; }
        public long? LastModifiedByUserId { get; set; }
        #endregion

        public bool IsAutomaticPosting { get; set; }
        public bool IsBulkPosting { get; set; }
        public DateTime? ToDate { get; set; }

        public bool PostReceiptsMovement { get; set; }
        public bool PostPaymentMovement { get; set; }
        public bool PostBankMovement { get; set; }
        public bool PostPurchaseInvoice { get; set; }
        public bool PostPurchaseRebate { get; set; }
        public bool PostStoreMovement { get; set; }
        public bool PostSalesInvoice { get; set; }
        public bool PostSalesRebate { get; set; }


        public int PostedReceiptsMovementCount { get; set; }
        public int PostedPaymentMovementCount { get; set; }
        public int PostedBankMovementCount { get; set; }
        public int PostedPurchaseInvoiceCount { get; set; }
        public int PostedPurchaseRebateCount { get; set; }
        public int PostedStoreMovementCount { get; set; }
        public int PostedSalesInvoiceCount { get; set; }
        public int PostedSalesRebateCount { get; set; }   

        #endregion
    }
}
