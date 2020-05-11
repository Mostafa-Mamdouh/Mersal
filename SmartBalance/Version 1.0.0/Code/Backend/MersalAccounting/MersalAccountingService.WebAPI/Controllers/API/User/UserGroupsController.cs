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
	/// UserGroups Controller
	/// </summary>
	[RoutePrefix("api/UserGroups")]
	public class UserGroupsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IUserGroupsService _UserGroupsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type UserGroupController.
		/// </summary>
		/// <param name="UserGroupsService">The injected service.</param>
		public UserGroupsController(IUserGroupsService UserGroupsService)
		{
			this._UserGroupsService = UserGroupsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of UserGroupViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserGroups/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserGroups/get-by-condition 
		 */
		public GenericCollectionViewModel<UserGroupViewModel> Get(ConditionFilter<UserGroup, long> condition)
		{
			var result = this._UserGroupsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of UserGroupViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserGroups/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserGroups/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<UserGroupViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._UserGroupsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of UserGroupViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserGroups/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserGroups/get-light-by-condition 
		 */
		public GenericCollectionViewModel<UserGroupLightViewModel> GetLightModel(ConditionFilter<UserGroup, long> condition)
		{
			var result = this._UserGroupsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of UserGroupViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserGroups/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserGroups/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<UserGroupLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._UserGroupsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a UserGroupViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserGroups/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserGroups/get/1 
		 */
		public UserGroupViewModel Get(long id)
		{
			var result = this._UserGroupsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserGroups/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserGroups/add-collection 
		 */
		public IList<UserGroupViewModel> Add([FromBody]IEnumerable<UserGroupViewModel> collection)
		{
			var result = this._UserGroupsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserGroups/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserGroups/add 
		 */
		public UserGroupViewModel Add([FromBody]UserGroupViewModel model)
		{
			var result = this._UserGroupsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserGroups/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserGroups/update-collection 
		 */
		public IList<UserGroupViewModel> Update([FromBody]IEnumerable<UserGroupViewModel> collection)
		{
			var result = this._UserGroupsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserGroups/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserGroups/update 
		 */
		public UserGroupViewModel Update([FromBody]UserGroupViewModel model)
		{
			var result = this._UserGroupsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserGroups/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserGroups/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<UserGroupViewModel> collection)
		{
			this._UserGroupsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserGroups/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserGroups/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._UserGroupsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserGroups/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserGroups/delete 
		 */
		public void Delete([FromBody]UserGroupViewModel model)
		{
			this._UserGroupsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserGroups/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserGroups/delete/1 
		 */
		public void Delete(long id)
		{
			this._UserGroupsService.Delete(id);
		}

		#endregion
	}
}
