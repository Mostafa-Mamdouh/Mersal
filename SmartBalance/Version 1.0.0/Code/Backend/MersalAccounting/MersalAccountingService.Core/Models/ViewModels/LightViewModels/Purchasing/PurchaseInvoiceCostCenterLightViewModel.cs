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
	/// PurchaseInvoiceCostCenter, and this lite model 
	/// do not contains a children 
	/// relations for speeding up the 
	/// retrivement process.
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class PurchaseInvoiceCostCenterLightViewModel : BaseViewModel
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type PurchaseInvoiceCostCenterLightViewModel.
		/// </summary>
		public PurchaseInvoiceCostCenterLightViewModel()
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
		public virtual CostCenterLightViewModel CostCenter { get; set; }

		public Nullable<long> PurchaseInvoiceId { get; set; }
		public virtual PurchaseInvoiceLightViewModel PurchaseInvoice { get; set; }

		public decimal Amount { get; set; }

		#endregion
	}
}
