#region Using ...
using Framework.Core.Models.ViewModels.Base;
using System;
using System.Diagnostics;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("Id={Id}")]
    public class UserMenuItemViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type UserMenuItemViewModel.
        /// </summary>
        public UserMenuItemViewModel()
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
        public virtual UserViewModel User { get; set; }
        public Nullable<long> MenuItemId { get; set; }
        public virtual MenuItemViewModel MenuItem { get; set; }

        #endregion
    }
}
