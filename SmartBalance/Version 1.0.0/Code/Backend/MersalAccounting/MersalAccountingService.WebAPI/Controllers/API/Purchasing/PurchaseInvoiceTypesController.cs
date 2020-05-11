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
	/// PurchaseInvoiceTypes Controller
	/// </summary>
	[RoutePrefix("api/PurchaseInvoiceTypes")]
	public class PurchaseInvoiceTypesController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ICurrentUserService _currentUserService;
		private readonly IPurchaseInvoiceTypesService _PurchaseInvoiceTypesService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type PurchaseInvoiceTypeController.
		/// </summary>
		/// <param name="currentUserService">The injected currentUserService.</param>
		/// <param name="PurchaseInvoiceTypesService">The injected service.</param>
		public PurchaseInvoiceTypesController(
			ICurrentUserService currentUserService,
			IPurchaseInvoiceTypesService PurchaseInvoiceTypesService)
		{
			this._currentUserService = currentUserService;
			this._PurchaseInvoiceTypesService = PurchaseInvoiceTypesService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseInvoiceTypeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceTypes/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceTypes/get-by-condition 
		 */
		public GenericCollectionViewModel<PurchaseInvoiceTypeViewModel> Get(ConditionFilter<PurchaseInvoiceType, long> condition)
		{
			var result = this._PurchaseInvoiceTypesService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseInvoiceTypeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceTypes/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceTypes/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<PurchaseInvoiceTypeViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._PurchaseInvoiceTypesService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseInvoiceTypeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceTypes/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceTypes/get-light-by-condition 
		 */
		public GenericCollectionViewModel<PurchaseInvoiceTypeLightViewModel> GetLightModel(ConditionFilter<PurchaseInvoiceType, long> condition)
		{
			var result = this._PurchaseInvoiceTypesService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseInvoiceTypeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceTypes/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceTypes/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<PurchaseInvoiceTypeLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._PurchaseInvoiceTypesService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a PurchaseInvoiceTypeViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceTypes/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceTypes/get/1 
		 */
		public PurchaseInvoiceTypeViewModel Get(long id)
		{
			var result = this._PurchaseInvoiceTypesService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceTypes/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceTypes/add-collection 
		 */
		public IList<PurchaseInvoiceTypeViewModel> Add([FromBody]IEnumerable<PurchaseInvoiceTypeViewModel> collection)
		{
			var result = this._PurchaseInvoiceTypesService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceTypes/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceTypes/add 
		 */
		public PurchaseInvoiceTypeViewModel Add([FromBody]PurchaseInvoiceTypeViewModel model)
		{
			var result = this._PurchaseInvoiceTypesService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceTypes/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceTypes/update-collection 
		 */
		public IList<PurchaseInvoiceTypeViewModel> Update([FromBody]IEnumerable<PurchaseInvoiceTypeViewModel> collection)
		{
			var result = this._PurchaseInvoiceTypesService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceTypes/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceTypes/update 
		 */
		public PurchaseInvoiceTypeViewModel Update([FromBody]PurchaseInvoiceTypeViewModel model)
		{
			var result = this._PurchaseInvoiceTypesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceTypes/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceTypes/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<PurchaseInvoiceTypeViewModel> collection)
		{
			this._PurchaseInvoiceTypesService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceTypes/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceTypes/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._PurchaseInvoiceTypesService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceTypes/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceTypes/delete 
		 */
		public void Delete([FromBody]PurchaseInvoiceTypeViewModel model)
		{
			this._PurchaseInvoiceTypesService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoiceTypes/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoiceTypes/delete/1 
		 */
		public void Delete(long id)
		{
			this._PurchaseInvoiceTypesService.Delete(id);
		}

		#endregion
	}
}
