#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Entities.Entity;
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
	/// Bank, and this lite model 
	/// do not contains a children 
	/// relations for speeding up the 
	/// retrivement process.
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class PaymentMovmentLightViewModel : BaseViewModel
	{
		#region Properties

		#region IEntityIdentity<T>
		public long Id { get; set; }
		#endregion

		#region IPostingSignature
		public bool IsPosted { get; set; }
		public DateTime? PostingDate { get; set; }
		public long? PostedByUserId { get; set; }
		#endregion

		public DateTime Date { get; set; }
		public string Description { get; set; }

		#region relations
		//sources

		public long? VendorId { get; set; }
		public virtual Vendor Vendor { get; set; }

		public long? AccountChartId { get; set; }
		public virtual MersalAccountingService.Entities.Entity.AccountChart AccountChart { get; set; }

		public long DelegateManId { get; set; }
		public virtual DelegateMan DelegateMan { get; set; }

		public int? BranchId { get; set; }
		public virtual Branch Branch { get; set; }
		#endregion 

		#endregion
	}
}
