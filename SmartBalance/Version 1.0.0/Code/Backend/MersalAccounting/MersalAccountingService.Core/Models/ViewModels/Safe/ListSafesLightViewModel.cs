#region Using ...
using Framework.Common.Enums;
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
	public class ListSafesLightViewModel : BaseViewModel
	{
		public long Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public DateTime Date { get; set; }
		public decimal OpeningCredit { get; set; }

		//public string BankName { get; set; }
		//public long? BankId { get; set; }

		//public string JournalTypeName { get; set; }
		//public long? JournalTypeId { get; set; }
	}
}
