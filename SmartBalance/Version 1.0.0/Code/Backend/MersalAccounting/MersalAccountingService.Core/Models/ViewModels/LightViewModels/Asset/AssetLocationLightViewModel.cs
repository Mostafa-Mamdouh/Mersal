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
    public class AssetLocationLightViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ExpenseTypeViewModel.
        /// </summary>
        public AssetLocationLightViewModel()
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
        //public string DisplyedName { get; set; }



        public virtual long? AssetId { get; set; }
        //public virtual AssetLightViewModel Asset { get; set; }


        public long? LocationId { get; set; }
        //public virtual LocationLightViewModel Location { get; set; }


        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyAssetLocationId { get; set; }
        public virtual AssetLocationLightViewModel ParentKeyAssetLocation { get; set; }

        #endregion       

        #endregion
    }
}