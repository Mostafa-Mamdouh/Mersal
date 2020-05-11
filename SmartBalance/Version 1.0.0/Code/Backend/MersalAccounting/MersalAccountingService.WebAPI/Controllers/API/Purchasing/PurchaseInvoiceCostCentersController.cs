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
	/// PurchaseInvoiceCostCenters Controller
	/// </summary>
	[RoutePrefix("api/PurchaseInvoiceCostCenters")]
	public class PurchaseInvoiceCostCentersController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ICurrentUserService _currentUserService;
		private readonly IPurchaseInvoiceCostCentersService _PurchaseInvoiceCostCentersService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type PurchaseInvoiceCostCenterController.
		/// </summary>
		/// <param name="currentUserService">The injected currentUserService.</param>
		/// <param name="PurchaseInvoiceCostCentersService">The injected service.</param>
		public PurchaseInvoiceCostCentersController(
			ICurrentUserService currentUserService,
			IPurchaseInvoiceCostCentersService PurchaseInvoiceCostCentersService)
		{
			this._currentUserService = currentUserService;
			this._PurchaseInvoiceCostCentersService = PurchaseInvoiceCostCentersService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseInvoiceCostCenterViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceCostCenters/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceCostCenters/get-by-condition 
		 */
		public GenericCollectionViewModel<PurchaseInvoiceCostCenterViewModel> Get(ConditionFilter<PurchaseInvoiceCostCenter, long> condition)
		{
			var result = this._PurchaseInvoiceCostCentersService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseInvoiceCostCenterViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceCostCenters/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceCostCenters/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<PurchaseInvoiceCostCenterViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._PurchaseInvoiceCostCentersService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseInvoiceCostCenterViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceCostCenters/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceCostCenters/get-light-by-condition 
		 */
		public GenericCollectionViewModel<PurchaseInvoiceCostCenterLightViewModel> GetLightModel(ConditionFilter<PurchaseInvoiceCostCenter, long> condition)
		{
			var result = this._PurchaseInvoiceCostCentersService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseInvoiceCostCenterViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceCostCenters/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceCostCenters/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<PurchaseInvoiceCostCenterLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._PurchaseInvoiceCostCentersService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a PurchaseInvoiceCostCenterViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceCostCenters/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceCostCenters/get/1 
		 */
		public PurchaseInvoiceCostCenterViewModel Get(long id)
		{
			var result = this._PurchaseInvoiceCostCentersService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceCostCenters/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceCostCenters/add-collection 
		 */
		public IList<PurchaseInvoiceCostCenterViewModel> Add([FromBody]IEnumerable<PurchaseInvoiceCostCenterViewModel> collection)
		{
			var result = this._PurchaseInvoiceCostCentersService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceCostCenters/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceCostCenters/add 
		 */
		public PurchaseInvoiceCostCenterViewModel Add([FromBody]PurchaseInvoiceCostCenterViewModel model)
		{
			var result = this._PurchaseInvoiceCostCentersService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceCostCenters/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceCostCenters/update-collection 
		 */
		public IList<PurchaseInvoiceCostCenterViewModel> Update([FromBody]IEnumerable<PurchaseInvoiceCostCenterViewModel> collection)
		{
			var result = this._PurchaseInvoiceCostCentersService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceCostCenters/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceCostCenters/update 
		 */
		public PurchaseInvoiceCostCenterViewModel Update([FromBody]PurchaseInvoiceCostCenterViewModel model)
		{
			var result = this._PurchaseInvoiceCostCentersService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceCostCenters/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceCostCenters/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<PurchaseInvoiceCostCenterViewModel> collection)
		{
			this._PurchaseInvoiceCostCentersService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceCostCenters/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceCostCenters/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._PurchaseInvoiceCostCentersService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceCostCenters/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceCostCenters/delete 
		 */
		public void Delete([FromBody]PurchaseInvoiceCostCenterViewModel model)
		{
			this._PurchaseInvoiceCostCentersService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceCostCenters/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceCostCenters/delete/1 
		 */
		public void Delete(long id)
		{
			this._PurchaseInvoiceCostCentersService.Delete(id);
		}

		#endregion
	}
}
