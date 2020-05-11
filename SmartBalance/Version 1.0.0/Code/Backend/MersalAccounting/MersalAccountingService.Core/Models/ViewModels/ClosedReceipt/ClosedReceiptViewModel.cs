#region using...
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
	[DebuggerDisplay("Id={Id}")]
	public class ClosedReceiptViewModel : BaseViewModel
	{
		#region Properties
		public long DocumentId { get; set; }

		public int ReceiptNumber { get; set; }
		#endregion
	}
}
