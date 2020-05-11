#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Core.Models.ViewModels;
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
	public class AssetViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type AssetViewModel.
        /// </summary>
        public AssetViewModel()
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

        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }


        //public string Name { get; set; }
        public string BarCode { get; set; }
        public string Description { get; set; }
        public string Properties { get; set; }
        public decimal? DepreciationValue { get; set; }
        public DateTime StartDepreciationDate { get; set; }


        public string Serial { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Status { get; set; }

		public long? CostCenterId { get; set; }


		public long? BrandId { get; set; }
        public virtual BrandViewModel Brand { get; set; }


        public long? LocationId { get; set; }
        public string LocationName { get; set; }
        public virtual LocationViewModel Location { get; set; }


        public long? AccountChartId { get; set; }
        public virtual AccountChartViewModel AccountChart { get; set; }


        public long? DepreciationRateId { get; set; }
        public virtual DepreciationRateViewModel DepreciationRate { get; set; }


        public long? DepreciationTypeId { get; set; }
        public virtual DepreciationTypeViewModel DepreciationType { get; set; }


        public long? PurchaseInvoiceId { get; set; }
        public virtual PurchaseInvoiceViewModel PurchaseInvoice { get; set; }

        public long? Vendor { get; set; }
        public decimal? Amount { get; set; }
        public int? Quantity { get; set; }
        public DateTime? Date { get; set; }

        public decimal? RaiseAmount { get; set; }
        public DateTime? RaiseDate { get; set; }

        public Nullable<long> AssetCategoryId { get; set; }
        public virtual AssetCategoryViewModel AssetCategory { get; set; }

        public virtual IList<EffiencyRaiseHistoryViewModel> EffiencyRaiseHistoryViewModels { get; set; }
        //public virtual ICollection<AssetLocationViewModel> AssetLocations { get; set; }


        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyAssetId { get; set; }
        public virtual AssetViewModel ParentKeyAsset { get; set; }


        public IList<AssetViewModel> ChildTranslatedAssets { get; set; }
        #endregion

        #endregion
    }
}
