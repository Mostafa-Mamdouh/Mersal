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
	/// Groups Controller
	/// </summary>
	[RoutePrefix("api/Groups")]
	public class GroupsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IGroupsService _GroupsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type GroupController.
		/// </summary>
		/// <param name="GroupsService">The injected service.</param>
		public GroupsController(IGroupsService GroupsService)
		{
			this._GroupsService = GroupsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Groups/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Groups/get-by-condition 
		 */
		public GenericCollectionViewModel<GroupViewModel> Get(ConditionFilter<Group, long> condition)
		{
			var result = this._GroupsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Groups/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Groups/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<GroupViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._GroupsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Groups/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Groups/get-light-by-condition 
		 */
		public GenericCollectionViewModel<GroupLightViewModel> GetLightModel(ConditionFilter<Group, long> condition)
		{
			var result = this._GroupsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Groups/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Groups/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<GroupLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._GroupsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GroupViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Groups/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Groups/get/1 
		 */
		public GroupViewModel Get(long id)
		{
			var result = this._GroupsService.Get(id);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ListGroupsLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-with-filter")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Groups/get-with-filter
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Groups/get-with-filter 
		 */
		public GenericCollectionViewModel<ListGroupsLightViewModel> GetByFilter([FromBody]GroupFilterViewModel model)
		{
			var result = this._GroupsService.GetByFilter(model);
			return result;
		}


		[Route("get-all-un-selected-groups-for-user/{userId}")]
		[HttpGet]
		[JwtAuthentication(Permissions.ChangeUserGroups)]
		public IList<GroupLightViewModel> GetAllUnSelectedGroupsForUser(long userId)
		{
			var result = this._GroupsService.GetAllUnSelectedGroupsForUser(userId);
			return result;
		}

		[Route("get-group-permissions/{groupId}")]
		[HttpGet]
		[JwtAuthentication(Permissions.ChangeGroupPermisstions)]
		public GroupPermissionListViewModel GetGroupPermission(long groupId)
		{
			var result = this._GroupsService.GetGroupPermission(groupId);
			return result;
		}

		[Route("update-group-permissions")]
		[HttpPost]
		[JwtAuthentication(Permissions.ChangeGroupPermisstions)]
		public GroupPermissionListViewModel UpdateGroupPermission([FromBody]GroupPermissionListViewModel model)
		{
			var result = this._GroupsService.UpdateGroupPermission(model);
			return result;
		}



		[Route("get-group-roles/{groupId}")]
		[HttpGet]
		[JwtAuthentication(Permissions.ChangeGroupRoles)]
		public GroupRoleListViewModel GetGroupRole(long groupId)
		{
			var result = this._GroupsService.GetGroupRole(groupId);
			return result;
		}

		[Route("update-group-roles")]
		[HttpPost]
		[JwtAuthentication(Permissions.ChangeGroupRoles)]
		public GroupRoleListViewModel UpdateGroupRole([FromBody]GroupRoleListViewModel model)
		{
			var result = this._GroupsService.UpdateGroupRole(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Groups/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Groups/add-collection 
		 */
		public IList<GroupViewModel> Add([FromBody]IEnumerable<GroupViewModel> collection)
		{
			var result = this._GroupsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Groups/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Groups/add 
		 */
		public GroupViewModel Add([FromBody]GroupViewModel model)
		{
			var result = this._GroupsService.Add(model);
			return result;
		}


		/// <summary>
		/// Update entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		[Route("update-collection")]
		[HttpPost]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Groups/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Groups/update-collection 
		 */
		public IList<GroupViewModel> Update([FromBody]IEnumerable<GroupViewModel> collection)
		{
			var result = this._GroupsService.Update(collection);
			return result;
		}

		/// <summary>
		/// Update an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("update")]
		[HttpPost]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Groups/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Groups/update 
		 */
		public GroupViewModel Update([FromBody]GroupViewModel model)
		{
			var result = this._GroupsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Groups/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Groups/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<GroupViewModel> collection)
		{
			this._GroupsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Groups/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Groups/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._GroupsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Groups/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Groups/delete 
		 */
		public void Delete([FromBody]GroupViewModel model)
		{
			this._GroupsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Groups/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Groups/delete/1 
		 */
		public void Delete(long id)
		{
			this._GroupsService.Delete(id);
		}

		#endregion
	}
}
