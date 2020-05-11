#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Entities.Entity
{
	/// <summary>
	/// Provides a AccountChart entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Code={Code}, Name={Name}, AccountType={AccountType}")]
	/*
	 * @EntityDescription: 
	 * الدليل المحاسبى
	 */
	public class AccountChart : IEntityIdentity<long>, IEntityDateTimeSignature, ICode
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AccountChart.
		/// </summary>
		public AccountChart()
		{
			this.ChildAccountCharts = new HashSet<AccountChart>();
			this.ChildTranslatedAccountCharts = new HashSet<AccountChart>();
			this.Inventories = new HashSet<Inventory>();
			this.CostCenters = new HashSet<CostCenter>();
			//this.Banks = new HashSet<Bank>();
			this.Products = new HashSet<Product>();
			this.Donators = new HashSet<Donator>();
			this.Vendors = new HashSet<Vendor>();
			this.PaymentMovments = new HashSet<PaymentMovment>();
			this.BankMovements = new HashSet<BankMovement>();
			//this.Safes = new HashSet<Safe>();
			//this.Banks = new HashSet<Bank>();
			this.Assets = new HashSet<Asset>();
			this.Expenses = new HashSet<Expense>();
			this.BankAccountCharts = new HashSet<BankAccountChart>();
			this.SafeAccountCharts = new HashSet<SafeAccountChart>();
            //this.Safes = new HashSet<Safe>();
            //this.GeneralAccounts = new HashSet<GeneralAccount>();
            this.Advances = new HashSet<Advance>();
            this.DonationAccountCharts = new HashSet<DonationAccountChart>();
		}
		#endregion

		#region Properties

		#region IEntityIdentity<T>
		public long Id { get; set; }
		#endregion

		#region IEntityDateTime
		public DateTime CreationDate { get; set; }
		public DateTime? FirstModificationDate { get; set; }
		public DateTime? LastModificationDate { get; set; }
		#endregion

		public string Name { get; set; }
		public string Description { get; set; }

		public int? AccountLevel { get; set; }
		public string Code { get; set; }
		public string FullCode { get; set; }
		public DateTime? Date { get; set; }
		public decimal? OpeningCredit { get; set; }
		public bool? IsDebt { get; set; }
		public bool? IsFinalNode { get; set; }
		public decimal? CurrentDebitBalance { get; set; }
		public decimal? CurrentCreditBalance { get; set; }

		public bool? IsCreditAccount { get; set; }


		public int? BranchId { get; set; }
		public Branch Branch { get; set; }


		public long? CurrencyId { get; set; }
		public Currency Currency { get; set; }


		public long? ParentAccountChartId { get; set; }
		public virtual AccountChart ParentAccountChart { get; set; }

		public virtual ICollection<AccountChart> ChildAccountCharts { get; set; }

		public virtual ICollection<Inventory> Inventories { get; set; }
		public virtual ICollection<CostCenter> CostCenters { get; set; }
		public virtual ICollection<PaymentMovment> PaymentMovments { get; set; }

		//public virtual ICollection<Safe> Safes { get; set; }
		//public virtual ICollection<Bank> Banks { get; set; }

		public virtual ICollection<Product> Products { get; set; }
		public virtual ICollection<Donator> Donators { get; set; }
		public virtual ICollection<Vendor> Vendors { get; set; }
		//public virtual ICollection<GeneralAccount> GeneralAccounts { get; set; }
		//public virtual ICollection<Safe> Safes { get; set; }
		public virtual ICollection<BankMovement> BankMovements { get; set; }
		public virtual ICollection<Asset> Assets { get; set; }
		public virtual ICollection<Expense> Expenses { get; set; }

        public virtual ICollection<Advance> Advances { get; set; }


		public long? AccountTypeId { get; set; }
		public virtual AccountType AccountType { get; set; }
		public long? AccountChartGroupId { get; set; }
		public virtual AccountChartGroup AccountChartGroup { get; set; }

		public long? AccountChartCategoryId { get; set; }
		public virtual AccountChartCategory AccountChartCategory { get; set; }


		public virtual ICollection<BankAccountChart> BankAccountCharts { get; set; }
		public virtual ICollection<SafeAccountChart> SafeAccountCharts { get; set; }

        public virtual ICollection<DonationAccountChart> DonationAccountCharts { get; set; }

		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyAccountChartId { get; set; }
		public virtual AccountChart ParentKeyAccountChart { get; set; }

		public virtual ICollection<AccountChart> ChildTranslatedAccountCharts { get; set; }
		#endregion

		#endregion
	}
}
