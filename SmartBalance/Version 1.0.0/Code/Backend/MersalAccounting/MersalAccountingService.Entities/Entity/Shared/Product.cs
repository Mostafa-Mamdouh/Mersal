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
	/// Provides a Product entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * الصنف
	 */
	public class Product : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Product.
		/// </summary>
		public Product()
		{
			//this.ProductPrices = new HashSet<ProductPrice>();
			this.SalesRebateProducts = new HashSet<SalesRebateProduct>();
			this.InventoryDifferences = new HashSet<InventoryDifference>();
			this.PurchaseRebateProducts = new HashSet<PurchaseRebateProduct>();
			//this.ChildTranslatedProducts = new HashSet<Product>();
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

		public long? BrandId { get; set; }
		public Brand Brand { get; set; }
		public long? InventoryId { get; set; }
		public Inventory Inventory { get; set; }
		public double? LockedCount { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		//public string Name { get; set; }
		public decimal Price { get; set; }
		public double Quantity { get; set; }
		public Nullable<decimal> Discount { get; set; }

		public decimal Expenses { get; set; }
		public decimal TotalDiscount { get; set; }
		public decimal NetValue { get; set; }

		public Nullable<long> ProductTypeId { get; set; }
		public virtual ProductType ProductType { get; set; }

		public virtual Nullable<long> MeasurementUnitId { get; set; }
		public virtual MeasurementUnit MeasurementUnit { get; set; }

		public long? AccountChartId { get; set; }
		public virtual AccountChart AccountChart { get; set; }

		//public long? PurchaseRebateId { get; set; }
		//public virtual PurchaseRebate PurchaseRebate { get; set; }

		public virtual Nullable<long> PurchaseInvoiceId { get; set; }

		public virtual PurchaseInvoice PurchaseInvoice { get; set; }

		public virtual Nullable<long> InventoryOpeningBalanceId { get; set; }
		public virtual InventoryOpeningBalance InventoryOpeningBalance { get; set; }






		//public virtual ICollection<ProductPrice> ProductPrices { get; set; }
		public virtual ICollection<SalesRebateProduct> SalesRebateProducts { get; set; }
		public virtual ICollection<InventoryDifference> InventoryDifferences { get; set; }
		public virtual ICollection<DonatorProduct> DonatorProducts { get; set; }
		public virtual ICollection<SalesBillProduct> SalesBillProducts { get; set; }
		public virtual ICollection<DonationProduct> DonationProducts { get; set; }
		public virtual ICollection<PurchaseRebateProduct> PurchaseRebateProducts { get; set; }
		//      #region Translation Functionality
		//      public Language? Language { get; set; }

		//public long? ParentKeyProductId { get; set; }
		//public virtual Product ParentKeyProduct { get; set; }


		//public virtual ICollection<Product> ChildTranslatedProducts { get; set; }
		//      #endregion

		#endregion
	}
}
