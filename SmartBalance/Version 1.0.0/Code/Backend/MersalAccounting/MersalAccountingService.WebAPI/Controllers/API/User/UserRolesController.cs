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
	/// UserRoles Controller
	/// </summary>
	[RoutePrefix("api/UserRoles")]
	public class UserRolesController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IUserRolesService _UserRolesService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type UserRoleController.
		/// </summary>
		/// <param name="UserRolesService">The injected service.</param>
		public UserRolesController(IUserRolesService UserRolesService)
		{
			this._UserRolesService = UserRolesService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of UserRoleViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserRoles/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserRoles/get-by-condition 
		 */
		public GenericCollectionViewModel<UserRoleViewModel> Get(ConditionFilter<UserRole, long> condition)
		{
			var result = this._UserRolesService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of UserRoleViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserRoles/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserRoles/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<UserRoleViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._UserRolesService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of UserRoleViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserRoles/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserRoles/get-light-by-condition 
		 */
		public GenericCollectionViewModel<UserRoleLightViewModel> GetLightModel(ConditionFilter<UserRole, long> condition)
		{
			var result = this._UserRolesService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of UserRoleViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserRoles/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserRoles/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<UserRoleLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._UserRolesService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a UserRoleViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserRoles/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserRoles/get/1 
		 */
		public UserRoleViewModel Get(long id)
		{
			var result = this._UserRolesService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserRoles/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserRoles/add-collection 
		 */
		public IList<UserRoleViewModel> Add([FromBody]IEnumerable<UserRoleViewModel> collection)
		{
			var result = this._UserRolesService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserRoles/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserRoles/add 
		 */
		public UserRoleViewModel Add([FromBody]UserRoleViewModel model)
		{
			var result = this._UserRolesService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserRoles/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserRoles/update-collection 
		 */
		public IList<UserRoleViewModel> Update([FromBody]IEnumerable<UserRoleViewModel> collection)
		{
			var result = this._UserRolesService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserRoles/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserRoles/update 
		 */
		public UserRoleViewModel Update([FromBody]UserRoleViewModel model)
		{
			var result = this._UserRolesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserRoles/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserRoles/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<UserRoleViewModel> collection)
		{
			this._UserRolesService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserRoles/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserRoles/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._UserRolesService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserRoles/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserRoles/delete 
		 */
		public void Delete([FromBody]UserRoleViewModel model)
		{
			this._UserRolesService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserRoles/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserRoles/delete/1 
		 */
		public void Delete(long id)
		{
			this._UserRolesService.Delete(id);
		}

		#endregion
	}
}
