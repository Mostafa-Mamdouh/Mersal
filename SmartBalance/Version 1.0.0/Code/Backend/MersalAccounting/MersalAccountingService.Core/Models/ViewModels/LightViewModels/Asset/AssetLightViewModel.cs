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
	/// Asset, and this lite model 
	/// do not contains a children 
	/// relations for speeding up the 
	/// retrivement process.
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class AssetLightViewModel : BaseViewModel
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AssetLightViewModel.
		/// </summary>
		public AssetLightViewModel()
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

        //public string Name { get; set; }
        public string BarCode { get; set; }
        public string Description { get; set; }
        public string Properties { get; set; }
        public decimal? DepreciationValue { get; set; }


        public string Serial { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Status { get; set; }



        public long? BrandId { get; set; }
        public virtual BrandLightViewModel Brand { get; set; }


        public long? LocationId { get; set; }
        public virtual LocationLightViewModel Location { get; set; }


        public long? AccountChartId { get; set; }
        public virtual AccountChartLightViewModel AccountChart { get; set; }


        public long? DepreciationRateId { get; set; }
        public virtual DepreciationRateLightViewModel DepreciationRate { get; set; }


        public long? DepreciationTypeId { get; set; }
        public virtual DepreciationTypeLightViewModel DepreciationType { get; set; }


        public long? PurchaseInvoiceId { get; set; }
        public virtual PurchaseInvoiceLightViewModel PurchaseInvoice { get; set; }







        public Nullable<long> AssetCategoryId { get; set; }
        public virtual AssetCategoryLightViewModel AssetCategory { get; set; }



        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyAssetId { get; set; }
        public virtual AssetLightViewModel ParentKeyAsset { get; set; }


       
        #endregion

        #endregion
    }
}
