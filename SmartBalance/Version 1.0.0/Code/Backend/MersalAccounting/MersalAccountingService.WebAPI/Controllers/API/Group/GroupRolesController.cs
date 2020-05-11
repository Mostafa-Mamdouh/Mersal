#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
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
	/// GroupRoles Controller
	/// </summary>
	[RoutePrefix("api/GroupRoles")]
	public class GroupRolesController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IGroupRolesService _GroupRolesService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type GroupRoleController.
		/// </summary>
		/// <param name="GroupRolesService">The injected service.</param>
		public GroupRolesController(IGroupRolesService GroupRolesService)
		{
			this._GroupRolesService = GroupRolesService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupRoleViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupRoles/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupRoles/get-by-condition 
		 */
		public GenericCollectionViewModel<GroupRoleViewModel> Get(ConditionFilter<GroupRole, long> condition)
		{
			var result = this._GroupRolesService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupRoleViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupRoles/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupRoles/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<GroupRoleViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._GroupRolesService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupRoleViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupRoles/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupRoles/get-light-by-condition 
		 */
		public GenericCollectionViewModel<GroupRoleLightViewModel> GetLightModel(ConditionFilter<GroupRole, long> condition)
		{
			var result = this._GroupRolesService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupRoleViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupRoles/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupRoles/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<GroupRoleLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._GroupRolesService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GroupRoleViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupRoles/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupRoles/get/1 
		 */
		public GroupRoleViewModel Get(long id)
		{
			var result = this._GroupRolesService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupRoles/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupRoles/add-collection 
		 */
		public IList<GroupRoleViewModel> Add([FromBody]IEnumerable<GroupRoleViewModel> collection)
		{
			var result = this._GroupRolesService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupRoles/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupRoles/add 
		 */
		public GroupRoleViewModel Add([FromBody]GroupRoleViewModel model)
		{
			var result = this._GroupRolesService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupRoles/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupRoles/update-collection 
		 */
		public IList<GroupRoleViewModel> Update([FromBody]IEnumerable<GroupRoleViewModel> collection)
		{
			var result = this._GroupRolesService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupRoles/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupRoles/update 
		 */
		public GroupRoleViewModel Update([FromBody]GroupRoleViewModel model)
		{
			var result = this._GroupRolesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupRoles/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupRoles/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<GroupRoleViewModel> collection)
		{
			this._GroupRolesService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupRoles/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupRoles/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._GroupRolesService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupRoles/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupRoles/delete 
		 */
		public void Delete([FromBody]GroupRoleViewModel model)
		{
			this._GroupRolesService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupRoles/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupRoles/delete/1 
		 */
		public void Delete(long id)
		{
			this._GroupRolesService.Delete(id);
		}

		#endregion
	}
}
