#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
#endregion

namespace MersalAccountingService.Entities.Entity
{
	/// <summary>
	/// Provides a Asset entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * الاصول
	 */
	public class Asset : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Asset.
		/// </summary>
		public Asset()
		{
			this.AssetLocations = new HashSet<AssetLocation>();
			this.Expenses = new HashSet<Expense>();
			this.Depreciations = new HashSet<Depreciation>();
			this.EfficiencyRaiseHistories = new HashSet<EfficiencyRaiseHistory>();
			this.ChildTranslatedAssets = new HashSet<Asset>();
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

		//public string Name { get; set; }
		public string BarCode { get; set; }
		public string Description { get; set; }
		public string Properties { get; set; }
		public decimal? DepreciationValue { get; set; }
		public long? Vendor { get; set; }
		public decimal? Amount { get; set; }
		public int? Quantity { get; set; }
		public DateTime? PurchaseDate { get; set; }
		public DateTime? StartDepreciationDate { get; set; }

		public string Serial { get; set; }
		public string Model { get; set; }
		public string Color { get; set; }
		public string Size { get; set; }
		public string Status { get; set; }




		public decimal? CurrentValue { get; set; }
		public DateTime? LastDepreciationDate { get; set; }


		public long? BrandId { get; set; }
		public virtual Brand Brand { get; set; }


		public long? AccountChartId { get; set; }
		public virtual AccountChart AccountChart { get; set; }


		public long? DepreciationRateId { get; set; }
		public virtual DepreciationRate DepreciationRate { get; set; }


		public long? DepreciationTypeId { get; set; }
		public virtual DepreciationType DepreciationType { get; set; }


		public long? PurchaseInvoiceId { get; set; }
		public virtual PurchaseInvoice PurchaseInvoice { get; set; }


		public virtual ICollection<Expense> Expenses { get; set; }
		public virtual ICollection<Depreciation> Depreciations { get; set; }


		public Nullable<long> AssetCategoryId { get; set; }
		public virtual AssetCategory AssetCategory { get; set; }

		public bool? IsExcluded { get; set; }
		public DateTime? ExcludedDate { get; set; }


		public bool? IsSaled { get; set; }
		public decimal? SaleAmount { get; set; }
		public DateTime? SaleDate { get; set; }


		public virtual ICollection<AssetLocation> AssetLocations { get; set; }
		public virtual ICollection<EfficiencyRaiseHistory> EfficiencyRaiseHistories { get; set; }

		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyAssetId { get; set; }
		public virtual Asset ParentKeyAsset { get; set; }


		public virtual ICollection<Asset> ChildTranslatedAssets { get; set; }
		#endregion

		#endregion
	}
}
