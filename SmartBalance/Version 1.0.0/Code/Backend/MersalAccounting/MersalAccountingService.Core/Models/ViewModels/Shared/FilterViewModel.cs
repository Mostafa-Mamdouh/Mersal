#region Using ...
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
	public class FilterViewModel
	{
		#region Properties
		public string Field { get; set; }
		public string Operator { get; set; }
		public string Value { get; set; }
		#endregion
	}
}
