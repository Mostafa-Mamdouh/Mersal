#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using MersalAccountingService.WebAPI.Auth;
using System.Collections.Generic;
using System.Web.Http;
#endregion

namespace MersalAccountingService.WebAPI.Controllers.API
{
    /// <summary>
    /// Locations Controller
    /// </summary>
    [RoutePrefix("api/Locations")]
    public class LocationsController : Base.BaseAPIController
    {
        #region Data Members
        private readonly ILocationsService _LocationsService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type LocationController.
        /// </summary>
        /// <param name="LocationsService">The injected service.</param>
        public LocationsController(ILocationsService LocationsService)
        {
            this._LocationsService = LocationsService;
        }
        #endregion

        #region Actions

        /// <summary>
        /// Gets a GenericCollectionViewModel of LocationViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Locations/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Locations/get-by-condition 
		 */
        public GenericCollectionViewModel<LocationViewModel> Get(ConditionFilter<Location, long> condition)
        {
            var result = this._LocationsService.Get(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of LocationViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Locations/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Locations/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<LocationViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._LocationsService.Get(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of LocationViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Locations/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Locations/get-light-by-condition 
		 */
        public GenericCollectionViewModel<LocationLightViewModel> GetLightModel(ConditionFilter<Location, long> condition)
        {
            var result = this._LocationsService.GetLightModel(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of LocationViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Locations/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Locations/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<LocationLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var result = this._LocationsService.GetLightModel(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a LocationViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Locations/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Locations/get/1 
		 */
        public LocationViewModel Get(long id)
        {
            var result = this._LocationsService.Get(id);
            return result;
        }


        [Route("get-with-filter")]
        [HttpPost]
        //[JwtAuthentication(Permissions.BanksList)]
        public GenericCollectionViewModel<ListLocationsLightViewModel> GetByFilter([FromBody]LocationFilterViewModel model)
        {
            var result = this._LocationsService.GetByFilter(model);
            return result;
        }

        [Route("get-children/{id}")]
        [HttpGet]
        //[JwtAuthentication(Permissions.BanksList)]
        public List<LocationLightViewModel> GetChildren(long id)
        {
            var result = this._LocationsService.GetChildren(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Locations/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Locations/add-collection 
		 */
        public IList<LocationViewModel> Add([FromBody]IEnumerable<LocationViewModel> collection)
        {
            var result = this._LocationsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Locations/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Locations/add 
		 */
        public LocationViewModel Add([FromBody]LocationViewModel model)
        {
            var result = this._LocationsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Locations/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Locations/update-collection 
		 */
        public IList<LocationViewModel> Update([FromBody]IEnumerable<LocationViewModel> collection)
        {
            var result = this._LocationsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Locations/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Locations/update 
		 */
        public LocationViewModel Update([FromBody]LocationViewModel model)
        {
            var result = this._LocationsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Locations/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Locations/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<LocationViewModel> collection)
        {
            this._LocationsService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Locations/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Locations/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._LocationsService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Locations/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Locations/delete 
		 */
        public void Delete([FromBody]LocationViewModel model)
        {
            this._LocationsService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Locations/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Locations/delete/1 
		 */
        public void Delete(long id)
        {
            this._LocationsService.Delete(id);
        }

        #endregion
    }
}
