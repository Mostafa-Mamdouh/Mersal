using Framework.Core.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.Models.ViewModels
{
	[DebuggerDisplay("Value={Value}, Name={Name}")]
	public class NmaeValueViewModel : BaseViewModel
	{
		public long Value { get; set; }
		public string Name { get; set; }
	}
}
