#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
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
	/// Provides a lite model for entity 
	/// AccountChart, and this lite model 
	/// do not contains a children 
	/// relations for speeding up the 
	/// retrivement process.
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class AccountChartLightViewModel : BaseViewModel, ICode
	{
		#region Properties
		public long Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public string FullCode { get; set; }
		public string DisplyedName { get; set; }

		public long Value { get; set; }

		public Nullable<long> ParentAccountChartId { get; set; }
		public AccountChartLightViewModel ParentAccountChart { get; set; }


		public int? BranchId { get; set; }
		public long? CurrencyId { get; set; }
		//public CurrencyLightViewModel Currency { get; set; }

		public int AccountLevel { get; set; }
		public bool? IsFinalNode { get; set; }
		public bool? IsCreditAccount { get; set; }
		#endregion
	}
}
