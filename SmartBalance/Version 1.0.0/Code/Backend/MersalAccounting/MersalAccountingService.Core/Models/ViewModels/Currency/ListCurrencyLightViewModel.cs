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
	[DebuggerDisplay("Id={Id}")]
	public class ListCurrencyLightViewModel : BaseViewModel
	{
		#region Properties

		public Nullable<long> Id { get; set; }

		public string Code { get; set; }

		public string NameAr { get; set; }

		public string NameEn { get; set; }

		public string Symbol { get; set; }

		public string DescriptionAr { get; set; }

		public string DescriptionEn { get; set; }

		public decimal Price { get; set; }

		#endregion
	}
}
