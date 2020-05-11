using Framework.Core.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.Models.ViewModels
{
	[DebuggerDisplay("RoleId={RoleId}")]
	public	class RolePermissionListViewModel: BaseViewModel
	{
		public long RoleId { get; set; }
		public IList<NmaeValueViewModel> List { get; set; } 
	}
}
