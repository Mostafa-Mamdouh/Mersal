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
	public class ListCurrencyRateLightViewModel : BaseViewModel
	{
		#region Properties

		public long Id { get; set; }

		//public string Name { get; set; }
		public DateTime? Date { get; set; }
		public decimal Price { get; set; }

		public Nullable<long> CurrencyId { get; set; }
		public string Currency { get; set; }


		public Nullable<long> ExchangeCurrencyId { get; set; }
		public string ExchangeCurrency { get; set; }
		#endregion
	}
}
