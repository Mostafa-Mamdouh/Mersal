using Framework.Core.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.Models.ViewModels
{
	[DebuggerDisplay("UserId={UserId}")]
	public class UserRoleListViewModel : BaseViewModel
	{
		public long UserId { get; set; }
		public IList<NmaeValueViewModel> List { get; set; }
	}
}
