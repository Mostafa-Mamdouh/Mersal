#region Using ...
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels.Shared
{
	/// <summary>
	/// 
	/// </summary>
	public class BaseFilterViewModel
	{
		#region Properties
		public int PageSize { get; set; }
		public int PageIndex { get; set; }
		public List<FilterViewModel> Filters { get; set; }
		public List<OrderViewModel> Sort { get; set; }
		#endregion
	}
}
