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
	public class PurchaseRebateCostCenterViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type PurchaseRebateCostCenterViewModel.
        /// </summary>
        public PurchaseRebateCostCenterViewModel()
        {

        }
		#endregion

		#region Properties

		#region IEntityIdentity<T>
		public long Id { get; set; }
		#endregion

		#region IEntityDateTimeSignature
		public DateTime CreationDate { get; set; }
		public DateTime? FirstModificationDate { get; set; }
		public DateTime? LastModificationDate { get; set; }
		#endregion

		public Nullable<long> CostCenterId { get; set; }
		public CostCenterViewModel CostCenter { get; set; }

		public Nullable<long> PurchaseRebateId { get; set; }
		public PurchaseRebateViewModel PurchaseRebate { get; set; }

		public decimal Amount { get; set; }

		#endregion
	}
}
