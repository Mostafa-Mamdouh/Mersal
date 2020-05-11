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
    /// ClosedMonth, and this lite model 
    /// do not contains a children 
    /// relations for speeding up the 
    /// retrivement process.
    /// </summary>
    [DebuggerDisplay("Id={Id}")]
    public class ClosedMonthLightViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ClosedMonthLightViewModel.
        /// </summary>
        public ClosedMonthLightViewModel()
        {

        }
        #endregion

        #region Properties

        #region IEntityIdentity<T>
        public long Id { get; set; }
        #endregion

        #region IEntityDateTimeSignature
        public DateTime CreationDate { get; set; }
        public DateTime? FirstModificationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        #endregion

        public byte? Month { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public bool? IsClosed { get; set; }
        public long? ClosedByUserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }      



        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyClosedMonthId { get; set; }
        public virtual ClosedMonthLightViewModel ParentKeyClosedMonth { get; set; }

        #endregion

        #endregion
    }
}
