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

namespace MersalAccountingService.Core.Models.ViewModels
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class AccountChartViewModel : BaseViewModel, ICode
	{
        #region Properties
        public long Id { get; set; }
        public string Name { get; set; }
		public string Description { get; set; }
		public string Code { get; set; }
		public string FullCode { get; set; }

        public decimal? OpeningCredit { get; set; }
        public bool? IsDebt { get; set; }


        public int? BranchId { get; set; }
        public BranchViewModel Branch { get; set; }


        public long? CurrencyId { get; set; }
        public CurrencyViewModel Currency { get; set; }

        public Nullable<long> ParentAccountChartId { get; set; }
        public IList<AccountChartViewModel> Childs { get; set; }
        public int AccountLevel { get; set; }
        public bool? isFinalNode { get; set; }
        public bool? IsCreditAccount { get; set; }
        public decimal? CurrentDebitBalance { get; set; }
        public decimal? CurrentCreditBalance { get; set; }


        public IList<BankMovementViewModel> BankMovements { get; set; }

        public  IList<SafeViewModel> Safes { get; set; }
        public  IList<BankViewModel> Banks { get; set; }

        #endregion
    }
}
