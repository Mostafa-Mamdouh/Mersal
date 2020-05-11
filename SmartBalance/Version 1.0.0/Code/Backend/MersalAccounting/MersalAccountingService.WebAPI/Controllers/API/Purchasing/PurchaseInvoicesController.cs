#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using MersalAccountingService.WebAPI.Auth;
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
	/// PurchaseInvoices Controller
	/// </summary>
	[RoutePrefix("api/PurchaseInvoices")]
	public class PurchaseInvoicesController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IPurchaseInvoicesService _PurchaseInvoicesService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type PurchaseInvoiceController.
		/// </summary>
		/// <param name="PurchaseInvoicesService">The injected service.</param>
		public PurchaseInvoicesController(IPurchaseInvoicesService PurchaseInvoicesService)
		{
			this._PurchaseInvoicesService = PurchaseInvoicesService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseInvoiceViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoices/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoices/get-by-condition 
		 */
		public GenericCollectionViewModel<PurchaseInvoiceViewModel> Get(ConditionFilter<PurchaseInvoice, long> condition)
		{
			var result = this._PurchaseInvoicesService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseInvoiceViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoices/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoices/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<PurchaseInvoiceViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._PurchaseInvoicesService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseInvoiceViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoices/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoices/get-light-by-condition 
		 */
		public GenericCollectionViewModel<PurchaseInvoiceLightViewModel> GetLightModel(ConditionFilter<PurchaseInvoice, long> condition)
		{
			var result = this._PurchaseInvoicesService.GetLightModel(condition);
			return result;
		}

        /// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseInvoiceViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-lookup")]
        [HttpGet]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoices/get-lookup
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoices/get-lookup
		 */
        public IList<PurchaseInvoiceLookupViewModel> GetLookupLightModel()
        {
            var result = this._PurchaseInvoicesService.GetLookupLightModel();
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of PurchaseInvoiceViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoices/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoices/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<PurchaseInvoiceLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._PurchaseInvoicesService.GetLightModel(pageIndex, pageSize);
			return result;
		}

        /// <summary>
        /// Gets a GenericCollectionViewModel of ListPurchasLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-with-filter")]
        [HttpPost]
		[JwtAuthentication(Permissions.PurchaseInvoicesList)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoices/get-with-filter
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoices/get-with-filter 
		 */
		public GenericCollectionViewModel<ListPurchasLightViewModel> GetByFilter([FromBody]PurchasInvoiceFilterViewModel model)
        {
            var result = this._PurchaseInvoicesService.GetByFilter(model);
            return result;
        }

        /// <summary>
        /// Gets a PurchaseInvoiceViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
		[HttpGet]
		[JwtAuthentication(Permissions.PurchaseInvoicesList)]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoices/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoices/get/1 
		 */
		public PurchaseInvoiceViewModel Get(long id)
		{
			var result = this._PurchaseInvoicesService.Get(id);
			return result;
		}


		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		[Route("add-collection")]
		[HttpPost]
		[JwtAuthentication(Permissions.AddPurchaseInvoice)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoices/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoices/add-collection 
		 */
		public IList<PurchaseInvoiceViewModel> Add([FromBody]IEnumerable<PurchaseInvoiceViewModel> collection)
		{
			var result = this._PurchaseInvoicesService.Add(collection);
			return result;
		}

		/// <summary>
		/// Add an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("add")]
		[HttpPost]
		[JwtAuthentication(Permissions.AddPurchaseInvoice)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoices/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoices/add 
		 */
		public PurchaseInvoiceViewModel Add([FromBody]PurchaseInvoiceViewModel model)
		{
			var result = this._PurchaseInvoicesService.Add(model);
			return result;
		}


		/// <summary>
		/// Update entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		[Route("update-collection")]
		[HttpPost]
		[JwtAuthentication(Permissions.EditPurchaseInvoice)]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoices/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoices/update-collection 
		 */
		public IList<PurchaseInvoiceViewModel> Update([FromBody]IEnumerable<PurchaseInvoiceViewModel> collection)
		{
			var result = this._PurchaseInvoicesService.Update(collection);
			return result;
		}

		/// <summary>
		/// Update an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("update")]
		[HttpPost]
		[JwtAuthentication(Permissions.EditPurchaseInvoice)]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoices/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoices/update 
		 */
		public PurchaseInvoiceViewModel Update([FromBody]PurchaseInvoiceViewModel model)
		{
			var result = this._PurchaseInvoicesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoices/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoices/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<PurchaseInvoiceViewModel> collection)
		{
			this._PurchaseInvoicesService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoices/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoices/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._PurchaseInvoicesService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoices/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoices/delete 
		 */
		public void Delete([FromBody]PurchaseInvoiceViewModel model)
		{
			this._PurchaseInvoicesService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoices/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoices/delete/1 
		 */
		public void Delete(long id)
		{
			this._PurchaseInvoicesService.Delete(id);
		}

		#endregion
	}
}
