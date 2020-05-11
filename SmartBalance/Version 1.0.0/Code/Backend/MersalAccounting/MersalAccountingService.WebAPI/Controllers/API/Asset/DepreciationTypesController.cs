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
    /// DepreciationTypes Controller
    /// </summary>
    [RoutePrefix("api/DepreciationTypes")]
    public class DepreciationTypesController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IDepreciationTypesService _DepreciationTypesService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type DepreciationTypeController.
        /// </summary>
        /// <param name="DepreciationTypesService">The injected service.</param>
        public DepreciationTypesController(IDepreciationTypesService DepreciationTypesService)
        {
            this._DepreciationTypesService = DepreciationTypesService;
        }
        #endregion

        #region Actions

        /// <summary>
        /// Gets a GenericCollectionViewModel of DepreciationTypeViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationTypes/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationTypes/get-by-condition 
		 */
        public GenericCollectionViewModel<DepreciationTypeViewModel> Get(ConditionFilter<DepreciationType, long> condition)
        {
            var result = this._DepreciationTypesService.Get(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DepreciationTypeViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationTypes/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationTypes/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<DepreciationTypeViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._DepreciationTypesService.Get(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DepreciationTypeViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationTypes/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationTypes/get-light-by-condition 
		 */
        public GenericCollectionViewModel<DepreciationTypeLightViewModel> GetLightModel(ConditionFilter<DepreciationType, long> condition)
        {
            var result = this._DepreciationTypesService.GetLightModel(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DepreciationTypeViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationTypes/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationTypes/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<DepreciationTypeLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var result = this._DepreciationTypesService.GetLightModel(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a DepreciationTypeViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationTypes/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationTypes/get/1 
		 */
        public DepreciationTypeViewModel Get(long id)
        {
            var result = this._DepreciationTypesService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationTypes/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationTypes/add-collection 
		 */
        public IList<DepreciationTypeViewModel> Add([FromBody]IEnumerable<DepreciationTypeViewModel> collection)
        {
            var result = this._DepreciationTypesService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationTypes/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationTypes/add 
		 */
        public DepreciationTypeViewModel Add([FromBody]DepreciationTypeViewModel model)
        {
            var result = this._DepreciationTypesService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationTypes/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationTypes/update-collection 
		 */
        public IList<DepreciationTypeViewModel> Update([FromBody]IEnumerable<DepreciationTypeViewModel> collection)
        {
            var result = this._DepreciationTypesService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationTypes/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationTypes/update 
		 */
        public DepreciationTypeViewModel Update([FromBody]DepreciationTypeViewModel model)
        {
            var result = this._DepreciationTypesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationTypes/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationTypes/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<DepreciationTypeViewModel> collection)
        {
            this._DepreciationTypesService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationTypes/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationTypes/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._DepreciationTypesService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationTypes/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationTypes/delete 
		 */
        public void Delete([FromBody]DepreciationTypeViewModel model)
        {
            this._DepreciationTypesService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DepreciationTypes/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DepreciationTypes/delete/1 
		 */
        public void Delete(long id)
        {
            this._DepreciationTypesService.Delete(id);
        }

        #endregion
    }
}
