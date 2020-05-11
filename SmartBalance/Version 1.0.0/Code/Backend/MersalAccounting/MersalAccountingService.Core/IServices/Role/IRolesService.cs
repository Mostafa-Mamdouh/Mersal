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
    public interface IRolesService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(RoleViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of RoleViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<RoleViewModel> Get(ConditionFilter<Role, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of RoleViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<RoleViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of RoleLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<RoleLightViewModel> GetLightModel(ConditionFilter<Role, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of RoleLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<RoleLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a RoleViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RoleViewModel Get(long id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		GenericCollectionViewModel<ListRolesLightViewModel> GetByFilter(RoleFilterViewModel model);


		IList<RoleLightViewModel> GetAllUnSelectedRolesForUser(long userId);

		RolePermissionListViewModel GetRolePermission(long roleId);
		RolePermissionListViewModel UpdateRolePermission(RolePermissionListViewModel model);



		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		IList<RoleViewModel> Add(IEnumerable<RoleViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        RoleViewModel Add(RoleViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<RoleViewModel> Update(IEnumerable<RoleViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        RoleViewModel Update(RoleViewModel model);


		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		void Delete(IEnumerable<RoleViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(RoleViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
