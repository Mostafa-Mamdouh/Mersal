#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
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
	/// Depreciations Controller
	/// </summary>
	[RoutePrefix("api/Depreciations")]
    public class DepreciationsController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IDepreciationsService _DepreciationsService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type DepreciationController.
        /// </summary>
        /// <param name="DepreciationsService">The injected service.</param>
        public DepreciationsController(IDepreciationsService DepreciationsService)
        {
            this._DepreciationsService = DepreciationsService;
        }
        #endregion

        #region Actions

        /// <summary>
        /// Gets a GenericCollectionViewModel of DepreciationViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Depreciations/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Depreciations/get-by-condition 
		 */
        public GenericCollectionViewModel<DepreciationViewModel> Get(ConditionFilter<Depreciation, long> condition)
        {
            var result = this._DepreciationsService.Get(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DepreciationViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Depreciations/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Depreciations/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<DepreciationViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._DepreciationsService.Get(pageIndex, pageSize);
            return result;
        }


        /// <summary>
        /// Gets a GenericCollectionViewModel of DepreciationViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Depreciations/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Depreciations/get-light-by-condition 
		 */
        public GenericCollectionViewModel<DepreciationLightViewModel> GetLightModel(ConditionFilter<Depreciation, long> condition)
        {
            var result = this._DepreciationsService.GetLightModel(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DepreciationViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Depreciations/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Depreciations/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<DepreciationLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var result = this._DepreciationsService.GetLightModel(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a DepreciationViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        //[JwtAuthentication(Permissions.ReceivedFixedDepreciationsList)]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Depreciations/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Depreciations/get/1 
		 */
        public DepreciationViewModel Get(long id)
        {
            var result = this._DepreciationsService.Get(id);
            return result;
        }

        [Route("get-with-filter")]
        [HttpPost]
        //[JwtAuthentication(Permissions.ReceivedFixedDepreciationsList)]
        public GenericCollectionViewModel<ListAssetLightViewModel> GetByFilter(AssetFilterViewModel model)
        {
            var result = this._DepreciationsService.GetByFilter(model);
            return result;
        }

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("add-collection")]
        [HttpPost]
        //[JwtAuthentication(Permissions.AddReceivedFixedDepreciation)]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Depreciations/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Depreciations/add-collection 
		 */
        public IList<DepreciationViewModel> Add([FromBody]IEnumerable<DepreciationViewModel> collection)
        {
            var result = this._DepreciationsService.Add(collection);
            return result;
        }

        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("add")]
        [HttpPost]
        //[JwtAuthentication(Permissions.AddReceivedFixedDepreciation)]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Depreciations/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Depreciations/add 
		 */
        public DepreciationViewModel Add([FromBody]DepreciationViewModel model)
        {
            var result = this._DepreciationsService.Add(model);
            return result;
        }


        /// <summary>
        /// Update entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("update-collection")]
        [HttpPost]
        //[JwtAuthentication(Permissions.EditReceivedFixedDepreciation)]
        /*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Depreciations/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Depreciations/update-collection 
		 */
        public IList<DepreciationViewModel> Update([FromBody]IEnumerable<DepreciationViewModel> collection)
        {
            var result = this._DepreciationsService.Update(collection);
            return result;
        }

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("update")]
        [HttpPost]
        //[JwtAuthentication(Permissions.EditReceivedFixedDepreciation)]
        /*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Depreciations/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Depreciations/update 
		 */
        public DepreciationViewModel Update([FromBody]DepreciationViewModel model)
        {
            var result = this._DepreciationsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Depreciations/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Depreciations/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<DepreciationViewModel> collection)
        {
            this._DepreciationsService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Depreciations/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Depreciations/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._DepreciationsService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Depreciations/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Depreciations/delete 
		 */
        public void Delete([FromBody]DepreciationViewModel model)
        {
            this._DepreciationsService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Depreciations/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Depreciations/delete/1 
		 */
        public void Delete(long id)
        {
            this._DepreciationsService.Delete(id);
        }

        #endregion
    }
}
