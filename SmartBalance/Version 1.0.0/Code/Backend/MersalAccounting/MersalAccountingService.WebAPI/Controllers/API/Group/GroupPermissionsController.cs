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
	/// GroupPermissions Controller
	/// </summary>
	[RoutePrefix("api/GroupPermissions")]
	public class GroupPermissionsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IGroupPermissionsService _GroupPermissionsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type GroupPermissionController.
		/// </summary>
		/// <param name="GroupPermissionsService">The injected service.</param>
		public GroupPermissionsController(IGroupPermissionsService GroupPermissionsService)
		{
			this._GroupPermissionsService = GroupPermissionsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupPermissionViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupPermissions/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupPermissions/get-by-condition 
		 */
		public GenericCollectionViewModel<GroupPermissionViewModel> Get(ConditionFilter<GroupPermission, long> condition)
		{
			var result = this._GroupPermissionsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupPermissionViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupPermissions/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupPermissions/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<GroupPermissionViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._GroupPermissionsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupPermissionViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupPermissions/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupPermissions/get-light-by-condition 
		 */
		public GenericCollectionViewModel<GroupPermissionLightViewModel> GetLightModel(ConditionFilter<GroupPermission, long> condition)
		{
			var result = this._GroupPermissionsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupPermissionViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupPermissions/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupPermissions/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<GroupPermissionLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._GroupPermissionsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GroupPermissionViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupPermissions/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupPermissions/get/1 
		 */
		public GroupPermissionViewModel Get(long id)
		{
			var result = this._GroupPermissionsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupPermissions/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupPermissions/add-collection 
		 */
		public IList<GroupPermissionViewModel> Add([FromBody]IEnumerable<GroupPermissionViewModel> collection)
		{
			var result = this._GroupPermissionsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupPermissions/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupPermissions/add 
		 */
		public GroupPermissionViewModel Add([FromBody]GroupPermissionViewModel model)
		{
			var result = this._GroupPermissionsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupPermissions/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupPermissions/update-collection 
		 */
		public IList<GroupPermissionViewModel> Update([FromBody]IEnumerable<GroupPermissionViewModel> collection)
		{
			var result = this._GroupPermissionsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupPermissions/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupPermissions/update 
		 */
		public GroupPermissionViewModel Update([FromBody]GroupPermissionViewModel model)
		{
			var result = this._GroupPermissionsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupPermissions/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupPermissions/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<GroupPermissionViewModel> collection)
		{
			this._GroupPermissionsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupPermissions/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupPermissions/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._GroupPermissionsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupPermissions/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupPermissions/delete 
		 */
		public void Delete([FromBody]GroupPermissionViewModel model)
		{
			this._GroupPermissionsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/GroupPermissions/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/GroupPermissions/delete/1 
		 */
		public void Delete(long id)
		{
			this._GroupPermissionsService.Delete(id);
		}

		#endregion
	}
}
