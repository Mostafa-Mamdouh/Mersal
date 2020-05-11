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
	/// PurchaseRebateCostCenters Controller
	/// </summary>
	[RoutePrefix("api/PurchaseRebateCostCenters")]
	public class PurchaseRebateCostCentersController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ICurrentUserService _currentUserService;
		private readonly IPurchaseRebateCostCentersService _PurchaseRebateCostCentersService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type PurchaseRebateCostCenterController.
		/// </summary>
		/// <param name="currentUserService">The injected currentUserService.</param>
		/// <param name="PurchaseRebateCostCentersService">The injected service.</param>
		public PurchaseRebateCostCentersController(
			ICurrentUserService currentUserService,
			IPurchaseRebateCostCentersService PurchaseRebateCostCentersService)
		{
			this._currentUserService = currentUserService;
			this._PurchaseRebateCostCentersService = PurchaseRebateCostCentersService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseRebateCostCenterViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebateCostCenters/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebateCostCenters/get-by-condition 
		 */
		public GenericCollectionViewModel<PurchaseRebateCostCenterViewModel> Get(ConditionFilter<PurchaseRebateCostCenter, long> condition)
		{
			var result = this._PurchaseRebateCostCentersService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseRebateCostCenterViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebateCostCenters/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebateCostCenters/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<PurchaseRebateCostCenterViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._PurchaseRebateCostCentersService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseRebateCostCenterViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebateCostCenters/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebateCostCenters/get-light-by-condition 
		 */
		public GenericCollectionViewModel<PurchaseRebateCostCenterLightViewModel> GetLightModel(ConditionFilter<PurchaseRebateCostCenter, long> condition)
		{
			var result = this._PurchaseRebateCostCentersService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseRebateCostCenterViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebateCostCenters/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebateCostCenters/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<PurchaseRebateCostCenterLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._PurchaseRebateCostCentersService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a PurchaseRebateCostCenterViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebateCostCenters/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebateCostCenters/get/1 
		 */
		public PurchaseRebateCostCenterViewModel Get(long id)
		{
			var result = this._PurchaseRebateCostCentersService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebateCostCenters/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebateCostCenters/add-collection 
		 */
		public IList<PurchaseRebateCostCenterViewModel> Add([FromBody]IEnumerable<PurchaseRebateCostCenterViewModel> collection)
		{
			var result = this._PurchaseRebateCostCentersService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebateCostCenters/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebateCostCenters/add 
		 */
		public PurchaseRebateCostCenterViewModel Add([FromBody]PurchaseRebateCostCenterViewModel model)
		{
			var result = this._PurchaseRebateCostCentersService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebateCostCenters/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebateCostCenters/update-collection 
		 */
		public IList<PurchaseRebateCostCenterViewModel> Update([FromBody]IEnumerable<PurchaseRebateCostCenterViewModel> collection)
		{
			var result = this._PurchaseRebateCostCentersService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebateCostCenters/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebateCostCenters/update 
		 */
		public PurchaseRebateCostCenterViewModel Update([FromBody]PurchaseRebateCostCenterViewModel model)
		{
			var result = this._PurchaseRebateCostCentersService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebateCostCenters/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebateCostCenters/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<PurchaseRebateCostCenterViewModel> collection)
		{
			this._PurchaseRebateCostCentersService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebateCostCenters/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebateCostCenters/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._PurchaseRebateCostCentersService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebateCostCenters/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebateCostCenters/delete 
		 */
		public void Delete([FromBody]PurchaseRebateCostCenterViewModel model)
		{
			this._PurchaseRebateCostCentersService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebateCostCenters/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebateCostCenters/delete/1 
		 */
		public void Delete(long id)
		{
			this._PurchaseRebateCostCentersService.Delete(id);
		}

		#endregion
	}
}
