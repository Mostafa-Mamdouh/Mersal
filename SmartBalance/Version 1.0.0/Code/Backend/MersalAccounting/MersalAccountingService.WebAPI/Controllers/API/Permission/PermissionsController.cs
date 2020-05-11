#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using MersalAccountingService.WebAPI.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
#endregion

namespace MersalAccountingService.WebAPI.Controllers.API
{
	/// <summary>
	/// Permissions Controller
	/// </summary>
	[RoutePrefix("api/Permissions")]
	public class PermissionsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IPermissionsService _PermissionsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type PermissionController.
		/// </summary>
		/// <param name="PermissionsService">The injected service.</param>
		public PermissionsController(IPermissionsService PermissionsService)
		{
			this._PermissionsService = PermissionsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of PermissionViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Permissions/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Permissions/get-by-condition 
		 */
		public GenericCollectionViewModel<PermissionViewModel> Get(ConditionFilter<Permission, long> condition)
		{
			var result = this._PermissionsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PermissionViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Permissions/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Permissions/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<PermissionViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._PermissionsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PermissionViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Permissions/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Permissions/get-light-by-condition 
		 */
		public GenericCollectionViewModel<PermissionLightViewModel> GetLightModel(ConditionFilter<Permission, long> condition)
		{
			var result = this._PermissionsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PermissionViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Permissions/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Permissions/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<PermissionLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._PermissionsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a PermissionViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Permissions/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Permissions/get/1 
		 */
		public PermissionViewModel Get(long id)
		{
			var result = this._PermissionsService.Get(id);
			return result;
		}

        [Route("get-all-un-selected-permissions/{roleId}")]
        [HttpGet]
		[JwtAuthentication(Permissions.ChangeRolePermisstions)]
		public IList<PermissionLightViewModel> GetAllUnSelectedPermissions(long roleId)
        {
            var result = this._PermissionsService.GetAllUnSelectedPermissions(roleId);
            return result;
        }

		[Route("get-all-un-selected-permissions-for-user/{userId}")]
		[HttpGet]
		[JwtAuthentication(Permissions.ChangeUserPermisstions)]
		public IList<PermissionLightViewModel> GetAllUnSelectedPermissionsForUser(long userId)
		{
			var result = this._PermissionsService.GetAllUnSelectedPermissionsForUser(userId);
			return result;
		}

		[Route("get-all-un-selected-permissions-for-group/{groupId}")]
		[HttpGet]
		[JwtAuthentication(Permissions.ChangeGroupPermisstions)]
		public IList<PermissionLightViewModel> GetAllUnSelectedPermissionsForGroup(long groupId)
		{
			var result = this._PermissionsService.GetAllUnSelectedPermissionsForGroup(groupId);
			return result;
		}


		/// <summary>
		/// Gets a GenericCollectionViewModel of ListPermissionsLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-with-filter")]
		[HttpPost]
		[JwtAuthentication(Permissions.EnableDisablePermissions)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Permissions/get-with-filter
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Permissions/get-with-filter 
		 */
		public GenericCollectionViewModel<ListPermissionsLightViewModel> GetByFilter([FromBody]PermissionFilterViewModel model)
		{
			var result = this._PermissionsService.GetByFilter(model);
			return result;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		[Route("add-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Permissions/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Permissions/add-collection 
		 */
		public IList<PermissionViewModel> Add([FromBody]IEnumerable<PermissionViewModel> collection)
		{
			var result = this._PermissionsService.Add(collection);
			return result;
		}

		/// <summary>
		/// Add an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("add")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Permissions/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Permissions/add 
		 */
		public PermissionViewModel Add([FromBody]PermissionViewModel model)
		{
			var result = this._PermissionsService.Add(model);
			return result;
		}


		/// <summary>
		/// Update entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		[Route("update-collection")]
		[HttpPost]
		[JwtAuthentication(Permissions.EnableDisablePermissions)]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Permissions/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Permissions/update-collection 
		 */
		public IList<PermissionViewModel> Update([FromBody]IEnumerable<PermissionViewModel> collection)
		{
			var result = this._PermissionsService.Update(collection);
			return result;
		}

		/// <summary>
		/// Update an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("update")]
		[HttpPost]
		[JwtAuthentication(Permissions.EnableDisablePermissions)]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Permissions/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Permissions/update 
		 */
		public PermissionViewModel Update([FromBody]PermissionViewModel model)
		{
			var result = this._PermissionsService.Update(model);
			return result;
		}


		/// <summary>
		/// Delete entities.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Permissions/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Permissions/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<PermissionViewModel> collection)
		{
			this._PermissionsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Permissions/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Permissions/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._PermissionsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Permissions/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Permissions/delete 
		 */
		public void Delete([FromBody]PermissionViewModel model)
		{
			this._PermissionsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Permissions/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Permissions/delete/1 
		 */
		public void Delete(long id)
		{
			this._PermissionsService.Delete(id);
		}

		#endregion
	}
}
