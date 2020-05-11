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
	/// Provides a Donation entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Code={Code}, Date={Date}, Amount={Amount}, ReceivingMethod={ReceivingMethod}")]
	/*
	 * @EntityDescription: 
	 * التبرع
	 */
	public class Donation : IEntityIdentity<long>, IEntityDateTimeSignature, IEntityUserSignature, IPostingSignature
    {
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Donation.
		/// </summary>
		public Donation()
		{
			this.ChildTranslatedDonations = new HashSet<Donation>();
			this.DonationCases = new HashSet<DonationCase>();
			this.DonationProducts = new HashSet<DonationProduct>();
			this.DonationCostCenters = new HashSet<DonationCostCenter>();
			this.DonationInventorys = new HashSet<DonationInventory>();
            this.DonationVendors = new HashSet<DonationVendor>();
            this.DonationAccountCharts = new HashSet<DonationAccountChart>();
            this.DonationDonators = new HashSet<DonationDonator>();
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


        public DateTime Date { get; set; }
		public string Description { get; set; }
		public string Code { get; set; }

        public DateTime? ReciptDate { get; set; }

        #region relations
        //sources
  //      public long? DonatorId { get; set; }
		//public virtual Donator Donator { get; set; }

		public long? DonationTypeId { get; set; }
		public virtual DonationType DonationType { get; set; }

		//public long? VendorId { get; set; }
		//public virtual Vendor Vendor { get; set; }

		//public long? AccountChartId { get; set; }
		//public virtual AccountChart AccountChart { get; set; }

        public long? ToBankAccountChartId { get; set; }
        public virtual AccountChart ToBankAccountChart { get; set; }


        public long? GeneralAccountId { get; set; }
		public virtual GeneralAccount GeneralAccount { get; set; }

		public virtual ICollection<DonationInventory> DonationInventorys { get; set; }

		public virtual ICollection<DonationCase> DonationCases { get; set; }
		public virtual ICollection<DonationProduct> DonationProducts { get; set; }
		public virtual ICollection<DonationCostCenter> DonationCostCenters { get; set; }
        public virtual ICollection<DonationVendor> DonationVendors { get; set; }

        public virtual ICollection<DonationAccountChart> DonationAccountCharts { get; set; }

        public virtual ICollection<DonationDonator> DonationDonators { get; set; }

		public int? BranchId { get; set; }
		public virtual Branch Branch { get; set; }
		public long? CurrencyId { get; set; }
		public virtual Currency Currency { get; set; }

        public long? DocumentId { get; set; }
        public virtual Document Document { get; set; }

        #region Receiving Method Of Payment
        public long? DelegateManId { get; set; }
		public string DelegateManReciptNumber { get; set; }
		public virtual DelegateMan DelegateMan { get; set; }

		public int? ReceivingMethodId { get; set; }
		public virtual ReceivingMethod ReceivingMethod { get; set; }
		//public ReceivingPaymentMethod ReceivingPaymentMethod { get; set; }

		//props if cheque
		public string ChequeNumber { get; set; }
		//تاريخ الاستحقاق
		public DateTime? Duedate { get; set; }
		public long? ChequeToBankId { get; set; }
		public Bank ChequeToBank { get; set; }
		public bool Exchangeable { get; set; }
		//prop if visa
		public string VisaNumber { get; set; }

		//in case of cash you need to set safe Id
		public long? SafeId { get; set; }
		public virtual Safe Safe { get; set; }

		//in case of Visa or Chique you need to set Bank Id
		public long? BankId { get; set; }
		public virtual Bank Bank { get; set; }

        public long? SafeAccountChartId { get; set; }
        public virtual AccountChart SafeAccountChart { get; set; }


        //المبلغ المدفوع
        public decimal Amount { get; set; }
		#endregion

		#endregion

		#region Translation Functionality
		public Language? Language { get; set; }
		public long? ParentKeyDonationId { get; set; }
		public virtual Donation ParentKeyDonation { get; set; }
		public virtual ICollection<Donation> ChildTranslatedDonations { get; set; }
		#endregion

		#endregion
	}
}
