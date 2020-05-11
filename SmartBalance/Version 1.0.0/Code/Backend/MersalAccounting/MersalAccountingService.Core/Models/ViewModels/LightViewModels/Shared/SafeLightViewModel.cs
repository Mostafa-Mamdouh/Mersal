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
	/// Safe, and this lite model 
	/// do not contains a children 
	/// relations for speeding up the 
	/// retrivement process.
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class SafeLightViewModel : BaseViewModel
	{
		#region Properties
		public int Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public DateTime? Date { get; set; }
		public string DisplyedName { get; set; }

		public long? AccountChartId { get; set; }
		public virtual AccountChartLightViewModel AccountChart { get; set; } 
		#endregion
	}
}
