#region Using ...
using Framework.Core.Models.ViewModels.Base;
using System;
using System.Diagnostics;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels.LightViewModels
{
    /// <summary>
    /// Provides a lite model for entity 
    /// UserMenuItem, and this lite model 
    /// do not contains a children 
    /// relations for speeding up the 
    /// retrivement process.
    /// </summary>
    [DebuggerDisplay("Id={Id}")]
    public class UserMenuItemLightViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type UserMenuItemLightViewModel.
        /// </summary>
        public UserMenuItemLightViewModel()
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


        public Nullable<long> UserId { get; set; }
        public virtual UserLightViewModel User { get; set; }
        public Nullable<long> MenuItemId { get; set; }
        public virtual MenuItemLightViewModel MenuItem { get; set; }

        #endregion
    }
}
