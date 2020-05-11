#region Using ...
using Framework.Core.Filters;
using Framework.Core.IServices.Base;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.IServices
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMenuItemsService : IBaseService
    {
        #region Methods
        IList<UserLightViewModel> GetAllUnSelectedUsersForMenuItem(long menuItemId);
		MenuItemUsersListViewModel GetMenuItemUsers(long MenuItemId);
		MenuItemUsersListViewModel UpdateMenuItemUsers(MenuItemUsersListViewModel model);


		IList<MenuItemLightViewModel> GetAllUnSelectedMenuItemsForUser(long userId);
		UserMenuItemsListViewModel GetUserMenuItems(long userId);
		UserMenuItemsListViewModel UpdateUserMenuItems(UserMenuItemsListViewModel model);





		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		void ThrowExceptionIfExist(MenuItemViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of MenuItemViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<MenuItemViewModel> Get(ConditionFilter<MenuItem, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of MenuItemViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<MenuItemViewModel> Get(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a GenericCollectionViewModel of MenuItemLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<MenuItemLightViewModel> GetLightModel(ConditionFilter<MenuItem, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of MenuItemLightViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<MenuItemLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a MenuItemViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MenuItemViewModel Get(long id);

        GenericCollectionViewModel<ListMenuItemsLightViewModel> GetByFilter(MenuItemFilterViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<MenuItemViewModel> Add(IEnumerable<MenuItemViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        MenuItemViewModel Add(MenuItemViewModel model);      


        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<MenuItemViewModel> Update(IEnumerable<MenuItemViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        MenuItemViewModel Update(MenuItemViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<MenuItemViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(MenuItemViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
