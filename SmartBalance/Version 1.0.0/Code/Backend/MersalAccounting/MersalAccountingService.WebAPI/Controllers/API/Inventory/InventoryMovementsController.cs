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
	/// InventoryMovements Controller
	/// </summary>
	[RoutePrefix("api/InventoryMovements")]
	public class InventoryMovementsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IInventoryMovementsService _InventoryMovementsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryMovementController.
		/// </summary>
		/// <param name="InventoryMovementsService">The injected service.</param>
		public InventoryMovementsController(IInventoryMovementsService InventoryMovementsService)
		{
			this._InventoryMovementsService = InventoryMovementsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryMovementViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovements/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovements/get-by-condition 
		 */
		public GenericCollectionViewModel<InventoryMovementViewModel> Get(ConditionFilter<InventoryMovement, long> condition)
		{
			var result = this._InventoryMovementsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryMovementViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovements/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovements/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<InventoryMovementViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._InventoryMovementsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryMovementViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovements/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovements/get-light-by-condition 
		 */
		public GenericCollectionViewModel<InventoryMovementLightViewModel> GetLightModel(ConditionFilter<InventoryMovement, long> condition)
		{
			var result = this._InventoryMovementsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryMovementViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovements/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovements/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<InventoryMovementLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._InventoryMovementsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a InventoryMovementViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovements/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovements/get/1 
		 */
		public InventoryMovementViewModel Get(long id)
		{
			var result = this._InventoryMovementsService.Get(id);
			return result;
		}

        [Route("get-with-filter")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalances/get-with-filter
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalances/get-with-filter 
		 */
        public GenericCollectionViewModel<InventoryMovementLightViewModel> GetByFilter([FromBody]InventoryMovementFilterViewModel model)
        {
            var result = this._InventoryMovementsService.GetByFilter(model);
            return result;
        }

        /// <summary>
        /// Gets a InventoryOpeningBalanceViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get-inventory-movement/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalances/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalances/get/1 
		 */
        public InventoryMovementAddViewModel GetInventoryMovement(long id)
        {
            var result = this._InventoryMovementsService.GetInventoryMovement(id);
            return result;
        }

        [Route("add-inventory-movement")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalances/add
    		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalances/add-opening-balances 
		 */
        public InventoryMovementAddViewModel AddInventoryOpeningBalance([FromBody]InventoryMovementAddViewModel model)
        {
            var result = this._InventoryMovementsService.AddInventoryMovement(model);
            return result;
        }

        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [Route("update-inventory-movement")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOpeningBalances/add
    		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOpeningBalances/add-opening-balances 
		 */
        public InventoryMovementAddViewModel UpdateInventoryOpeningBalance([FromBody]InventoryMovementAddViewModel model)
        {
            var result = this._InventoryMovementsService.UpdateInventoryMovement(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovements/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovements/add-collection 
		 */
		public IList<InventoryMovementViewModel> Add([FromBody]IEnumerable<InventoryMovementViewModel> collection)
		{
			var result = this._InventoryMovementsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovements/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovements/add 
		 */
		public InventoryMovementViewModel Add([FromBody]InventoryMovementViewModel model)
		{
			var result = this._InventoryMovementsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovements/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovements/update-collection 
		 */
		public IList<InventoryMovementViewModel> Update([FromBody]IEnumerable<InventoryMovementViewModel> collection)
		{
			var result = this._InventoryMovementsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovements/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovements/update 
		 */
		public InventoryMovementViewModel Update([FromBody]InventoryMovementViewModel model)
		{
			var result = this._InventoryMovementsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovements/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovements/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<InventoryMovementViewModel> collection)
		{
			this._InventoryMovementsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovements/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovements/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._InventoryMovementsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovements/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovements/delete 
		 */
		public void Delete([FromBody]InventoryMovementViewModel model)
		{
			this._InventoryMovementsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovements/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovements/delete/1 
		 */
		public void Delete(long id)
		{
			this._InventoryMovementsService.Delete(id);
		}

		#endregion
	}
}
