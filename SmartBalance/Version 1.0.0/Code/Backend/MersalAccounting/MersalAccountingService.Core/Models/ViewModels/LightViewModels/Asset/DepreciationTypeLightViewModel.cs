#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Common.Enums;
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
    /// DepreciationType, and this lite model 
    /// do not contains a children 
    /// relations for speeding up the 
    /// retrivement process.
    /// </summary>
    [DebuggerDisplay("Id={Id}")]
    public class DepreciationTypeLightViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type DepreciationTypeLightViewModel.
        /// </summary>
        public DepreciationTypeLightViewModel()
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

        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DepreciationTypeCodeEnum? DepreciationTypeCode { get; set; }
        public string DisplyedName { get; set; }



        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyDepreciationTypeId { get; set; }
        public virtual DepreciationTypeLightViewModel ParentKeyDepreciationType { get; set; }

     
        #endregion

        #endregion
    }
}
