#region using...
using Framework.Core.Models.ViewModels.Base;
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
	public class DocumentFilterViewModel : BaseFilterViewModel
	{
		#region Properties
		public string DocomentNumber { get; set; }
		public string CountReceipts { get; set; }
		public string FirstNumber { get; set; }
		#endregion
	}
}

