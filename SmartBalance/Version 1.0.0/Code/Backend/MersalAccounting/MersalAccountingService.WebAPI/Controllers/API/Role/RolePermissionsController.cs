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
	/// RolePermissions Controller
	/// </summary>
	[RoutePrefix("api/RolePermissions")]
	public class RolePermissionsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IRolePermissionsService _RolePermissionsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type RolePermissionController.
		/// </summary>
		/// <param name="RolePermissionsService">The injected service.</param>
		public RolePermissionsController(IRolePermissionsService RolePermissionsService)
		{
			this._RolePermissionsService = RolePermissionsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of RolePermissionViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/RolePermissions/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/RolePermissions/get-by-condition 
		 */
		public GenericCollectionViewModel<RolePermissionViewModel> Get(ConditionFilter<RolePermission, long> condition)
		{
			var result = this._RolePermissionsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of RolePermissionViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/RolePermissions/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/RolePermissions/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<RolePermissionViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._RolePermissionsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of RolePermissionViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/RolePermissions/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/RolePermissions/get-light-by-condition 
		 */
		public GenericCollectionViewModel<RolePermissionLightViewModel> GetLightModel(ConditionFilter<RolePermission, long> condition)
		{
			var result = this._RolePermissionsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of RolePermissionViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/RolePermissions/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/RolePermissions/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<RolePermissionLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._RolePermissionsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a RolePermissionViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/RolePermissions/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/RolePermissions/get/1 
		 */
		public RolePermissionViewModel Get(long id)
		{
			var result = this._RolePermissionsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/RolePermissions/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/RolePermissions/add-collection 
		 */
		public IList<RolePermissionViewModel> Add([FromBody]IEnumerable<RolePermissionViewModel> collection)
		{
			var result = this._RolePermissionsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/RolePermissions/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/RolePermissions/add 
		 */
		public RolePermissionViewModel Add([FromBody]RolePermissionViewModel model)
		{
			var result = this._RolePermissionsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/RolePermissions/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/RolePermissions/update-collection 
		 */
		public IList<RolePermissionViewModel> Update([FromBody]IEnumerable<RolePermissionViewModel> collection)
		{
			var result = this._RolePermissionsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/RolePermissions/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/RolePermissions/update 
		 */
		public RolePermissionViewModel Update([FromBody]RolePermissionViewModel model)
		{
			var result = this._RolePermissionsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/RolePermissions/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/RolePermissions/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<RolePermissionViewModel> collection)
		{
			this._RolePermissionsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/RolePermissions/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/RolePermissions/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._RolePermissionsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/RolePermissions/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/RolePermissions/delete 
		 */
		public void Delete([FromBody]RolePermissionViewModel model)
		{
			this._RolePermissionsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/RolePermissions/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/RolePermissions/delete/1 
		 */
		public void Delete(long id)
		{
			this._RolePermissionsService.Delete(id);
		}

		#endregion
	}
}
