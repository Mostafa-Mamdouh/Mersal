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
    public class AssetInventoryDetailViewModel :  BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type AssetInventoryDetailViewModel.
        /// </summary>
        public AssetInventoryDetailViewModel()
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


        public long? AssetInventoryId { get; set; }
        public virtual AssetInventoryViewModel AssetInventory { get; set; }


        public long? BrandId { get; set; }
        public virtual BrandViewModel Brand { get; set; }


        public int? ExpectedQuantity { get; set; }
        public int? ActualQuantity { get; set; }
        public int? Difference { get; set; }
       

        #endregion
    }
}
