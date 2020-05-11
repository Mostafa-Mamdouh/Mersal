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
	[DebuggerDisplay("Id={Id}")]
	public class LoginViewModel
	{
		#region Properties
		public string UserName { get; set; }
		public string Password { get; set; } 
		#endregion
	}
}
