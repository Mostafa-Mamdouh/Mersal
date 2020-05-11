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
	public class CostCenterViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type CostCenterViewModel.
        /// </summary>
        public CostCenterViewModel()
        {

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
        public DateTime? Date { get; set; }
        public string DisplyedName { get; set; }
        public string Description { get; set; }
		//public bool IsActive { get; set; }

        public decimal? OpeningCredit { get; set; }
        public bool? IsDebt { get; set; }

        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }



        #region relations
        public long? AccountChartId { get; set; }
		public AccountChartViewModel AccountChart { get; set; }


        public long? CostCenterTypeId { get; set; }
        public virtual CostCenterTypeViewModel CostCenterType { get; set; }

        //public IList<DonationCostCenterViewModel> DonationCostCenters { get; set; }
        //public IList<CostCenterBillViewModel> CostCenterBills { get; set; }
        //public IList<PaymentMovmentCostCenterViewModel> PaymentMovmentCostCenters { get; set; }

        public IList<PurchaseInvoiceCostCenterViewModel> PurchaseInvoiceCostCenters { get; set; }
		public IList<PurchaseRebateCostCenterViewModel> PurchaseRebateCostCenters { get; set; }
		#endregion

		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyCostCenterId { get; set; }
		public CostCenterViewModel ParentKeyCostCenter { get; set; }


		public IList<CostCenterViewModel> ChildTranslatedCostCenters { get; set; }
		#endregion

		#endregion

	}
}
