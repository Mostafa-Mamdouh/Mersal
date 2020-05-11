#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.Common;
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
    /// ClosedMonths Controller
    /// </summary>
    [RoutePrefix("api/ClosedMonths")]
    public class ClosedMonthsController : Base.BaseAPIController
    {
        #region Data Members
        private readonly ICurrentUserService _currentUserService;
        private readonly IClosedMonthsService _ClosedMonthsService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ClosedMonthController.
        /// </summary>
        /// <param name="currentUserService">The injected currentUserService.</param>
        /// <param name="ClosedMonthsService">The injected service.</param>
        public ClosedMonthsController(
            ICurrentUserService currentUserService,
            IClosedMonthsService ClosedMonthsService)
        {
            this._currentUserService = currentUserService;
            this._ClosedMonthsService = ClosedMonthsService;
        }
        #endregion

        #region Actions

        /// <summary>
        /// Gets a GenericCollectionViewModel of ClosedMonthViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ClosedMonths/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ClosedMonths/get-by-condition 
		 */
        public GenericCollectionViewModel<ClosedMonthViewModel> Get(ConditionFilter<ClosedMonth, long> condition)
        {
            var result = this._ClosedMonthsService.Get(condition);
            return result;
        }

        [Route("get-with-filter")]
        [HttpPost]
        //[JwtAuthentication(Permissions.ClosedMonthsList)]
        public GenericCollectionViewModel<ListClosedMonthsLightViewModel> GetByFilter(ClosedMonthsFilterViewModel model)
        {
            var result = this._ClosedMonthsService.GetByFilter(model);
            return result;
        }


        /// <summary>
        /// Gets a GenericCollectionViewModel of ClosedMonthViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ClosedMonths/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ClosedMonths/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<ClosedMonthViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._ClosedMonthsService.Get(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ClosedMonthViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ClosedMonths/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ClosedMonths/get-light-by-condition 
		 */
        public GenericCollectionViewModel<ClosedMonthLightViewModel> GetLightModel(ConditionFilter<ClosedMonth, long> condition)
        {
            var result = this._ClosedMonthsService.GetLightModel(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ClosedMonthViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ClosedMonths/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ClosedMonths/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<ClosedMonthLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var result = this._ClosedMonthsService.GetLightModel(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a ClosedMonthViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ClosedMonths/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ClosedMonths/get/1 
		 */
        public ClosedMonthViewModel Get(long id)
        {
            var result = this._ClosedMonthsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ClosedMonths/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ClosedMonths/add-collection 
		 */
        public IList<ClosedMonthViewModel> Add([FromBody]IEnumerable<ClosedMonthViewModel> collection)
        {
            var result = this._ClosedMonthsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ClosedMonths/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ClosedMonths/add 
		 */
        public ClosedMonthViewModel Add([FromBody]ClosedMonthViewModel model)
        {
            var result = this._ClosedMonthsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ClosedMonths/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ClosedMonths/update-collection 
		 */
        public IList<ClosedMonthViewModel> Update([FromBody]IEnumerable<ClosedMonthViewModel> collection)
        {
            var result = this._ClosedMonthsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ClosedMonths/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ClosedMonths/update 
		 */
        public ClosedMonthViewModel Update([FromBody]ClosedMonthViewModel model)
        {
            var result = this._ClosedMonthsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ClosedMonths/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ClosedMonths/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<ClosedMonthViewModel> collection)
        {
            this._ClosedMonthsService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ClosedMonths/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ClosedMonths/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._ClosedMonthsService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ClosedMonths/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ClosedMonths/delete 
		 */
        public void Delete([FromBody]ClosedMonthViewModel model)
        {
            this._ClosedMonthsService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ClosedMonths/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ClosedMonths/delete/1 
		 */
        public void Delete(long id)
        {
            this._ClosedMonthsService.Delete(id);
        }

        #endregion
    }
}
