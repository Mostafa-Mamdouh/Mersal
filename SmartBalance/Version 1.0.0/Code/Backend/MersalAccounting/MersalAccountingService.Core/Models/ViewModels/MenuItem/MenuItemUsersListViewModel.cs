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
	public class MenuItemUsersListViewModel
	{
		#region Properties
		public long MenuItemId { get; set; }
		public IList<NmaeValueViewModel> List { get; set; }
		#endregion
	}
}
