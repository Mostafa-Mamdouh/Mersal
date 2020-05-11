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
	public class VendorViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type VendorViewModel.
        /// </summary>
        public VendorViewModel()
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

        public string Code { get; set; }
        public string Name { get; set; }
		public DateTime? Date { get; set; }

		public decimal? OpeningCredit { get; set; }
        public bool? IsDebt { get; set; }

        public long? AccountChartId { get; set; }
        public virtual AccountChartViewModel AccountChart { get; set; }

        public Nullable<long> VendorTypeId { get; set; }
		public virtual VendorTypeViewModel VendorType { get; set; }
		public string Description { get; set; }
        public string DisplyedName { get; set; }


		public string NameAr { get; set; }
		public string NameEn { get; set; }
		public string DescriptionAr { get; set; }
		public string DescriptionEn { get; set; }

        public string CommercialRegister { get; set; }

        public string TaxCard { get; set; }

        public string PayeeName { get; set; }

        public bool? ExemptFromTax { get; set; }

        public string Phone { get; set; }
        
        public string Address { get; set; }

        public string VATRegistrationCertificate { get; set; }


        public IList<PurchaseInvoiceViewModel> PurchaseInvoices { get; set; }
		public IList<PurchaseRebateViewModel> PurchaseRebates { get; set; }

		#region Translation Functionality
		public Language? Language { get; set; }

        public long? ParentKeyVendorId { get; set; }
        public VendorViewModel ParentKeyVendor { get; set; }


        public IList<VendorViewModel> ChildTranslatedVendors { get; set; }
        #endregion

        #endregion
    }
}
