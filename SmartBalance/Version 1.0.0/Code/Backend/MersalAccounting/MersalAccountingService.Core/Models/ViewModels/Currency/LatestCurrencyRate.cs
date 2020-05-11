#region Using ...
using Framework.Core.Models.ViewModels.Base;
using System.Diagnostics;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class LatestCurrencyRate : BaseViewModel
	{
		#region Properties
		public decimal NewAmount { get; set; }
		public string AppendedDescriptionAr { get; set; }
		public string AppendedDescriptionEn { get; set; }
		#endregion
	}
}
