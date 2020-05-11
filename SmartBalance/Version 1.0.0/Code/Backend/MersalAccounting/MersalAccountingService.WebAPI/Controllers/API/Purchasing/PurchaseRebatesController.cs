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
	/// PurchaseRebates Controller
	/// </summary>
	[RoutePrefix("api/PurchaseRebates")]
	public class PurchaseRebatesController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IPurchaseRebatesService _PurchaseRebatesService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type PurchaseRebateController.
		/// </summary>
		/// <param name="PurchaseRebatesService">The injected service.</param>
		public PurchaseRebatesController(IPurchaseRebatesService PurchaseRebatesService)
		{
			this._PurchaseRebatesService = PurchaseRebatesService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseRebateViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebates/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebates/get-by-condition 
		 */
		public GenericCollectionViewModel<PurchaseRebateViewModel> Get(ConditionFilter<PurchaseRebate, long> condition)
		{
			var result = this._PurchaseRebatesService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseRebateViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebates/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebates/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<PurchaseRebateViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._PurchaseRebatesService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseRebateViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebates/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebates/get-light-by-condition 
		 */
		public GenericCollectionViewModel<PurchaseRebateLightViewModel> GetLightModel(ConditionFilter<PurchaseRebate, long> condition)
		{
			var result = this._PurchaseRebatesService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseRebateViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebates/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebates/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<PurchaseRebateLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._PurchaseRebatesService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a PurchaseRebateViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		[JwtAuthentication(Permissions.PurchaseRebateList)]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebates/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebates/get/1 
		 */
		public PurchaseRebateViewModel Get(long id)
		{
			var result = this._PurchaseRebatesService.Get(id);
			return result;
		}


        /// <summary>
        /// Gets a GenericCollectionViewModel of ListPurchasLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-with-filter")]
        [HttpPost]
		[JwtAuthentication(Permissions.PurchaseRebateList)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebates/get-with-filter
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoices/get-with-filter 
		 */
		public GenericCollectionViewModel<ListPurchasLightViewModel> GetByFilter([FromBody]PurchasInvoiceFilterViewModel model)
        {
            var result = this._PurchaseRebatesService.GetByFilter(model);
            return result;
        }

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("add-collection")]
		[HttpPost]
		[JwtAuthentication(Permissions.AddPurchaseRebate)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebates/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebates/add-collection 
		 */
		public IList<PurchaseRebateViewModel> Add([FromBody]IEnumerable<PurchaseRebateViewModel> collection)
		{
			var result = this._PurchaseRebatesService.Add(collection);
			return result;
		}

		/// <summary>
		/// Add an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("add")]
		[HttpPost]
		[JwtAuthentication(Permissions.AddPurchaseRebate)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebates/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebates/add 
		 */
		public PurchaseRebateViewModel Add([FromBody]PurchaseRebateViewModel model)
		{
			var result = this._PurchaseRebatesService.Add(model);
			return result;
		}


		/// <summary>
		/// Update entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		[Route("update-collection")]
		[HttpPost]
		[JwtAuthentication(Permissions.EditPurchaseRebate)]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebates/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebates/update-collection 
		 */
		public IList<PurchaseRebateViewModel> Update([FromBody]IEnumerable<PurchaseRebateViewModel> collection)
		{
			var result = this._PurchaseRebatesService.Update(collection);
			return result;
		}

		/// <summary>
		/// Update an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("update")]
		[HttpPost]
		[JwtAuthentication(Permissions.EditPurchaseRebate)]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebates/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebates/update 
		 */
		public PurchaseRebateViewModel Update([FromBody]PurchaseRebateViewModel model)
		{
			var result = this._PurchaseRebatesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebates/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebates/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<PurchaseRebateViewModel> collection)
		{
			this._PurchaseRebatesService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebates/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebates/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._PurchaseRebatesService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebates/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebates/delete 
		 */
		public void Delete([FromBody]PurchaseRebateViewModel model)
		{
			this._PurchaseRebatesService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseRebates/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseRebates/delete/1 
		 */
		public void Delete(long id)
		{
			this._PurchaseRebatesService.Delete(id);
		}

		#endregion
	}
}
