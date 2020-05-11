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
	[DebuggerDisplay("Id={Id}, LocationName={LocationName}, Date={Date}")]
	public class ListAssetInventorysLightViewModel : BaseViewModel
	{
		#region Properties
		public long Id { get; set; }
		public string LocationName { get; set; }
		public DateTime? Date { get; set; }
		#endregion
	}
}
