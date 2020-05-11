#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.Common;
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
	/// InventoryMovementCostCenters Controller
	/// </summary>
	[RoutePrefix("api/InventoryMovementCostCenters")]
	public class InventoryMovementCostCentersController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ICurrentUserService _currentUserService;
		private readonly IInventoryMovementCostCentersService _InventoryMovementCostCentersService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryMovementCostCenterController.
		/// </summary>
		/// <param name="currentUserService">The injected currentUserService.</param>
		/// <param name="InventoryMovementCostCentersService">The injected service.</param>
		public InventoryMovementCostCentersController(
			ICurrentUserService currentUserService,
			IInventoryMovementCostCentersService InventoryMovementCostCentersService)
		{
			this._currentUserService = currentUserService;
			this._InventoryMovementCostCentersService = InventoryMovementCostCentersService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryMovementCostCenterViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementCostCenters/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementCostCenters/get-by-condition 
		 */
		public GenericCollectionViewModel<InventoryMovementCostCenterViewModel> Get(ConditionFilter<InventoryMovementCostCenter, long> condition)
		{
			var result = this._InventoryMovementCostCentersService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryMovementCostCenterViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementCostCenters/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementCostCenters/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<InventoryMovementCostCenterViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._InventoryMovementCostCentersService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryMovementCostCenterViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementCostCenters/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementCostCenters/get-light-by-condition 
		 */
		public GenericCollectionViewModel<InventoryMovementCostCenterViewModel> GetLightModel(ConditionFilter<InventoryMovementCostCenter, long> condition)
		{
			var result = this._InventoryMovementCostCentersService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryMovementCostCenterViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementCostCenters/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementCostCenters/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<InventoryMovementCostCenterViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._InventoryMovementCostCentersService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a InventoryMovementCostCenterViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementCostCenters/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementCostCenters/get/1 
		 */
		public InventoryMovementCostCenterViewModel Get(long id)
		{
			var result = this._InventoryMovementCostCentersService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementCostCenters/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementCostCenters/add-collection 
		 */
		public IList<InventoryMovementCostCenterViewModel> Add([FromBody]IEnumerable<InventoryMovementCostCenterViewModel> collection)
		{
			var result = this._InventoryMovementCostCentersService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementCostCenters/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementCostCenters/add 
		 */
		public InventoryMovementCostCenterViewModel Add([FromBody]InventoryMovementCostCenterViewModel model)
		{
			var result = this._InventoryMovementCostCentersService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementCostCenters/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementCostCenters/update-collection 
		 */
		public IList<InventoryMovementCostCenterViewModel> Update([FromBody]IEnumerable<InventoryMovementCostCenterViewModel> collection)
		{
			var result = this._InventoryMovementCostCentersService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementCostCenters/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementCostCenters/update 
		 */
		public InventoryMovementCostCenterViewModel Update([FromBody]InventoryMovementCostCenterViewModel model)
		{
			var result = this._InventoryMovementCostCentersService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementCostCenters/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementCostCenters/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<InventoryMovementCostCenterViewModel> collection)
		{
			this._InventoryMovementCostCentersService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementCostCenters/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementCostCenters/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._InventoryMovementCostCentersService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementCostCenters/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementCostCenters/delete 
		 */
		public void Delete([FromBody]InventoryMovementCostCenterViewModel model)
		{
			this._InventoryMovementCostCentersService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementCostCenters/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementCostCenters/delete/1 
		 */
		public void Delete(long id)
		{
			this._InventoryMovementCostCentersService.Delete(id);
		}

		#endregion
	}
}
