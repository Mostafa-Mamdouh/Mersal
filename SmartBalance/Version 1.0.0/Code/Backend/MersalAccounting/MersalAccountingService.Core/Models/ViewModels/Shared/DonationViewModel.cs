#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Core.Models.ViewModels.Donation;
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
	public class DonationViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type DonationViewModel.
        /// </summary>
        public DonationViewModel()
        {

        }
        #endregion        

        #region Properties

        #region IEntityIdentity<T>
        public long Id { get; set; }
		#endregion

		#region IEntityDateTime
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreationDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? FirstModificationDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
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

        public List<long> DonatoinTypesLevel { get; set; }
        public DateTime Date { get; set; }
		public string DescriptionAR { get; set; }
		public string DescriptionEN { get; set; }
		public string Code { get; set; }


        public DateTime? ReciptDate { get; set; }

        #region relation
        public List<AddDonationCaseViewModel> Cases { get; set; }
		public List<AddDonationInventoryViewModel> Inventorys { get; set; }
		public List<AddDonationProducts> Products { get; set; }
		public List<AddDonationCostCenter> CostCenters { get; set; }

		public int BranchId { get; set; }
		public SourceType SourceType { get; set; }
		public List<long> VendorId { get; set; }
		public List<long> AccountChartId { get; set; }
		public List<long> DonatorId { get; set; }
        public long? ToBankAccountChartId { get; set; }

        public long? DonationTypeId { get; set; }

		public long? DelegateManId { get; set; }
		public string DelegateManReciptNumber { get; set; }
		//if donator is a new Donator  
		public AddDonatorViewModel Donator { get; set; }

        public long? DocumentId { get; set; }

        #endregion
        #region payment 
        public int ReceivingMethodId { get; set; }
		//props if cheque
		public string ChequeNumber { get; set; }
		//تاريخ الاستحقاق
		public DateTime? Duedate { get; set; }
		//prop if visa
		public string VisaNumber { get; set; }
		//in case of cash you need to set safe Id
		public long? SafeId { get; set; }
		//in case of Visa or Chique you need to set Bank Id
		public long? FromBankId { get; set; }
		public long? ToBankId { get; set; }
		public long? VisaBankId { get; set; }
		public bool Exchangeable { get; set; }
		//acctual Paid Amount what our Source Pay
		public decimal Amount { get; set; }
		public long CurrencyId { get; set; }
        public long? SafeAccountChartId { get; set; }
        #endregion


        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyDonationId { get; set; }
        public DonationViewModel ParentKeyDonation { get; set; }


        public IList<DonationViewModel> ChildTranslatedDonations { get; set; }
        #endregion

        #endregion
    }
}
