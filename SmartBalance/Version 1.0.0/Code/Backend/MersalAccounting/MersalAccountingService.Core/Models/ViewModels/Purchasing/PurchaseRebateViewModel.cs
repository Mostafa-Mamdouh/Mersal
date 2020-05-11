#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Core.Models.ViewModels.JournalEntries;
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
	public class PurchaseRebateViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type PurchaseRebateViewModel.
        /// </summary>
        public PurchaseRebateViewModel()
        {

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

        #region IPostingSignature
        public bool IsPosted { get; set; }
        public DateTime? PostingDate { get; set; }
        public long? PostedByUserId { get; set; }
        #endregion

        public string Code { get; set; }
        public Nullable<DateTime> Date { get; set; }

        public long? VendorId { get; set; }
        public virtual VendorViewModel Vendor { get; set; }

        public long? InventoryId { get; set; }
        public virtual InventoryViewModel Inventory { get; set; }

        public long? PurchaseInvoiceTypeId { get; set; }
        public virtual PurchaseInvoiceTypeViewModel PurchaseInvoiceType { get; set; }

        public long? SafeId { get; set; }
        public virtual SafeViewModel Safe { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal NetAmount { get; set; }

        #region payment 
        public string ChequeNumber { get; set; }
        //????? ?????????
        public DateTime? DueDate { get; set; }

        public long? FromBankId { get; set; }
        public long? ToBankId { get; set; }
        #endregion

        public IList<PurchaseRebateCostCenterViewModel> PurchaseRebateCostCenters { get; set; }

        public IList<PurchaseRebateProductViewModel> PurchaseRebateProducts { get; set; }

		//public string Reason { get; set; }      


		public AddJournalEntriesViewModel Journal { get; set; }


		#endregion
	}
}
