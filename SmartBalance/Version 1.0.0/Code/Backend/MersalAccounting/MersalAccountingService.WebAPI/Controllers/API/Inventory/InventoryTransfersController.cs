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
	/// InventoryTransfers Controller
	/// </summary>
	[RoutePrefix("api/InventoryTransfers")]
	public class InventoryTransfersController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IInventoryTransfersService _InventoryTransfersService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryTransferController.
		/// </summary>
		/// <param name="InventoryTransfersService">The injected service.</param>
		public InventoryTransfersController(IInventoryTransfersService InventoryTransfersService)
		{
			this._InventoryTransfersService = InventoryTransfersService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryTransferViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransfers/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransfers/get-by-condition 
		 */
		public GenericCollectionViewModel<InventoryTransferViewModel> Get(ConditionFilter<InventoryTransfer, long> condition)
		{
			var result = this._InventoryTransfersService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryTransferViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransfers/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransfers/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<InventoryTransferViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._InventoryTransfersService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryTransferViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransfers/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransfers/get-light-by-condition 
		 */
		public GenericCollectionViewModel<InventoryTransferLightViewModel> GetLightModel(ConditionFilter<InventoryTransfer, long> condition)
		{
			var result = this._InventoryTransfersService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryTransferViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransfers/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransfers/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<InventoryTransferLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._InventoryTransfersService.GetLightModel(pageIndex, pageSize);
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
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransfers/get-with-filter 
		 */
        public GenericCollectionViewModel<InventoryTransferLightViewModel> GetByFilter([FromBody]InventoryTransferFilterViewModel model)
        {
            var result = this._InventoryTransfersService.GetByFilter(model);
            return result;
        }


        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [Route("add-inventory-transfer")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransfers/add
    		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransfers/add-inventory-transfer
		 */
        public InventoryTransferAddViewModel Add([FromBody]InventoryTransferAddViewModel model)
        {
            var result = this._InventoryTransfersService.AddInventoryTransfer(model);
            return result;
        }
        [Route("update-inventory-transfer")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransfers/add
    		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransfers/add-inventory-transfer
		 */
        public InventoryTransferAddViewModel UpdateInventoryTransfer([FromBody]InventoryTransferAddViewModel model)
        {
            var result = this._InventoryTransfersService.UpdateInventoryTransfer(model);
            return result;
        }

        /// <summary>
        /// Gets a InventoryOpeningBalanceViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get-inventory-transfer/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransfers/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransfers/get/1 
		 */
        public InventoryTransferAddViewModel GetInventoryTransfer(long id)
        {
            var result = this._InventoryTransfersService.GetInventoryTransfer(id);
            return result;
        }
        

        /// <summary>
        /// Gets a InventoryTransferViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransfers/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransfers/get/1 
		 */
		public InventoryTransferViewModel Get(long id)
		{
			var result = this._InventoryTransfersService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransfers/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransfers/add-collection 
		 */
		public IList<InventoryTransferViewModel> Add([FromBody]IEnumerable<InventoryTransferViewModel> collection)
		{
			var result = this._InventoryTransfersService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransfers/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransfers/add 
		 */
		public InventoryTransferViewModel Add([FromBody]InventoryTransferViewModel model)
		{
			var result = this._InventoryTransfersService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransfers/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransfers/update-collection 
		 */
		public IList<InventoryTransferViewModel> Update([FromBody]IEnumerable<InventoryTransferViewModel> collection)
		{
			var result = this._InventoryTransfersService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransfers/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransfers/update 
		 */
		public InventoryTransferViewModel Update([FromBody]InventoryTransferViewModel model)
		{
			var result = this._InventoryTransfersService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransfers/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransfers/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<InventoryTransferViewModel> collection)
		{
			this._InventoryTransfersService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransfers/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransfers/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._InventoryTransfersService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransfers/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransfers/delete 
		 */
		public void Delete([FromBody]InventoryTransferViewModel model)
		{
			this._InventoryTransfersService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryTransfers/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryTransfers/delete/1 
		 */
		public void Delete(long id)
		{
			this._InventoryTransfersService.Delete(id);
		}

		#endregion
	}
}
