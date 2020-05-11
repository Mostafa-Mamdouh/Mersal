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
	public class PurchaseInvoiceCostCenterViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type PurchaseInvoiceCostCenterViewModel.
        /// </summary>
        public PurchaseInvoiceCostCenterViewModel()
        {

        }
        #endregion        

        #region Properties

        #region IEntityIdentity<T>
        public long Id { get; set; }
		#endregion

		#region IEntityDateTimeSignature
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreationDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? FirstModificationDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastModificationDate { get; set; }
		#endregion

		public Nullable<long> CostCenterId { get; set; }
		public virtual CostCenterViewModel CostCenter { get; set; }

		public Nullable<long> PurchaseInvoiceId { get; set; }
		public virtual PurchaseInvoiceViewModel PurchaseInvoice { get; set; }

		public decimal Amount { get; set; }

		#endregion
	}
}
