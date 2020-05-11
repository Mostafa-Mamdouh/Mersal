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

namespace MersalAccountingService.Core.Models.ViewModels.LightViewModels
{
	/// <summary>
	/// Provides a lite model for entity 
	/// Product, and this lite model 
	/// do not contains a children 
	/// relations for speeding up the 
	/// retrivement process.
	/// </summary>
	[DebuggerDisplay("Id={Id}, BrandId={BrandId}, Price={Price}, Quantity={Quantity}")]
	public class ProductLightViewModel : BaseViewModel
	{
        #region Properties

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
        public BrandLightViewModel Brand { get; set; }
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
        public virtual ProductTypeLightViewModel ProductType { get; set; }

        public virtual Nullable<long> MeasurementUnitId { get; set; }
        public virtual MeasurementUnitLightViewModel MeasurementUnit { get; set; }

        public long? AccountChartId { get; set; }
        public virtual AccountChartLightViewModel AccountChart { get; set; }

        //public long? PurchaseRebateId { get; set; }
        //public virtual PurchaseRebate PurchaseRebate { get; set; }

        public virtual Nullable<long> PurchaseInvoiceId { get; set; }

        public virtual PurchaseInvoiceLightViewModel PurchaseInvoice { get; set; }
       
        #endregion
    }
}
