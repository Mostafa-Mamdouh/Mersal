#region Using ...
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels.PaymentMovment
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class DetailsPaymentMovmentCostCenterViewModel
	{
		#region Properties
		public long Id { get; set; }
		public string Name { get; set; }
		public decimal Amount { get; set; }
		#endregion
	}
}
