#region using ..
using Framework.Core.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels.LightViewModels
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class AssetLookupViewModel : BaseViewModel
	{
		#region Properties
		public long AssetId { get; set; }
		public string BrandName { get; set; } 
		#endregion
	}
}
