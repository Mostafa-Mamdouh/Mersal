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
	/// 
	/// </summary>
    [DebuggerDisplay("Id={Id}")]
    public class AssetInventoryLightViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type AssetInventoryLightViewModel.
        /// </summary>
        public AssetInventoryLightViewModel()
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


        public string Description { get; set; }

        public DateTime? Date { get; set; }


        public long? LocationId { get; set; }
        public virtual LocationLightViewModel Location { get; set; }


      
        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyAssetInventoryId { get; set; }
        public virtual AssetInventoryLightViewModel ParentKeyAssetInventory { get; set; }
       
        #endregion

        #endregion
    }
}
