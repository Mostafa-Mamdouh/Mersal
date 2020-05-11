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
    public class AssetLocationViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ExpenseTypeViewModel.
        /// </summary>
        public AssetLocationViewModel()
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


        public virtual long? AssetId { get; set; }
        public virtual AssetViewModel Asset { get; set; }


        public long? LocationId { get; set; }
        public virtual LocationViewModel Location { get; set; }


        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }

      

        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyAssetLocationId { get; set; }
        public virtual AssetLocationViewModel ParentKeyAssetLocation { get; set; }


        //public IList<AssetLocationViewModel> ChildTranslatedAssetLocations { get; set; }
        #endregion

        #endregion
    }
}
