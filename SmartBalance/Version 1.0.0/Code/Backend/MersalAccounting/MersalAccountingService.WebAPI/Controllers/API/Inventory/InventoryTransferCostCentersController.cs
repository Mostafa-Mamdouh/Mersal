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
	/// InventoryTransferCostCenters Controller
	/// </summary>
	[RoutePrefix("api/InventoryTransferCostCenters")]
	public class InventoryTransferCostCentersController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ICurrentUserService _currentUserService;
		private readonly IInventoryTransferCostCentersService _InventoryTransferCostCentersService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryTransferCostCenterController.
		/// </summary>
		/// <param name="currentUserService">The injected currentUserService.</param>
		/// <param name="InventoryTransferCostCentersService">The injected service.</param>
		public InventoryTransferCostCentersController(
			ICurrentUserService currentUserService,
			IInventoryTransferCostCentersService InventoryTransferCostCentersService)
		{
			this._currentUserService = currentUserService;
			this._InventoryTransferCostCentersService = InventoryTransferCostCentersService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryTransferCostCenterViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransferCostCenters/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransferCostCenters/get-by-condition 
		 */
		public GenericCollectionViewModel<InventoryTransferCostCenterViewModel> Get(ConditionFilter<InventoryTransferCostCenter, long> condition)
		{
			var result = this._InventoryTransferCostCentersService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryTransferCostCenterViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransferCostCenters/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransferCostCenters/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<InventoryTransferCostCenterViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._InventoryTransferCostCentersService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryTransferCostCenterViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransferCostCenters/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransferCostCenters/get-light-by-condition 
		 */
		public GenericCollectionViewModel<InventoryTransferCostCenterViewModel> GetLightModel(ConditionFilter<InventoryTransferCostCenter, long> condition)
		{
			var result = this._InventoryTransferCostCentersService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryTransferCostCenterViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransferCostCenters/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransferCostCenters/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<InventoryTransferCostCenterViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._InventoryTransferCostCentersService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a InventoryTransferCostCenterViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransferCostCenters/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransferCostCenters/get/1 
		 */
		public InventoryTransferCostCenterViewModel Get(long id)
		{
			var result = this._InventoryTransferCostCentersService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransferCostCenters/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransferCostCenters/add-collection 
		 */
		public IList<InventoryTransferCostCenterViewModel> Add([FromBody]IEnumerable<InventoryTransferCostCenterViewModel> collection)
		{
			var result = this._InventoryTransferCostCentersService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransferCostCenters/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransferCostCenters/add 
		 */
		public InventoryTransferCostCenterViewModel Add([FromBody]InventoryTransferCostCenterViewModel model)
		{
			var result = this._InventoryTransferCostCentersService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransferCostCenters/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransferCostCenters/update-collection 
		 */
		public IList<InventoryTransferCostCenterViewModel> Update([FromBody]IEnumerable<InventoryTransferCostCenterViewModel> collection)
		{
			var result = this._InventoryTransferCostCentersService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransferCostCenters/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransferCostCenters/update 
		 */
		public InventoryTransferCostCenterViewModel Update([FromBody]InventoryTransferCostCenterViewModel model)
		{
			var result = this._InventoryTransferCostCentersService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransferCostCenters/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransferCostCenters/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<InventoryTransferCostCenterViewModel> collection)
		{
			this._InventoryTransferCostCentersService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransferCostCenters/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransferCostCenters/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._InventoryTransferCostCentersService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransferCostCenters/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransferCostCenters/delete 
		 */
		public void Delete([FromBody]InventoryTransferCostCenterViewModel model)
		{
			this._InventoryTransferCostCentersService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransferCostCenters/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransferCostCenters/delete/1 
		 */
		public void Delete(long id)
		{
			this._InventoryTransferCostCentersService.Delete(id);
		}

		#endregion
	}
}
