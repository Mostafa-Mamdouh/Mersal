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
	/// ExitPermissions Controller
	/// </summary>
	[RoutePrefix("api/ExitPermissions")]
	public class ExitPermissionsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IExitPermissionsService _ExitPermissionsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type ExitPermissionController.
		/// </summary>
		/// <param name="ExitPermissionsService">The injected service.</param>
		public ExitPermissionsController(IExitPermissionsService ExitPermissionsService)
		{
			this._ExitPermissionsService = ExitPermissionsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of ExitPermissionViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExitPermissions/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExitPermissions/get-by-condition 
		 */
		public GenericCollectionViewModel<ExitPermissionViewModel> Get(ConditionFilter<ExitPermission, long> condition)
		{
			var result = this._ExitPermissionsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ExitPermissionViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExitPermissions/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExitPermissions/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<ExitPermissionViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._ExitPermissionsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ExitPermissionViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExitPermissions/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExitPermissions/get-light-by-condition 
		 */
		public GenericCollectionViewModel<ExitPermissionLightViewModel> GetLightModel(ConditionFilter<ExitPermission, long> condition)
		{
			var result = this._ExitPermissionsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ExitPermissionViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExitPermissions/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExitPermissions/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<ExitPermissionLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._ExitPermissionsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a ExitPermissionViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExitPermissions/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExitPermissions/get/1 
		 */
		public ExitPermissionViewModel Get(long id)
		{
			var result = this._ExitPermissionsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExitPermissions/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExitPermissions/add-collection 
		 */
		public IList<ExitPermissionViewModel> Add([FromBody]IEnumerable<ExitPermissionViewModel> collection)
		{
			var result = this._ExitPermissionsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExitPermissions/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExitPermissions/add 
		 */
		public ExitPermissionViewModel Add([FromBody]ExitPermissionViewModel model)
		{
			var result = this._ExitPermissionsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExitPermissions/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExitPermissions/update-collection 
		 */
		public IList<ExitPermissionViewModel> Update([FromBody]IEnumerable<ExitPermissionViewModel> collection)
		{
			var result = this._ExitPermissionsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExitPermissions/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExitPermissions/update 
		 */
		public ExitPermissionViewModel Update([FromBody]ExitPermissionViewModel model)
		{
			var result = this._ExitPermissionsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExitPermissions/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExitPermissions/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<ExitPermissionViewModel> collection)
		{
			this._ExitPermissionsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExitPermissions/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExitPermissions/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._ExitPermissionsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExitPermissions/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExitPermissions/delete 
		 */
		public void Delete([FromBody]ExitPermissionViewModel model)
		{
			this._ExitPermissionsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExitPermissions/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExitPermissions/delete/1 
		 */
		public void Delete(long id)
		{
			this._ExitPermissionsService.Delete(id);
		}

		#endregion
	}
}
