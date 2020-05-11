#region Using ..
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
	public class AddDonatorViewModel
	{
		#region Properties
		public string Name { get; set; }
		public string Phone { get; set; }
		public long AccountChartId { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		#endregion
	}
}
