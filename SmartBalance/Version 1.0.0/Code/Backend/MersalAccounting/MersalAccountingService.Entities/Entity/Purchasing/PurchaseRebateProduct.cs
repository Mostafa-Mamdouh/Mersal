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
	/// Provides a PurchaseRebateProduct entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * منتجات مرتد المشتريات
	 */
	public class PurchaseRebateProduct : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type PurchaseRebateProduct.
		/// </summary>
		public PurchaseRebateProduct()
		{
			//this.ChildTranslatedPurchaseRebateProducts = new HashSet<PurchaseRebateProduct>();
			this.SalesRebateProducts = new HashSet<SalesRebateProduct>();
			this.InventoryDifferences = new HashSet<InventoryDifference>();
			this.DonatorProducts = new HashSet<DonatorProduct>();
			this.SalesBillProducts = new HashSet<SalesBillProduct>();
			this.DonationProducts = new HashSet<DonationProduct>();
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


		public Nullable<long> ProductId { get; set; }
		public virtual Product Product { get; set; }

		public long? BrandId { get; set; }
		public Brand Brand { get; set; }

		public string Code { get; set; }
		//public string Name { get; set; }
		public decimal Price { get; set; }
		public double Quantity { get; set; }
		public Nullable<decimal> Discount { get; set; }
		public decimal InvoiceDiscount { get; set; }
		public decimal Expenses { get; set; }
		public decimal TotalDiscount { get; set; }
		public decimal NetValue { get; set; }

		public Nullable<long> ProductTypeId { get; set; }
		public virtual ProductType ProductType { get; set; }

		public virtual Nullable<long> MeasurementUnitId { get; set; }
		public virtual MeasurementUnit MeasurementUnit { get; set; }

		public long? AccountChartId { get; set; }
		public virtual AccountChart AccountChart { get; set; }

		public long? PurchaseRebateId { get; set; }
		public virtual PurchaseRebate PurchaseRebate { get; set; }


		public virtual Nullable<long> PurchaseInvoiceId { get; set; }

		public virtual PurchaseInvoice PurchaseInvoice { get; set; }


		//public virtual ICollection<ProductPrice> ProductPrices { get; set; }
		public virtual ICollection<SalesRebateProduct> SalesRebateProducts { get; set; }
		public virtual ICollection<InventoryDifference> InventoryDifferences { get; set; }
		public virtual ICollection<DonatorProduct> DonatorProducts { get; set; }
		public virtual ICollection<SalesBillProduct> SalesBillProducts { get; set; }
		public virtual ICollection<DonationProduct> DonationProducts { get; set; }


		#endregion
	}
}
