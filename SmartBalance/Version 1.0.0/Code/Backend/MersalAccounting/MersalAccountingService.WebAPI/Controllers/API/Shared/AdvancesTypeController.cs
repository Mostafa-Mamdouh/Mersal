using Framework.Core.Filters;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MersalAccountingService.WebAPI.Controllers.API
{
    [RoutePrefix("api/AdvancesTypes")]
    public class AdvancesTypeController : ApiController
    {
        #region Data Members
        private readonly IAdvancesTypeService _AdvancesTypeService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type AdvancesTypeController.
        /// </summary>
        /// <param name="AdvancesTypeService">The injected service.</param>
        public AdvancesTypeController(IAdvancesTypeService AdvancesTypeService)
        {
            this._AdvancesTypeService = AdvancesTypeService;
        }
        #endregion

        #region Actions

        //[Route("get-with-filter")]
        //[HttpPost]
        ////[JwtAuthentication(Permissions.AdvancesTypeList)]
        //public GenericCollectionViewModel<ListDiscountPercentegesLightViewModel> GetByFilter([FromBody]AdvancesTypeFilterViewModel model)
        //{
        //    var result = this._AdvancesTypeService.GetByFilter(model);
        //    return result;
        //}

        /// <summary>
        /// Gets a GenericCollectionViewModel of AdvancesTypeViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AdvancesType/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AdvancesType/get-by-condition 
		 */
        public GenericCollectionViewModel<AdvancesTypeViewModel> Get(ConditionFilter<AdvancesType, int> condition)
        {
            var result = this._AdvancesTypeService.Get(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AdvancesTypeViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AdvancesType/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AdvancesType/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<AdvancesTypeViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._AdvancesTypeService.Get(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AdvancesTypeViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AdvancesType/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AdvancesType/get-light-by-condition 
		 */
        public GenericCollectionViewModel<AdvancesTypeLightViewModel> GetLightModel(ConditionFilter<AdvancesType, int> condition)
        {
            var result = this._AdvancesTypeService.GetLightModel(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AdvancesTypeViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AdvancesType/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AdvancesType/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<AdvancesTypeLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var result = this._AdvancesTypeService.GetLightModel(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a AdvancesTypeViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        //[JwtAuthentication(Permissions.AdvancesTypeList)]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AdvancesType/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AdvancesType/get/1 
		 */
        public AdvancesTypeViewModel Get(int id)
        {
            var result = this._AdvancesTypeService.Get(id);
            return result;
        }


        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("add-collection")]
        [HttpPost]
        //[JwtAuthentication(Permissions.AddAdvancesType)]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AdvancesType/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AdvancesType/add-collection 
		 */
        public IList<AdvancesTypeViewModel> Add([FromBody]IEnumerable<AdvancesTypeViewModel> collection)
        {
            var result = this._AdvancesTypeService.Add(collection);
            return result;
        }

        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("add")]
        [HttpPost]
        //[JwtAuthentication(Permissions.AddAdvancesType)]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AdvancesType/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AdvancesType/add 
		 */
        public AdvancesTypeViewModel Add([FromBody]AdvancesTypeViewModel model)
        {
            var result = this._AdvancesTypeService.Add(model);
            return result;
        }


        /// <summary>
        /// Update entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("update-collection")]
        [HttpPost]
        //[JwtAuthentication(Permissions.EditAdvancesType)]
        /*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AdvancesType/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AdvancesType/update-collection 
		 */
        public IList<AdvancesTypeViewModel> Update([FromBody]IEnumerable<AdvancesTypeViewModel> collection)
        {
            var result = this._AdvancesTypeService.Update(collection);
            return result;
        }

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("update")]
        [HttpPost]
        //[JwtAuthentication(Permissions.EditAdvancesType)]
        /*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AdvancesType/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AdvancesType/update 
		 */
        public AdvancesTypeViewModel Update([FromBody]AdvancesTypeViewModel model)
        {
            var result = this._AdvancesTypeService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AdvancesType/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AdvancesType/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<AdvancesTypeViewModel> collection)
        {
            this._AdvancesTypeService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AdvancesType/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AdvancesType/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<int> collection)
        {
            this._AdvancesTypeService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AdvancesType/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AdvancesType/delete 
		 */
        public void Delete([FromBody]AdvancesTypeViewModel model)
        {
            this._AdvancesTypeService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AdvancesType/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AdvancesType/delete/1 
		 */
        public void Delete(int id)
        {
            this._AdvancesTypeService.Delete(id);
        }

        #endregion
    }
}
