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
	public interface IGroupPermissionsService : IBaseService
	{
		#region Methods
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		void ThrowExceptionIfExist(GroupPermissionViewModel model);

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupPermissionViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<GroupPermissionViewModel> Get(ConditionFilter<GroupPermission, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupPermissionViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<GroupPermissionViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupPermissionLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<GroupPermissionLightViewModel> GetLightModel(ConditionFilter<GroupPermission, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupPermissionLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<GroupPermissionLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GroupPermissionViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		GroupPermissionViewModel Get(long id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		IList<GroupPermissionViewModel> Add(IEnumerable<GroupPermissionViewModel> collection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		GroupPermissionViewModel Add(GroupPermissionViewModel model);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		IList<GroupPermissionViewModel> Update(IEnumerable<GroupPermissionViewModel> collection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		GroupPermissionViewModel Update(GroupPermissionViewModel model);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		void Delete(IEnumerable<GroupPermissionViewModel> collection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		void Delete(IEnumerable<long> collection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		void Delete(GroupPermissionViewModel model);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		void Delete(long id);
		#endregion
	}
}
