#region using...
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
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
	public class FixedAssetAccountChartSettingViewModel : BaseViewModel
    {
		#region Constructors
		public FixedAssetAccountChartSettingViewModel()
		{
			this.AccountChartViewModel = new AccountChartLightViewModel();
		}
		#endregion

		#region Properties
		public long Id { get; set; }

		public string Value { get; set; }
		public AccountChartLightViewModel AccountChartViewModel { get; set; }

		public ModelStatus ModelStatus { get; set; } 
		#endregion
	}
}
