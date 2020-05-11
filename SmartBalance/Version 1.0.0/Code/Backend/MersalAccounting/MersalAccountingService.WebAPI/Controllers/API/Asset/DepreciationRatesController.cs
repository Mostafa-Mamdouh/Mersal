#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using System.Collections.Generic;
using System.Web.Http;
#endregion

namespace MersalAccountingService.WebAPI.Controllers.API
{
    /// <summary>
    /// DepreciationRates Controller
    /// </summary>
    [RoutePrefix("api/DepreciationRates")]
    public class DepreciationRatesController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IDepreciationRatesService _DepreciationRatesService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type DepreciationRateController.
        /// </summary>
        /// <param name="DepreciationRatesService">The injected service.</param>
        public DepreciationRatesController(IDepreciationRatesService DepreciationRatesService)
        {
            this._DepreciationRatesService = DepreciationRatesService;
        }
        #endregion

        #region Actions

        /// <summary>
        /// Gets a GenericCollectionViewModel of DepreciationRateViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationRates/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationRates/get-by-condition 
		 */
        public GenericCollectionViewModel<DepreciationRateViewModel> Get(ConditionFilter<DepreciationRate, long> condition)
        {
            var result = this._DepreciationRatesService.Get(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DepreciationRateViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationRates/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationRates/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<DepreciationRateViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._DepreciationRatesService.Get(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DepreciationRateViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationRates/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationRates/get-light-by-condition 
		 */
        public GenericCollectionViewModel<DepreciationRateLightViewModel> GetLightModel(ConditionFilter<DepreciationRate, long> condition)
        {
            var result = this._DepreciationRatesService.GetLightModel(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DepreciationRateViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationRates/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationRates/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<DepreciationRateLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var result = this._DepreciationRatesService.GetLightModel(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a DepreciationRateViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationRates/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationRates/get/1 
		 */
        public DepreciationRateViewModel Get(long id)
        {
            var result = this._DepreciationRatesService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationRates/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationRates/add-collection 
		 */
        public IList<DepreciationRateViewModel> Add([FromBody]IEnumerable<DepreciationRateViewModel> collection)
        {
            var result = this._DepreciationRatesService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationRates/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationRates/add 
		 */
        public DepreciationRateViewModel Add([FromBody]DepreciationRateViewModel model)
        {
            var result = this._DepreciationRatesService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationRates/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationRates/update-collection 
		 */
        public IList<DepreciationRateViewModel> Update([FromBody]IEnumerable<DepreciationRateViewModel> collection)
        {
            var result = this._DepreciationRatesService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationRates/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationRates/update 
		 */
        public DepreciationRateViewModel Update([FromBody]DepreciationRateViewModel model)
        {
            var result = this._DepreciationRatesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationRates/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationRates/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<DepreciationRateViewModel> collection)
        {
            this._DepreciationRatesService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationRates/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationRates/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._DepreciationRatesService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationRates/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationRates/delete 
		 */
        public void Delete([FromBody]DepreciationRateViewModel model)
        {
            this._DepreciationRatesService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationRates/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationRates/delete/1 
		 */
        public void Delete(long id)
        {
            this._DepreciationRatesService.Delete(id);
        }

        #endregion
    }
}
