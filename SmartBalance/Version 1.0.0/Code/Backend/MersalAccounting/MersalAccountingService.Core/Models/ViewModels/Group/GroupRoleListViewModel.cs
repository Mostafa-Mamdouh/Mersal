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
	[DebuggerDisplay("GroupId={GroupId}")]
	public class GroupRoleListViewModel : BaseViewModel
	{
		#region Properties
		public long GroupId { get; set; }
		public IList<NmaeValueViewModel> List { get; set; }
		#endregion
	}
}
