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
    /// AssetInventorys Controller
    /// </summary>
    [RoutePrefix("api/AssetInventorys")]
    public class AssetInventorysController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IAssetInventorysService _AssetInventorysService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type AssetInventoryController.
        /// </summary>
        /// <param name="AssetInventorysService">The injected service.</param>
        public AssetInventorysController(IAssetInventorysService AssetInventorysService)
        {
            this._AssetInventorysService = AssetInventorysService;
        }
        #endregion

        #region Actions

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetInventoryViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventorys/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventorys/get-by-condition 
		 */
        public GenericCollectionViewModel<AssetInventoryViewModel> Get(ConditionFilter<AssetInventory, long> condition)
        {
            var result = this._AssetInventorysService.Get(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetInventoryViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventorys/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventorys/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<AssetInventoryViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._AssetInventorysService.Get(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetInventoryViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventorys/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventorys/get-light-by-condition 
		 */
        public GenericCollectionViewModel<AssetInventoryLightViewModel> GetLightModel(ConditionFilter<AssetInventory, long> condition)
        {
            var result = this._AssetInventorysService.GetLightModel(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetInventoryViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventorys/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventorys/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<AssetInventoryLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var result = this._AssetInventorysService.GetLightModel(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a AssetInventoryViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventorys/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventorys/get/1 
		 */
        public AssetInventoryViewModel Get(long id)
        {
            var result = this._AssetInventorysService.Get(id);
            return result;
        }


        [Route("get-with-filter")]
        [HttpPost]
        public GenericCollectionViewModel<ListAssetInventorysLightViewModel> GetByFilter([FromBody]AssetInventoryFilterViewModel model)
        {
            var result = this._AssetInventorysService.GetByFilter(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventorys/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventorys/add-collection 
		 */
        public IList<AssetInventoryViewModel> Add([FromBody]IEnumerable<AssetInventoryViewModel> collection)
        {
            var result = this._AssetInventorysService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventorys/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventorys/add 
		 */
        public AssetInventoryViewModel Add([FromBody]AssetInventoryViewModel model)
        {
            var result = this._AssetInventorysService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventorys/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventorys/update-collection 
		 */
        public IList<AssetInventoryViewModel> Update([FromBody]IEnumerable<AssetInventoryViewModel> collection)
        {
            var result = this._AssetInventorysService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventorys/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventorys/update 
		 */
        public AssetInventoryViewModel Update([FromBody]AssetInventoryViewModel model)
        {
            var result = this._AssetInventorysService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventorys/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventorys/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<AssetInventoryViewModel> collection)
        {
            this._AssetInventorysService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventorys/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventorys/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._AssetInventorysService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventorys/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventorys/delete 
		 */
        public void Delete([FromBody]AssetInventoryViewModel model)
        {
            this._AssetInventorysService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventorys/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventorys/delete/1 
		 */
        public void Delete(long id)
        {
            this._AssetInventorysService.Delete(id);
        }

        #endregion
    }
}
