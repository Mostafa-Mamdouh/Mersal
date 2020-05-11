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
	/// InventoryOpeningBalances Controller
	/// </summary>
	[RoutePrefix("api/OpeningBalance")]
	public class InventoryOpeningBalanceController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IInventoryOpeningBalanceService _InventoryOpeningBalancesService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryOpeningBalanceController.
		/// </summary>
		/// <param name="InventoryOpeningBalancesService">The injected service.</param>
		public InventoryOpeningBalanceController(IInventoryOpeningBalanceService InventoryOpeningBalancesService)
		{
			this._InventoryOpeningBalancesService = InventoryOpeningBalancesService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryOpeningBalanceViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalances/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalances/get-by-condition 
		 */
		public GenericCollectionViewModel<InventoryOpeningBalanceViewModel> Get(ConditionFilter<InventoryOpeningBalance, long> condition)
		{
			var result = this._InventoryOpeningBalancesService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryOpeningBalanceViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalances/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalances/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<InventoryOpeningBalanceViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._InventoryOpeningBalancesService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryOpeningBalanceViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalances/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalances/get-light-by-condition 
		 */
		public GenericCollectionViewModel<InventoryOpeningBalanceLightViewModel> GetLightModel(ConditionFilter<InventoryOpeningBalance, long> condition)
		{
			var result = this._InventoryOpeningBalancesService.GetLightModel(condition);
			return result;
		}

        /// <summary>
		/// Gets a GenericCollectionViewModel of InventoryOpeningBalanceViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		

        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryOpeningBalanceViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalances/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalances/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<InventoryOpeningBalanceLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._InventoryOpeningBalancesService.GetLightModel(pageIndex, pageSize);
			return result;
		}

        /// <summary>
        /// Gets a GenericCollectionViewModel of ListPurchasLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-with-filter")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalances/get-with-filter
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalances/get-with-filter 
		 */
        public GenericCollectionViewModel<InventoryOpeningBalanceLightViewModel> GetByFilter([FromBody]InventoryOpeningBalanceFilterViewModel model)
        {
            var result = this._InventoryOpeningBalancesService.GetByFilter(model);
            return result;
        }

        /// <summary>
        /// Gets a InventoryOpeningBalanceViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalances/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalances/get/1 
		 */
		public InventoryOpeningBalanceViewModel Get(long id)
		{
			var result = this._InventoryOpeningBalancesService.Get(id);
			return result;
		}


        /// <summary>
        /// Gets a InventoryOpeningBalanceViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get-by-vendorId/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalances/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/OpeningBalance/get-by-vendorId/1 
		 */
        public GenericCollectionViewModel<InventoryOpeningBalanceLookupViewModel> GetByVendorID(long id)
        {
            var result = this._InventoryOpeningBalancesService.GetOpeningBalancesByVendorID(id);
            return result;
        }



        /// <summary>
        /// Gets a InventoryOpeningBalanceViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get-opening-balances/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalances/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalances/get/1 
		 */
        public InventoryOpeningBalanceAddViewModel GetOpeningBalances(long id)
        {
            var result = this._InventoryOpeningBalancesService.GetOpeningBalances(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalances/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalances/add-collection 
		 */
		public IList<InventoryOpeningBalanceViewModel> Add([FromBody]IEnumerable<InventoryOpeningBalanceViewModel> collection)
		{
			var result = this._InventoryOpeningBalancesService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalances/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalances/add 
		 */
		public InventoryOpeningBalanceViewModel Add([FromBody]InventoryOpeningBalanceViewModel model)
		{
			var result = this._InventoryOpeningBalancesService.Add(model);
			return result;
		}


        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [Route("add-opening-balances")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalances/add
    		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalances/add-opening-balances 
		 */
        public InventoryOpeningBalanceAddViewModel Add([FromBody]InventoryOpeningBalanceAddViewModel model)
        {
            var result = this._InventoryOpeningBalancesService.AddInventoryOpeningBalance(model);
            return result;
        }

        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [Route("update-opening-balances")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalances/add
    		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalances/add-opening-balances 
		 */
        public InventoryOpeningBalanceAddViewModel UpdateInventoryOpeningBalance([FromBody]InventoryOpeningBalanceAddViewModel model)
        {
            var result = this._InventoryOpeningBalancesService.UpdateInventoryOpeningBalance(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalances/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalances/update-collection 
		 */
		public IList<InventoryOpeningBalanceViewModel> Update([FromBody]IEnumerable<InventoryOpeningBalanceViewModel> collection)
		{
			var result = this._InventoryOpeningBalancesService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalances/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalances/update 
		 */
		public InventoryOpeningBalanceViewModel Update([FromBody]InventoryOpeningBalanceViewModel model)
		{
			var result = this._InventoryOpeningBalancesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalances/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalances/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<InventoryOpeningBalanceViewModel> collection)
		{
			this._InventoryOpeningBalancesService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalances/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalances/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._InventoryOpeningBalancesService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalances/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalances/delete 
		 */
		public void Delete([FromBody]InventoryOpeningBalanceViewModel model)
		{
			this._InventoryOpeningBalancesService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalances/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalances/delete/1 
		 */
		public void Delete(long id)
		{
			this._InventoryOpeningBalancesService.Delete(id);
		}

		#endregion
	}
}
