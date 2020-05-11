#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using MersalAccountingService.Common.Interfaces;
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
	/// Provides a BankMovement entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * حركة بنكية
	 */
	public class BankMovement : IEntityIdentity<long>, IEntityDateTimeSignature, IEntityUserSignature, IPostingSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type BankMovement.
		/// </summary>
		public BankMovement()
		{
			this.ChildTranslatedBankMovements = new HashSet<BankMovement>();
			this.BankMovementCostCenters = new HashSet<BankMovementCostCenters>();
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

		#region IEntityUserSignature		
		public long? CreatedByUserId { get; set; }
		public long? FirstModifiedByUserId { get; set; }
		public long? LastModifiedByUserId { get; set; }
		#endregion

		#region IPostingSignature
		public bool IsPosted { get; set; }
		public DateTime? PostingDate { get; set; }
		public long? PostedByUserId { get; set; }
		#endregion

		public string Code { get; set; }
		public Nullable<DateTime> Date { get; set; }
		public decimal Amount { get; set; }
		public string Description { get; set; }
		public string RemittanceVoucherNumber { get; set; }

		public long? BankId { get; set; }
		public virtual Bank Bank { get; set; }
		public string ChequeNo { get; set; }
		public long? BankAccountChartId { get; set; }
		public virtual AccountChart BankAccountChart { get; set; }
		public long? ToBankAccountChartId { get; set; }
		public virtual AccountChart ToBankAccountChart { get; set; }

		public long? CostCenterId { get; set; }
		public virtual CostCenter CostCenter { get; set; }

		public long? CurrencyId { get; set; }
		public virtual Currency Currency { get; set; }

		public long? JournalTypeId { get; set; }
		public virtual JournalType JournalType { get; set; }

		public long? DirectlyDonationBankId { get; set; }
		public virtual Bank DirectlyDonationBank { get; set; }

		public long? CapturePapersBankId { get; set; }
		public virtual Bank CapturePapersBank { get; set; }


		public long? ToBankId { get; set; }
		public virtual Bank ToBank { get; set; }

		public long? AccountChartId { get; set; }
		public virtual AccountChart AccountChart { get; set; }

		public long? SafeId { get; set; }
		public virtual Safe Safe { get; set; }

		public virtual ICollection<BankMovementCostCenters> BankMovementCostCenters { get; set; }



		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyBankMovementId { get; set; }
		public virtual BankMovement ParentKeyBankMovement { get; set; }


		public virtual ICollection<BankMovement> ChildTranslatedBankMovements { get; set; }
		#endregion

		#endregion
	}
}
