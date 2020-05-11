#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
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
	/// Provides a Bank entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * البنوك
	 */
	public class Bank : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Bank.
		/// </summary>
		public Bank()
		{
			this.ChildTranslatedBanks = new HashSet<Bank>();
			this.DonationsfromBanks = new HashSet<Donation>();
			this.DonationstoBanks = new HashSet<Donation>();
			this.PaymentMovments = new HashSet<PaymentMovment>();
			this.BankMovements = new HashSet<BankMovement>();
			this.ToBankMovement = new HashSet<BankMovement>();
			this.VisaBanks = new HashSet<PurchaseInvoice>();
			this.BankAccountCharts = new HashSet<BankAccountChart>();
            this.Advances = new HashSet<Advance>();
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
		public string Code { get; set; }
		public string Description { get; set; }
		public DateTime? Date { get; set; }


		public decimal? OpeningCredit { get; set; }
		public bool? IsDebt { get; set; }


		//public long? AccountChartId { get; set; }
		//public virtual AccountChart AccountChart { get; set; }


		public virtual ICollection<Donation> DonationsfromBanks { get; set; }
		public virtual ICollection<Donation> DonationstoBanks { get; set; }

		public virtual ICollection<PaymentMovment> PaymentMovments { get; set; }

		public virtual ICollection<BankMovement> BankMovements { get; set; }
		public virtual ICollection<BankMovement> ToBankMovement { get; set; }

		public virtual ICollection<PurchaseInvoice> VisaBanks { get; set; }

		public virtual ICollection<BankAccountChart> BankAccountCharts { get; set; }

        public virtual ICollection<Advance> Advances { get; set; }


		//public long AccountChartId { get; set; }
		//public virtual AccountChart AccountChart { get; set; }

		#region Translation Functionality
		public Language? Language { get; set; }
		public long? ParentKeyBankId { get; set; }
		public virtual Bank ParentKeyBank { get; set; }
		public virtual ICollection<Bank> ChildTranslatedBanks { get; set; }
		#endregion

		#endregion
	}
}
