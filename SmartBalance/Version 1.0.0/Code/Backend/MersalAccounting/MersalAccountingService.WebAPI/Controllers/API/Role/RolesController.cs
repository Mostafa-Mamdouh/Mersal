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
	/// Roles Controller
	/// </summary>
	[RoutePrefix("api/Roles")]
	public class RolesController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IRolesService _RolesService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type RoleController.
		/// </summary>
		/// <param name="RolesService">The injected service.</param>
		public RolesController(IRolesService RolesService)
		{
			this._RolesService = RolesService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of RoleViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Roles/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Roles/get-by-condition 
		 */
		public GenericCollectionViewModel<RoleViewModel> Get(ConditionFilter<Role, long> condition)
		{
			var result = this._RolesService.Get(condition);
			return result;
		}


		/// <summary>
		/// Gets a GenericCollectionViewModel of RoleViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Roles/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Roles/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<RoleViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._RolesService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of RoleViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Roles/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Roles/get-light-by-condition 
		 */
		public GenericCollectionViewModel<RoleLightViewModel> GetLightModel(ConditionFilter<Role, long> condition)
		{
			var result = this._RolesService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of RoleViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Roles/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Roles/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<RoleLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._RolesService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a RoleViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		[JwtAuthentication(Permissions.RoleList)]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Roles/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Roles/get/1 
		 */
		public RoleViewModel Get(long id)
		{
			var result = this._RolesService.Get(id);
			return result;
		}


		/// <summary>
		/// Gets a GenericCollectionViewModel of ListRolesLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-with-filter")]
		[HttpPost]
		[JwtAuthentication(Permissions.RoleList)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Roles/get-with-filter
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Roles/get-with-filter 
		 */
		public GenericCollectionViewModel<ListRolesLightViewModel> GetByFilter([FromBody]RoleFilterViewModel model)
		{
			var result = this._RolesService.GetByFilter(model);
			return result;
		}


		[Route("get-all-un-selected-roles-for-user/{userId}")]
		[HttpGet]
		[JwtAuthentication(Permissions.ChangeUserRoles)]
		public IList<RoleLightViewModel> GetAllUnSelectedRolesForUser(long userId)
		{
			var result = this._RolesService.GetAllUnSelectedRolesForUser(userId);
			return result;
		}

		[Route("get-role-permissions/{roleId}")]
		[HttpGet]
		[JwtAuthentication(Permissions.ChangeRolePermisstions)]
		public RolePermissionListViewModel GetRolePermission(long roleId)
		{
			var result = this._RolesService.GetRolePermission(roleId);
			return result;
		}

		[Route("update-role-permissions")]
		[HttpPost]
		[JwtAuthentication(Permissions.ChangeRolePermisstions)]
		public RolePermissionListViewModel UpdateRolePermission([FromBody]RolePermissionListViewModel model)
		{
			var result = this._RolesService.UpdateRolePermission(model);
			return result;
		}




		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		[Route("add-collection")]
		[HttpPost]
		[JwtAuthentication(Permissions.AddRole)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Roles/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Roles/add-collection 
		 */
		public IList<RoleViewModel> Add([FromBody]IEnumerable<RoleViewModel> collection)
		{
			var result = this._RolesService.Add(collection);
			return result;
		}

		/// <summary>
		/// Add an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("add")]
		[HttpPost]
		[JwtAuthentication(Permissions.AddRole)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Roles/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Roles/add 
		 */
		public RoleViewModel Add([FromBody]RoleViewModel model)
		{
			var result = this._RolesService.Add(model);
			return result;
		}


		/// <summary>
		/// Update entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		[Route("update-collection")]
		[HttpPost]
		[JwtAuthentication(Permissions.EditRole)]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Roles/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Roles/update-collection 
		 */
		public IList<RoleViewModel> Update([FromBody]IEnumerable<RoleViewModel> collection)
		{
			var result = this._RolesService.Update(collection);
			return result;
		}

		/// <summary>
		/// Update an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("update")]
		[HttpPost]
		[JwtAuthentication(Permissions.EditRole)]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Roles/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Roles/update 
		 */
		public RoleViewModel Update([FromBody]RoleViewModel model)
		{
			var result = this._RolesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Roles/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Roles/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<RoleViewModel> collection)
		{
			this._RolesService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Roles/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Roles/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._RolesService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Roles/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Roles/delete 
		 */
		public void Delete([FromBody]RoleViewModel model)
		{
			this._RolesService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Roles/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Roles/delete/1 
		 */
		public void Delete(long id)
		{
			this._RolesService.Delete(id);
		}

		#endregion
	}
}
