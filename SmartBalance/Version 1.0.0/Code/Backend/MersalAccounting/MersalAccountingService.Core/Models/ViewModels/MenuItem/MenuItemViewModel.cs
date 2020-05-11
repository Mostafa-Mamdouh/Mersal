#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("Id={Id}")]
    public class MenuItemViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type MenuItemViewModel.
        /// </summary>
        public MenuItemViewModel()
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

        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }


        public string Name { get; set; }
        public string Title { get; set; }
        public string ResourceKey { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public string AreaName { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string URL { get; set; }
        public string RootUrl { get; set; }
        public string OnErrorGoToURL { get; set; }
        public Nullable<long> ApplicationId { get; set; }
        public string Icon { get; set; }
        public int? ItemOrder { get; set; }
        public bool? AllowAnonymous { get; set; }

        public Nullable<long> ParentMenuItemId { get; set; }
        public MenuItemViewModel ParentMenuItem { get; set; }


        public IList<MenuItemViewModel> ChildMenuItems { get; set; }
        //public IList<UserMenuItemViewModel> UserMenuItems { get; set; }

       
        
        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyMenuItemId { get; set; }
        public MenuItemViewModel ParentKeyMenuItem { get; set; }


        //public IList<MenuItemViewModel> ChildTranslatedMenuItems { get; set; }
        #endregion

        #endregion
    }
}
