#region Using ...
using Framework.Core.Models.ViewModels.Base;
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
	[DebuggerDisplay("Id={Id}, Code={Code}, Title={Title}")]
	public class ListLocationsLightViewModel : BaseViewModel
	{
		#region Properties
		public long Id { get; set; }
		public string Code { get; set; }
		public string Title { get; set; }
		public DateTime? Date { get; set; }
		#endregion
	}
}
