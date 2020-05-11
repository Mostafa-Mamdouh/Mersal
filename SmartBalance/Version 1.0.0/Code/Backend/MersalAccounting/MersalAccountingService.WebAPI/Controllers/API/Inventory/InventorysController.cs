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
	/// Inventorys Controller
	/// </summary>
	[RoutePrefix("api/Inventorys")]
	public class InventorysController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IInventorysService _InventorysService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryController.
		/// </summary>
		/// <param name="InventorysService">The injected service.</param>
		public InventorysController(IInventorysService InventorysService)
		{
			this._InventorysService = InventorysService;
		}
        #endregion

        #region Actions

        [Route("get-with-filter")]
        [HttpPost]
        public GenericCollectionViewModel<ListInventoryLightViewModel> GetByFilter([FromBody]InventoryFilterViewModel model)
        {
            var result = this._InventorysService.GetByFilter(model);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Inventorys/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Inventorys/get-by-condition 
		 */
		public GenericCollectionViewModel<InventoryViewModel> Get(ConditionFilter<Inventory, long> condition)
		{
			var result = this._InventorysService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Inventorys/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Inventorys/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<InventoryViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._InventorysService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Inventorys/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Inventorys/get-light-by-condition 
		 */
		public GenericCollectionViewModel<InventoryLightViewModel> GetLightModel(ConditionFilter<Inventory, long> condition)
		{
			var result = this._InventorysService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Inventorys/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Inventorys/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<InventoryLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._InventorysService.GetLightModel(pageIndex, pageSize);
			return result;
		}

        [Route("get-lookup")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Inventorys/get-lookup
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Inventorys/get-lookup
		 */
        public List<InventoryLightViewModel> GetLookup()
        {
            var result = this._InventorysService.GetLookUp();
            return result;
        }

        /// <summary>
        /// Gets a InventoryViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Inventorys/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Inventorys/get/1 
		 */
		public InventoryViewModel Get(long id)
		{
			var result = this._InventorysService.Get(id);
			return result;
		}

        /// <summary>
        /// Gets a InventoryViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get-Inventory-Product/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Inventorys/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Inventorys/get-Inventory-Product/1 
		 */
        public List<ProductLightViewModel> GetInventoryProduct(long id)
        {
            var result = this._InventorysService.GetInventoryProduct(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Inventorys/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Inventorys/add-collection 
		 */
		public IList<InventoryViewModel> Add([FromBody]IEnumerable<InventoryViewModel> collection)
		{
			var result = this._InventorysService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Inventorys/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Inventorys/add 
		 */
		public InventoryViewModel Add([FromBody]InventoryViewModel model)
		{
			var result = this._InventorysService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Inventorys/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Inventorys/update-collection 
		 */
		public IList<InventoryViewModel> Update([FromBody]IEnumerable<InventoryViewModel> collection)
		{
			var result = this._InventorysService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Inventorys/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Inventorys/update 
		 */
		public InventoryViewModel Update([FromBody]InventoryViewModel model)
		{
			var result = this._InventorysService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Inventorys/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Inventorys/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<InventoryViewModel> collection)
		{
			this._InventorysService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Inventorys/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Inventorys/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._InventorysService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Inventorys/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Inventorys/delete 
		 */
		public void Delete([FromBody]InventoryViewModel model)
		{
			this._InventorysService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Inventorys/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Inventorys/delete/1 
		 */
		public void Delete(long id)
		{
			this._InventorysService.Delete(id);
		}

		#endregion
	}
}
