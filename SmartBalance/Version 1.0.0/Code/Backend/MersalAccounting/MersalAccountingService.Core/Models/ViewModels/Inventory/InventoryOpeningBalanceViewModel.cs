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
	public class InventoryOpeningBalanceViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type PurchaseInvoiceViewModel.
        /// </summary>
        public InventoryOpeningBalanceViewModel()
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



        public string Code { get; set; }
        public string Description { get; set; }

        public Nullable<DateTime> Date { get; set; }
        public long? InventoryId { get; set; }
		public virtual InventoryViewModel Inventory { get; set; }


        public string BillNumber { get; set; }

        public virtual long? VendorId { get; set; }
        public virtual VendorViewModel Vendor { get; set; }


        public IList<InventoryOpeningBalanceCostCenterViewModel> InventoryOpeningBalanceCostCenter { get; set; }
		public IList<ProductViewModel> Products { get; set; }

		//public virtual ICollection<EntrancePermission> EntrancePermissions { get; set; }


		//#region Translation Functionality
		//public Language? Language { get; set; }

		//public long? ParentKeyPurchaseInvoiceId { get; set; }
		//public virtual PurchaseInvoice ParentKeyPurchaseInvoice { get; set; }


		//public virtual ICollection<PurchaseInvoice> ChildTranslatedPurchaseInvoices { get; set; }
		//#endregion

		#endregion
	}
}
