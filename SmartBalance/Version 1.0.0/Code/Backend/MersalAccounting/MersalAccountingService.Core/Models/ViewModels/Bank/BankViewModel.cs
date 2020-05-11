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
	public class BankViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type BankViewModel.
        /// </summary>
        public BankViewModel()
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

        public DateTime? Date { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public string DisplyedName { get; set; }

        public decimal? OpeningCredit { get; set; }
        public bool? IsDebt { get; set; }



        public long? AccountChartId { get; set; }
        public virtual AccountChartViewModel AccountChart { get; set; }


        public IList<DonationViewModel> DonationsfromBanks { get; set; }
        public IList<DonationViewModel> DonationstoBanks { get; set; }

        public IList<PaymentMovmentViewModel> PaymentMovments { get; set; }

        public IList<BankMovementViewModel> BankMovements { get; set; }
        public IList<BankMovementViewModel> ToBankMovement { get; set; }

        public IList<PurchaseInvoiceViewModel> VisaBanks { get; set; }

        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyBankId { get; set; }
        public BankViewModel ParentKeyBank { get; set; }


        public IList<BankViewModel> ChildTranslatedBanks { get; set; }
        #endregion

        #endregion
    }
}
