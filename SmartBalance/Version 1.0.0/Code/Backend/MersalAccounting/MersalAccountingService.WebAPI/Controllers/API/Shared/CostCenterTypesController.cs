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
    /// CostCenterTypes Controller
    /// </summary>
    [RoutePrefix("api/CostCenterTypes")]
    public class CostCenterTypesController : Base.BaseAPIController
    {
        #region Data Members
        private readonly ICostCenterTypesService _CostCenterTypesService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type CostCenterTypeController.
        /// </summary>
        /// <param name="CostCenterTypesService">The injected service.</param>
        public CostCenterTypesController(ICostCenterTypesService CostCenterTypesService)
        {
            this._CostCenterTypesService = CostCenterTypesService;
        }
        #endregion

        #region Actions

        [Route("get-with-filter")]
        [HttpPost]
        //[JwtAuthentication(Permissions.BanksList)]
        public GenericCollectionViewModel<ListCostCenterTypesLightViewModel> GetByFilter([FromBody]CostCenterTypesFilterViewModel model)
        {
            var result = this._CostCenterTypesService.GetByFilter(model);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of CostCenterTypeViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenterTypes/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenterTypes/get-by-condition 
		 */
        public GenericCollectionViewModel<CostCenterTypeViewModel> Get(ConditionFilter<CostCenterType, long> condition)
        {
            var result = this._CostCenterTypesService.Get(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of CostCenterTypeViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenterTypes/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenterTypes/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<CostCenterTypeViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._CostCenterTypesService.Get(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of CostCenterTypeViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenterTypes/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenterTypes/get-light-by-condition 
		 */
        public GenericCollectionViewModel<CostCenterTypeLightViewModel> GetLightModel(ConditionFilter<CostCenterType, long> condition)
        {
            var result = this._CostCenterTypesService.GetLightModel(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of CostCenterTypeViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenterTypes/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenterTypes/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<CostCenterTypeLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var result = this._CostCenterTypesService.GetLightModel(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a CostCenterTypeViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenterTypes/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenterTypes/get/1 
		 */
        public CostCenterTypeViewModel Get(long id)
        {
            var result = this._CostCenterTypesService.Get(id);
            return result;
        }


        //     [Route("get-lookup")]
        //     [HttpGet]
        //     /*
        //* HttpVerb: Get
        //* URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenterTypes/get-lookup
        //* Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenterTypes/get-lookup
        //*/
        //     public IList<CostCenterTypeLightViewModel> GetLookup()
        //     {
        //         var result = this._CostCenterTypesService.GetLookup();
        //         return result;
        //     }

        //     /// <summary>
        //     /// Gets a GenericCollectionViewModel of ListCostCenterTypesLightViewModel by condition.
        //     /// </summary>
        //     /// <param name="condition"></param>
        //     /// <returns></returns>
        //     [Route("get-with-filter")]
        //     [HttpPost]
        //     /*
        //* HttpVerb: POST
        //* URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenterTypes/get-with-filter
        //* Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenterTypes/get-with-filter 
        //*/
        //     public GenericCollectionViewModel<ListCostCenterTypesLightViewModel> GetByFilter([FromBody]CostCenterTypeFilterViewModel model)
        //     {
        //         var result = this._CostCenterTypesService.GetByFilter(model);
        //         return result;
        //     }

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("add-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenterTypes/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenterTypes/add-collection 
		 */
        public IList<CostCenterTypeViewModel> Add([FromBody]IEnumerable<CostCenterTypeViewModel> collection)
        {
            var result = this._CostCenterTypesService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenterTypes/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenterTypes/add 
		 */
        public CostCenterTypeViewModel Add([FromBody]CostCenterTypeViewModel model)
        {
            var result = this._CostCenterTypesService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenterTypes/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenterTypes/update-collection 
		 */
        public IList<CostCenterTypeViewModel> Update([FromBody]IEnumerable<CostCenterTypeViewModel> collection)
        {
            var result = this._CostCenterTypesService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenterTypes/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenterTypes/update 
		 */
        public CostCenterTypeViewModel Update([FromBody]CostCenterTypeViewModel model)
        {
            var result = this._CostCenterTypesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenterTypes/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenterTypes/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<CostCenterTypeViewModel> collection)
        {
            this._CostCenterTypesService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenterTypes/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenterTypes/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._CostCenterTypesService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenterTypes/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenterTypes/delete 
		 */
        public void Delete([FromBody]CostCenterTypeViewModel model)
        {
            this._CostCenterTypesService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenterTypes/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenterTypes/delete/1 
		 */
        public void Delete(long id)
        {
            this._CostCenterTypesService.Delete(id);
        }

        #endregion
    }
}
