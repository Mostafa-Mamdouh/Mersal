#region Using ...
using Framework.Core.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels.AccountChart
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class AddAccountChartViewModel : BaseViewModel
	{
		#region Properties
		public long Id { get; set; }
		public string Code { get; set; }
		public string FullCode { get; set; }

		public string NameAR { get; set; }
		public string NameEN { get; set; }

		public string DescriptionAr { get; set; }
		public string DescriptionEn { get; set; }

		public long? AccountTypeId { get; set; }
		public DateTime? Date { get; set; }
		public decimal? OpeningCredit { get; set; }
		public bool? IsDebt { get; set; }
		public long? GroupId { get; set; }
		public long? CategoryId { get; set; }
		public long? ParentAccountChartId { get; set; }
		public bool IsFinalNode { get; set; }
		public bool? IsCreditAccount { get; set; }

		public long? CurrencyId { get; set; }

		public decimal? CurrentDebitBalance { get; set; }
		public decimal? CurrentCreditBalance { get; set; }

		public int? BranchId { get; set; }
		#endregion
	}
}
