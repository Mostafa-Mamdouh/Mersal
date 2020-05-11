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
	/// InventoryOpeningBalanceCostCenters Controller
	/// </summary>
	[RoutePrefix("api/OpeningBalanceCostCenters")]
	public class InventoryOpeningBalanceCostCentersController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ICurrentUserService _currentUserService;
		private readonly IInventoryOpeningBalanceCostCentersService _InventoryOpeningBalanceCostCentersService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryOpeningBalanceCostCenterController.
		/// </summary>
		/// <param name="currentUserService">The injected currentUserService.</param>
		/// <param name="InventoryOpeningBalanceCostCentersService">The injected service.</param>
		public InventoryOpeningBalanceCostCentersController(
			ICurrentUserService currentUserService,
			IInventoryOpeningBalanceCostCentersService InventoryOpeningBalanceCostCentersService)
		{
			this._currentUserService = currentUserService;
			this._InventoryOpeningBalanceCostCentersService = InventoryOpeningBalanceCostCentersService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryOpeningBalanceCostCenterViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalanceCostCenters/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalanceCostCenters/get-by-condition 
		 */
		public GenericCollectionViewModel<InventoryOpeningBalanceCostCenterViewModel> Get(ConditionFilter<InventoryOpeningBalanceCostCenter, long> condition)
		{
			var result = this._InventoryOpeningBalanceCostCentersService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryOpeningBalanceCostCenterViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalanceCostCenters/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalanceCostCenters/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<InventoryOpeningBalanceCostCenterViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._InventoryOpeningBalanceCostCentersService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryOpeningBalanceCostCenterViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalanceCostCenters/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalanceCostCenters/get-light-by-condition 
		 */
		public GenericCollectionViewModel<InventoryOpeningBalanceCostCenterViewModel> GetLightModel(ConditionFilter<InventoryOpeningBalanceCostCenter, long> condition)
		{
			var result = this._InventoryOpeningBalanceCostCentersService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryOpeningBalanceCostCenterViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalanceCostCenters/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalanceCostCenters/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<InventoryOpeningBalanceCostCenterViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._InventoryOpeningBalanceCostCentersService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a InventoryOpeningBalanceCostCenterViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalanceCostCenters/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalanceCostCenters/get/1 
		 */
		public InventoryOpeningBalanceCostCenterViewModel Get(long id)
		{
			var result = this._InventoryOpeningBalanceCostCentersService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalanceCostCenters/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalanceCostCenters/add-collection 
		 */
		public IList<InventoryOpeningBalanceCostCenterViewModel> Add([FromBody]IEnumerable<InventoryOpeningBalanceCostCenterViewModel> collection)
		{
			var result = this._InventoryOpeningBalanceCostCentersService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalanceCostCenters/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalanceCostCenters/add 
		 */
		public InventoryOpeningBalanceCostCenterViewModel Add([FromBody]InventoryOpeningBalanceCostCenterViewModel model)
		{
			var result = this._InventoryOpeningBalanceCostCentersService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalanceCostCenters/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalanceCostCenters/update-collection 
		 */
		public IList<InventoryOpeningBalanceCostCenterViewModel> Update([FromBody]IEnumerable<InventoryOpeningBalanceCostCenterViewModel> collection)
		{
			var result = this._InventoryOpeningBalanceCostCentersService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalanceCostCenters/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalanceCostCenters/update 
		 */
		public InventoryOpeningBalanceCostCenterViewModel Update([FromBody]InventoryOpeningBalanceCostCenterViewModel model)
		{
			var result = this._InventoryOpeningBalanceCostCentersService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalanceCostCenters/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalanceCostCenters/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<InventoryOpeningBalanceCostCenterViewModel> collection)
		{
			this._InventoryOpeningBalanceCostCentersService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalanceCostCenters/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalanceCostCenters/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._InventoryOpeningBalanceCostCentersService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalanceCostCenters/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalanceCostCenters/delete 
		 */
		public void Delete([FromBody]InventoryOpeningBalanceCostCenterViewModel model)
		{
			this._InventoryOpeningBalanceCostCentersService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalanceCostCenters/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalanceCostCenters/delete/1 
		 */
		public void Delete(long id)
		{
			this._InventoryOpeningBalanceCostCentersService.Delete(id);
		}

		#endregion
	}
}
