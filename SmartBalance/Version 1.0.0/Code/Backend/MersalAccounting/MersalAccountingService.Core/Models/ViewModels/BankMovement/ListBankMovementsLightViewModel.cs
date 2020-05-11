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
	public class ListBankMovementsLightViewModel : BaseViewModel
	{
		#region Properties
		public long Id { get; set; }
		public string Code { get; set; }
		public decimal Amount { get; set; }
		public string BankName { get; set; }
		public long? BankId { get; set; }
		public DateTime Date { get; set; }
		public string JournalTypeName { get; set; }
		public long? JournalTypeId { get; set; }
		#endregion
	}
}
