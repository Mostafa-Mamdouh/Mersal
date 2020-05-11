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
	/// EntrancePermissions Controller
	/// </summary>
	[RoutePrefix("api/EntrancePermissions")]
	public class EntrancePermissionsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IEntrancePermissionsService _EntrancePermissionsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type EntrancePermissionController.
		/// </summary>
		/// <param name="EntrancePermissionsService">The injected service.</param>
		public EntrancePermissionsController(IEntrancePermissionsService EntrancePermissionsService)
		{
			this._EntrancePermissionsService = EntrancePermissionsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of EntrancePermissionViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/EntrancePermissions/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/EntrancePermissions/get-by-condition 
		 */
		public GenericCollectionViewModel<EntrancePermissionViewModel> Get(ConditionFilter<EntrancePermission, long> condition)
		{
			var result = this._EntrancePermissionsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of EntrancePermissionViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/EntrancePermissions/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/EntrancePermissions/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<EntrancePermissionViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._EntrancePermissionsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of EntrancePermissionViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/EntrancePermissions/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/EntrancePermissions/get-light-by-condition 
		 */
		public GenericCollectionViewModel<EntrancePermissionLightViewModel> GetLightModel(ConditionFilter<EntrancePermission, long> condition)
		{
			var result = this._EntrancePermissionsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of EntrancePermissionViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/EntrancePermissions/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/EntrancePermissions/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<EntrancePermissionLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._EntrancePermissionsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a EntrancePermissionViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/EntrancePermissions/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/EntrancePermissions/get/1 
		 */
		public EntrancePermissionViewModel Get(long id)
		{
			var result = this._EntrancePermissionsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/EntrancePermissions/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/EntrancePermissions/add-collection 
		 */
		public IList<EntrancePermissionViewModel> Add([FromBody]IEnumerable<EntrancePermissionViewModel> collection)
		{
			var result = this._EntrancePermissionsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/EntrancePermissions/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/EntrancePermissions/add 
		 */
		public EntrancePermissionViewModel Add([FromBody]EntrancePermissionViewModel model)
		{
			var result = this._EntrancePermissionsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/EntrancePermissions/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/EntrancePermissions/update-collection 
		 */
		public IList<EntrancePermissionViewModel> Update([FromBody]IEnumerable<EntrancePermissionViewModel> collection)
		{
			var result = this._EntrancePermissionsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/EntrancePermissions/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/EntrancePermissions/update 
		 */
		public EntrancePermissionViewModel Update([FromBody]EntrancePermissionViewModel model)
		{
			var result = this._EntrancePermissionsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/EntrancePermissions/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/EntrancePermissions/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<EntrancePermissionViewModel> collection)
		{
			this._EntrancePermissionsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/EntrancePermissions/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/EntrancePermissions/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._EntrancePermissionsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/EntrancePermissions/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/EntrancePermissions/delete 
		 */
		public void Delete([FromBody]EntrancePermissionViewModel model)
		{
			this._EntrancePermissionsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/EntrancePermissions/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/EntrancePermissions/delete/1 
		 */
		public void Delete(long id)
		{
			this._EntrancePermissionsService.Delete(id);
		}

		#endregion
	}
}
