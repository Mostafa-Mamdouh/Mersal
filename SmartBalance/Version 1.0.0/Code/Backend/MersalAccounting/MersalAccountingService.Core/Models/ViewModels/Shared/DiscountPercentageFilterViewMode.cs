#region Using ...
using MersalAccountingService.Core.Models.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace MersalAccountingService.Core.Models.ViewModels
{
	/// <summary>
	/// 
	/// </summary>
    public class DiscountPercentageFilterViewModel : BaseFilterViewModel
	{
		#region Properties
		public long? Id { get; set; }
		public string Name { get; set; }
		public float? Percentage { get; set; } 
		#endregion
	}
}
