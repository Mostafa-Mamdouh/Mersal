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
	/// Provides a Safe entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * الخزن
	 */
	public class Safe : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Safe.
		/// </summary>
		public Safe()
		{
			this.ChildTranslatedSafes = new HashSet<Safe>();
			this.Donations = new HashSet<Donation>();
			this.PaymentMovments = new HashSet<PaymentMovment>();
			this.BankMovements = new HashSet<BankMovement>();
			this.PurchaseInvoices = new HashSet<PurchaseInvoice>();
			this.PurchaseRebates = new HashSet<PurchaseRebate>();
			this.SafeAccountCharts = new HashSet<SafeAccountChart>();
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

		public int? BranchId { get; set; }
		public virtual Branch Branch { get; set; }

		//public long? AccountChartId { get; set; }
		//public virtual AccountChart AccountChart { get; set; }F

		public virtual ICollection<Donation> Donations { get; set; }
		public virtual ICollection<PaymentMovment> PaymentMovments { get; set; }
		public virtual ICollection<BankMovement> BankMovements { get; set; }
		public virtual ICollection<PurchaseInvoice> PurchaseInvoices { get; set; }
		public virtual ICollection<PurchaseRebate> PurchaseRebates { get; set; }
		public virtual ICollection<SafeAccountChart> SafeAccountCharts { get; set; }



		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeySafeId { get; set; }
		public virtual Safe ParentKeySafe { get; set; }


		public virtual ICollection<Safe> ChildTranslatedSafes { get; set; }
		#endregion

		#endregion
	}
}
