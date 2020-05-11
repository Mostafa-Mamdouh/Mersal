#region Using ...
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
#endregion

namespace MersalAccountingService.WebAPI.Controllers.API
{
	/// <summary>
	/// 
	/// </summary>
    [RoutePrefix("api/Excludes")]
    public class ExcludesController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IExcludesService _ExcludesService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ExcludeController.
        /// </summary>
        /// <param name="ExcludesService">The injected service.</param>
        public ExcludesController(IExcludesService ExcludesService)
        {
            this._ExcludesService = ExcludesService;
        }
        #endregion

        #region Actions

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExcludeViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Excludes/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Excludes/get-by-condition 
		 */
        public GenericCollectionViewModel<ExcludeViewModel> Get(ConditionFilter<Exclude, long> condition)
        {
            var result = this._ExcludesService.Get(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExcludeViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Excludes/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Excludes/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<ExcludeViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._ExcludesService.Get(pageIndex, pageSize);
            return result;
        }


        /// <summary>
        /// Gets a GenericCollectionViewModel of ExcludeViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Excludes/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Excludes/get-light-by-condition 
		 */
        public GenericCollectionViewModel<ExcludeLightViewModel> GetLightModel(ConditionFilter<Exclude, long> condition)
        {
            var result = this._ExcludesService.GetLightModel(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExcludeViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Excludes/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Excludes/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<ExcludeLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var result = this._ExcludesService.GetLightModel(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a ExcludeViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        //[JwtAuthentication(Permissions.ReceivedFixedExcludesList)]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Excludes/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Excludes/get/1 
		 */
        public ExcludeViewModel Get(long id)
        {
            var result = this._ExcludesService.Get(id);
            return result;
        }

        [Route("get-with-filter")]
        [HttpPost]
        //[JwtAuthentication(Permissions.ReceivedFixedExcludesList)]
        public GenericCollectionViewModel<ListExcludeLightViewModel> GetByFilter(AssetFilterViewModel model)
        {
            var result = this._ExcludesService.GetByFilter(model);
            return result;
        }

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("add-collection")]
        [HttpPost]
        //[JwtAuthentication(Permissions.AddReceivedFixedExclude)]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Excludes/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Excludes/add-collection 
		 */
        public IList<ExcludeViewModel> Add([FromBody]IEnumerable<ExcludeViewModel> collection)
        {
            var result = this._ExcludesService.Add(collection);
            return result;
        }

        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("add")]
        [HttpPost]
        //[JwtAuthentication(Permissions.AddReceivedFixedExclude)]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Excludes/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Excludes/add 
		 */
        public ExcludeViewModel Add([FromBody]ExcludeViewModel model)
        {
            var result = this._ExcludesService.Add(model);
            return result;
        }


        /// <summary>
        /// Update entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("update-collection")]
        [HttpPost]
        //[JwtAuthentication(Permissions.EditReceivedFixedExclude)]
        /*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Excludes/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Excludes/update-collection 
		 */
        public IList<ExcludeViewModel> Update([FromBody]IEnumerable<ExcludeViewModel> collection)
        {
            var result = this._ExcludesService.Update(collection);
            return result;
        }

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("update")]
        [HttpPost]
        //[JwtAuthentication(Permissions.EditReceivedFixedExclude)]
        /*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Excludes/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Excludes/update 
		 */
        public ExcludeViewModel Update([FromBody]ExcludeViewModel model)
        {
            var result = this._ExcludesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Excludes/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Excludes/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<ExcludeViewModel> collection)
        {
            this._ExcludesService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Excludes/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Excludes/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._ExcludesService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Excludes/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Excludes/delete 
		 */
        public void Delete([FromBody]ExcludeViewModel model)
        {
            this._ExcludesService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Excludes/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Excludes/delete/1 
		 */
        public void Delete(long id)
        {
            this._ExcludesService.Delete(id);
        }

        #endregion
    }
}
