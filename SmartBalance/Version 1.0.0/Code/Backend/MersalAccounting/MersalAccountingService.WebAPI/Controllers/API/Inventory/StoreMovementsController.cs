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
    /// StoreMovements Controller
    /// </summary>
    [RoutePrefix("api/StoreMovements")]
    public class StoreMovementsController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IStoreMovementsService _StoreMovementsService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type StoreMovementController.
        /// </summary>
        /// <param name="StoreMovementsService">The injected service.</param>
        public StoreMovementsController(IStoreMovementsService StoreMovementsService)
        {
            this._StoreMovementsService = StoreMovementsService;
        }
        #endregion

        #region Actions

        /// <summary>
        /// Gets a GenericCollectionViewModel of StoreMovementViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMovements/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMovements/get-by-condition 
		 */
        public GenericCollectionViewModel<StoreMovementViewModel> Get(ConditionFilter<StoreMovement, long> condition)
        {
            var result = this._StoreMovementsService.Get(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of StoreMovementViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMovements/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMovements/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<StoreMovementViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._StoreMovementsService.Get(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of StoreMovementViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMovements/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMovements/get-light-by-condition 
		 */
        public GenericCollectionViewModel<StoreMovementLightViewModel> GetLightModel(ConditionFilter<StoreMovement, long> condition)
        {
            var result = this._StoreMovementsService.GetLightModel(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of StoreMovementViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMovements/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMovements/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<StoreMovementLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var result = this._StoreMovementsService.GetLightModel(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a StoreMovementViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMovements/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMovements/get/1 
		 */
        public StoreMovementViewModel Get(long id)
        {
            var result = this._StoreMovementsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMovements/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMovements/add-collection 
		 */
        public IList<StoreMovementViewModel> Add([FromBody]IEnumerable<StoreMovementViewModel> collection)
        {
            var result = this._StoreMovementsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMovements/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMovements/add 
		 */
        public StoreMovementViewModel Add([FromBody]StoreMovementViewModel model)
        {
            var result = this._StoreMovementsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMovements/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMovements/update-collection 
		 */
        public IList<StoreMovementViewModel> Update([FromBody]IEnumerable<StoreMovementViewModel> collection)
        {
            var result = this._StoreMovementsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMovements/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMovements/update 
		 */
        public StoreMovementViewModel Update([FromBody]StoreMovementViewModel model)
        {
            var result = this._StoreMovementsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMovements/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMovements/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<StoreMovementViewModel> collection)
        {
            this._StoreMovementsService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMovements/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMovements/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._StoreMovementsService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMovements/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMovements/delete 
		 */
        public void Delete([FromBody]StoreMovementViewModel model)
        {
            this._StoreMovementsService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMovements/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMovements/delete/1 
		 */
        public void Delete(long id)
        {
            this._StoreMovementsService.Delete(id);
        }

        #endregion
    }
}
