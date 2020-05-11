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
    /// AssetInventoryDetails Controller
    /// </summary>
    [RoutePrefix("api/AssetInventoryDetails")]
    public class AssetInventoryDetailsController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IAssetInventoryDetailsService _AssetInventoryDetailsService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type AssetInventoryDetailController.
        /// </summary>
        /// <param name="AssetInventoryDetailsService">The injected service.</param>
        public AssetInventoryDetailsController(IAssetInventoryDetailsService AssetInventoryDetailsService)
        {
            this._AssetInventoryDetailsService = AssetInventoryDetailsService;
        }
        #endregion

        #region Actions

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetInventoryDetailViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventoryDetails/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventoryDetails/get-by-condition 
		 */
        public GenericCollectionViewModel<AssetInventoryDetailViewModel> Get(ConditionFilter<AssetInventoryDetail, long> condition)
        {
            var result = this._AssetInventoryDetailsService.Get(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetInventoryDetailViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventoryDetails/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventoryDetails/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<AssetInventoryDetailViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._AssetInventoryDetailsService.Get(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetInventoryDetailViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventoryDetails/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventoryDetails/get-light-by-condition 
		 */
        public GenericCollectionViewModel<AssetInventoryDetailLightViewModel> GetLightModel(ConditionFilter<AssetInventoryDetail, long> condition)
        {
            var result = this._AssetInventoryDetailsService.GetLightModel(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetInventoryDetailViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventoryDetails/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventoryDetails/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<AssetInventoryDetailLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var result = this._AssetInventoryDetailsService.GetLightModel(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a AssetInventoryDetailViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventoryDetails/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventoryDetails/get/1 
		 */
        public AssetInventoryDetailViewModel Get(long id)
        {
            var result = this._AssetInventoryDetailsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventoryDetails/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventoryDetails/add-collection 
		 */
        public IList<AssetInventoryDetailViewModel> Add([FromBody]IEnumerable<AssetInventoryDetailViewModel> collection)
        {
            var result = this._AssetInventoryDetailsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventoryDetails/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventoryDetails/add 
		 */
        public AssetInventoryDetailViewModel Add([FromBody]AssetInventoryDetailViewModel model)
        {
            var result = this._AssetInventoryDetailsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventoryDetails/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventoryDetails/update-collection 
		 */
        public IList<AssetInventoryDetailViewModel> Update([FromBody]IEnumerable<AssetInventoryDetailViewModel> collection)
        {
            var result = this._AssetInventoryDetailsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventoryDetails/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventoryDetails/update 
		 */
        public AssetInventoryDetailViewModel Update([FromBody]AssetInventoryDetailViewModel model)
        {
            var result = this._AssetInventoryDetailsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventoryDetails/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventoryDetails/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<AssetInventoryDetailViewModel> collection)
        {
            this._AssetInventoryDetailsService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventoryDetails/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventoryDetails/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._AssetInventoryDetailsService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventoryDetails/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventoryDetails/delete 
		 */
        public void Delete([FromBody]AssetInventoryDetailViewModel model)
        {
            this._AssetInventoryDetailsService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetInventoryDetails/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetInventoryDetails/delete/1 
		 */
        public void Delete(long id)
        {
            this._AssetInventoryDetailsService.Delete(id);
        }

        #endregion
    }
}
