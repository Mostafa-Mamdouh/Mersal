#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using MersalAccountingService.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Entities.Entity
{
    /// <summary>
    /// Provides a PurchaseRebate entity.
    /// </summary>
    [DebuggerDisplay("Id={Id}, Name={Name}")]
    /*
	 * @EntityDescription: 
	 * مرتد المشتريات
	 */
    public class PurchaseRebate : IEntityIdentity<long>, IEntityDateTimeSignature, IPostingSignature
    {
        #region Data Members

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type PurchaseRebate.
        /// </summary>
        public PurchaseRebate()
        {
            this.PurchaseRebateCostCenters = new HashSet<PurchaseRebateCostCenter>();
            this.PurchaseRebateProducts = new HashSet<PurchaseRebateProduct>();
            //this.ChildTranslatedPurchaseRebates = new HashSet<PurchaseRebate>();
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
        public virtual Vendor Vendor { get; set; }

        public long? InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }

        public long? PurchaseInvoiceTypeId { get; set; }
        public virtual PurchaseInvoiceType PurchaseInvoiceType { get; set; }

        public long? SafeId { get; set; }
        public virtual Safe Safe { get; set; }

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

        public virtual ICollection<PurchaseRebateCostCenter> PurchaseRebateCostCenters { get; set; }

        public virtual ICollection<PurchaseRebateProduct> PurchaseRebateProducts { get; set; }

        //public string Reason { get; set; }


        //#region Translation Functionality
        //public Language? Language { get; set; }

        //public long? ParentKeyPurchaseRebateId { get; set; }
        //public virtual PurchaseRebate ParentKeyPurchaseRebate { get; set; }


        //public virtual ICollection<PurchaseRebate> ChildTranslatedPurchaseRebates { get; set; }
        //#endregion

        #endregion
    }
}
