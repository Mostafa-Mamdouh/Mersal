#region Using ...
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels.Donation
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class DonationInvoiceViewModel
	{
		#region Properties
		public long Id { get; set; }
		public string Source { get; set; }
		public string Branch { get; set; }
		public DateTime Date { get; set; }
		public DateTime CreationDate { get; set; }
		public decimal Amount { get; set; }
		public string PaymentMethod { get; set; }
		public string ReciptNumber { get; set; }
		public string DelegateMan { get; set; }
		public string DonatorName { get; set; }
		public string DonationTypeName { get; set; }

		public long? VendorId { get; set; }
		public long? AccountChartId { get; set; }
		public long? DonatorId { get; set; }
		public string Currency { get; set; }
		public string LastCurrencyExchange { get; set; }
		#endregion
	}
}
