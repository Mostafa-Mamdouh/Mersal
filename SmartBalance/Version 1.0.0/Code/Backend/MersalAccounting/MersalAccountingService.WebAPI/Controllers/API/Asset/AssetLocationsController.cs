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
    /// AssetLocations Controller
    /// </summary>
    [RoutePrefix("api/AssetLocations")]
    public class AssetLocationsController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IAssetLocationsService _AssetLocationsService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type AssetLocationController.
        /// </summary>
        /// <param name="AssetLocationsService">The injected service.</param>
        public AssetLocationsController(IAssetLocationsService AssetLocationsService)
        {
            this._AssetLocationsService = AssetLocationsService;
        }
        #endregion

        #region Actions

        [Route("get-with-filter")]
        [HttpPost]
        [JwtAuthentication(Permissions.AssetLocationList)]
        public GenericCollectionViewModel<ListAssetLocationsLightViewModel> GetByFilter([FromBody]AssetLocationsFilterViewModel model)
        {
            var result = this._AssetLocationsService.GetByFilter(model);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetLocationViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetLocations/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetLocations/get-by-condition 
		 */
        public GenericCollectionViewModel<AssetLocationViewModel> Get(ConditionFilter<AssetLocation, long> condition)
        {
            var result = this._AssetLocationsService.Get(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetLocationViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetLocations/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetLocations/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<AssetLocationViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._AssetLocationsService.Get(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetLocationViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetLocations/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetLocations/get-light-by-condition 
		 */
        public GenericCollectionViewModel<AssetLocationLightViewModel> GetLightModel(ConditionFilter<AssetLocation, long> condition)
        {
            var result = this._AssetLocationsService.GetLightModel(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetLocationViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetLocations/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetLocations/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<AssetLocationLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var result = this._AssetLocationsService.GetLightModel(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a AssetLocationViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetLocations/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetLocations/get/1 
		 */
        public AssetLocationViewModel Get(long id)
        {
            var result = this._AssetLocationsService.Get(id);
            return result;
        }


   //     [Route("get-lookup")]
   //     [HttpGet]
   //     /*
   //* HttpVerb: Get
   //* URL Pattern: http[s]://IPAddress:PortNumber/api/AssetLocations/get-lookup
   //* Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetLocations/get-lookup
   //*/
   //     public IList<AssetLocationLightViewModel> GetLookup()
   //     {
   //         var result = this._AssetLocationsService.GetLookup();
   //         return result;
   //     }


   //     /// <summary>
   //     /// Add entities.
   //     /// </summary>
   //     /// <param name="collection"></param>
   //     /// <returns></returns>
   //     [Route("add-collection")]
   //     [HttpPost]
   //     /*
		 //* HttpVerb: POST
		 //* URL Pattern: http[s]://IPAddress:PortNumber/api/AssetLocations/add-collection
		 //* Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetLocations/add-collection 
		 //*/
   //     public IList<AssetLocationViewModel> Add([FromBody]IEnumerable<AssetLocationViewModel> collection)
   //     {
   //         var result = this._AssetLocationsService.Add(collection);
   //         return result;
   //     }

   //     /// <summary>
   //     /// Add an entity.
   //     /// </summary>
   //     /// <param name="model"></param>
   //     /// <returns></returns>
   //     [Route("add")]
   //     [HttpPost]
   //     /*
		 //* HttpVerb: POST
		 //* URL Pattern: http[s]://IPAddress:PortNumber/api/AssetLocations/add
		 //* Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetLocations/add 
		 //*/
   //     public AssetLocationViewModel Add([FromBody]AssetLocationViewModel model)
   //     {
   //         var result = this._AssetLocationsService.Add(model);
   //         return result;
   //     }


        /// <summary>
        /// Update entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("update-collection")]
        [HttpPost]
        [JwtAuthentication(Permissions.EditAssetLocation)]
        /*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetLocations/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetLocations/update-collection 
		 */
        public IList<AssetLocationViewModel> Update([FromBody]IEnumerable<AssetLocationViewModel> collection)
        {
            var result = this._AssetLocationsService.Update(collection);
            return result;
        }

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("update")]
        [HttpPost]
        [JwtAuthentication(Permissions.EditAssetLocation)]
        /*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetLocations/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetLocations/update 
		 */
        public AssetLocationViewModel Update([FromBody]AssetLocationViewModel model)
        {
            var result = this._AssetLocationsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetLocations/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetLocations/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<AssetLocationViewModel> collection)
        {
            this._AssetLocationsService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetLocations/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetLocations/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._AssetLocationsService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetLocations/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetLocations/delete 
		 */
        public void Delete([FromBody]AssetLocationViewModel model)
        {
            this._AssetLocationsService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetLocations/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetLocations/delete/1 
		 */
        public void Delete(long id)
        {
            this._AssetLocationsService.Delete(id);
        }

        #endregion
    }
}
