#region Using ...
using Framework.Core.Filters;
using Framework.Core.IServices.Base;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
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
    public interface IUsersService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(UserViewModel model);
		void ThrowExceptionIfExistEmail(UserViewModel model);
		void ThrowExceptionIfExistMobile(UserViewModel model);

		bool GetHasPermissionToChangePostedAccounts();

        decimal? GetMaxPaymentLimit(long userId);
        decimal? GetMaxPaymentLimitForCurrentUser();

        BranchLightViewModel GetUserBranch(long userId);
        BranchLightViewModel GetCurrentUserBranch();


        bool IsUserHassPermission(long? userId, Permissions permissionItem);
        bool IsCurrentUserHassPermission(Permissions permissionItem);



        /// <summary>
        /// Gets a GenericCollectionViewModel of UserViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<UserViewModel> Get(ConditionFilter<User, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of UserViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<UserViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of UserLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<UserLightViewModel> GetLightModel(ConditionFilter<User, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of UserLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<UserLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a UserViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserViewModel Get(long id);

		GenericCollectionViewModel<ListUsersLightViewModel> GetByFilter(UserFilterViewModel model);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		IList<UserViewModel> Add(IEnumerable<UserViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        UserViewModel Add(UserViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<UserViewModel> Update(IEnumerable<UserViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        UserViewModel Update(UserViewModel model);

		UserPermissionListViewModel GetUserPermission(long userId);
		UserPermissionListViewModel UpdateUserPermission(UserPermissionListViewModel model);

		UserRoleListViewModel GetUserRole(long userId);
		UserRoleListViewModel UpdateUserRole(UserRoleListViewModel model);

		UserGroupListViewModel GetUserGroup(long userId);
		UserGroupListViewModel UpdateUserGroup(UserGroupListViewModel model);

        UserBranchListViewModel GetUserBranchs(long userId);
        UserBranchListViewModel UpdateUserBranch(UserBranchListViewModel model);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<UserViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(UserViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);

        IList<MersalPrivilegeViewModel> GetUserPrivileges(long userId);
        IList<MersalMenuItemViewModel> GetUserMenuItems(long userId);

       // IList<PermissionViewModel> GetUserPermissions(long userId);

        UserLoggedInViewModel Login(LoginViewModel model);

        void ChangePassword(ChangePasswordViewModel model);

        void ResetPassword(long userId);
        #endregion
    }
}
