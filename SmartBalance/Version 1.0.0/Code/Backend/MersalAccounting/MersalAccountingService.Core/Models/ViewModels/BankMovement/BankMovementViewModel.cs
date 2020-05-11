#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Core.Models.ViewModels.JournalEntries;
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
	public class BankMovementViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type BankMovementViewModel.
        /// </summary>
        public BankMovementViewModel()
        {
            this.Cheques = new List<ChecksUnderCollectionViewModel>();
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

        public string DescriptionAr { get; set; }
		public string DescriptionEn { get; set; }
        public string ChequeNo { get; set; }

        public long? BankId { get; set; }
		public virtual BankViewModel Bank { get; set; }

        public long? BankAccountChartId { get; set; }
        public virtual AccountChartViewModel BankAccountChart { get; set; }

        public long? ToBankAccountChartId { get; set; }
        public virtual AccountChartViewModel ToBankAccountChart { get; set; }


        public long? CostCenterId { get; set; }
        public virtual CostCenterViewModel CostCenter { get; set; }

        public long? CurrencyId { get; set; }
        public virtual CurrencyViewModel Currency { get; set; }

        public long? JournalTypeId { get; set; }
		public virtual JournalTypeViewModel JournalType { get; set; }

        public long? DirectlyDonationBankId { get; set; }

        public long? ToBankId { get; set; }
		public virtual BankViewModel ToBank { get; set; }

		public long? AccountChartId { get; set; }
		public virtual AccountChartViewModel AccountChart { get; set; }

		public long? SafeId { get; set; }
		public virtual SafeViewModel Safe { get; set; }

        public List<ChecksUnderCollectionViewModel> Cheques { get; set; }
        public long? CapturePapersBankId { get; set; }

        #region Translation Functionality
        public Language? Language { get; set; }

		public long? ParentKeyBankMovementId { get; set; }
		public virtual BankMovementViewModel ParentKeyBankMovement { get; set; }


		public virtual ICollection<BankMovementViewModel> ChildTranslatedBankMovements { get; set; }
        #endregion

        public List<BankMovementCostCentersViewModel> CostCenters { get; set; }


        public AddJournalEntriesViewModel Journal { get; set; }
		#endregion
	}
}
