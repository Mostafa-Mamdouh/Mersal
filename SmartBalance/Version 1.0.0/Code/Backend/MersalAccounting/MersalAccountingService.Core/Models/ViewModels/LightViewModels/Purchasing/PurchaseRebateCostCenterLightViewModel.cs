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

namespace MersalAccountingService.Core.Models.ViewModels.LightViewModels
{
	/// <summary>
	/// Provides a lite model for entity 
	/// PurchaseRebateCostCenter, and this lite model 
	/// do not contains a children 
	/// relations for speeding up the 
	/// retrivement process.
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class PurchaseRebateCostCenterLightViewModel : BaseViewModel
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type PurchaseRebateCostCenterLightViewModel.
		/// </summary>
		public PurchaseRebateCostCenterLightViewModel()
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
		public virtual CostCenterLightViewModel CostCenter { get; set; }

		public Nullable<long> PurchaseRebateId { get; set; }
		public virtual PurchaseRebateLightViewModel PurchaseRebate { get; set; }

		public decimal Amount { get; set; }

		#endregion
	}
}
