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
	public class ProductViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ProductViewModel.
        /// </summary>
        public ProductViewModel()
        {

        }
        #endregion

        #region Properties

        public virtual Nullable<long> SalesUnitId { get; set; }
        public virtual object SalesUnit { get; set; }



        #region IEntityIdentity<T>
        public long Id { get; set; }
        #endregion

        #region IEntityDateTime
        public DateTime CreationDate { get; set; }
        public DateTime? FirstModificationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        #endregion

        public long? BrandId { get; set; }
        public string BrandName { get; set; }
        public BrandViewModel Brand { get; set; }
        public double? LockedCount { get; set; }
        public string Code { get; set; }
        //public string Name { get; set; }
        public decimal Price { get; set; }
        public double Quantity { get; set; }
        public Nullable<decimal> Discount { get; set; }

        public decimal Expenses { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal NetValue { get; set; }

        public Nullable<long> ProductTypeId { get; set; }
        public virtual ProductTypeViewModel ProductType { get; set; }

        public virtual Nullable<long> MeasurementUnitId { get; set; }
        public virtual MeasurementUnitViewModel MeasurementUnit { get; set; }

        public long? AccountChartId { get; set; }
        public string Description { get; set; }

        public virtual AccountChartViewModel AccountChart { get; set; }

        //public long? PurchaseRebateId { get; set; }
        //public virtual PurchaseRebate PurchaseRebate { get; set; }

        public virtual Nullable<long> PurchaseInvoiceId { get; set; }

        public virtual PurchaseInvoiceViewModel PurchaseInvoice { get; set; }

        //public virtual ICollection<ProductPrice> ProductPrices { get; set; }
        public IList<SalesRebateProductViewModel> SalesRebateProducts { get; set; }
        public IList<InventoryDifferenceViewModel> InventoryDifferences { get; set; }
		//public IList<DonatorProduct> DonatorProducts { get; set; }
		public IList<SalesBillProductViewModel> SalesBillProducts { get; set; }
		//public IList<DonationProduct> DonationProducts { get; set; }
		//public IList<PurchaseRebateProductViewModel> PurchaseRebateProducts { get; set; }

		#endregion
	}
}
