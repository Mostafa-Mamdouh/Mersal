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
	public class ListBankLightViewModel : BaseViewModel
	{
		#region Properties
		public long Id { get; set; }
		public DateTime? Date { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public decimal? OpeningCredit { get; set; }
		public string Description { get; set; }
		public int AccountChartCount { get; set; }
		public int AccountChartDocumentsCount { get; set; }
		#endregion
	}
}
