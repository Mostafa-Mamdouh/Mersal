using Framework.Core.Filters;
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

namespace MersalAccountingService.WebAPI.Controllers.API
{
    /// <summary>
	/// SafeAccountChart Controller
	/// </summary>
	[RoutePrefix("api/SafeAccountCharts")]
    public class SafeAccountChartsController : Base.BaseAPIController
    {
        #region Data Members
        private readonly ISafeAccountChartsService _safeAccountChartsService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type SafeAccountChartsController.
        /// </summary>
        /// <param name="SafeAccountChartsService">The injected service.</param>
        public SafeAccountChartsController(ISafeAccountChartsService safeAccountChartsService)
        {
            this._safeAccountChartsService = safeAccountChartsService;
        }
        #endregion

        #region Actions

        /// <summary>
        /// Gets a GenericCollectionViewModel of SafeAccountChartViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/safeAccountChart/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/safeAccountChart/get-by-condition 
		 */
        public GenericCollectionViewModel<SafeAccountChartViewModel> Get(ConditionFilter<SafeAccountChart, long> condition)
        {
            var result = this._safeAccountChartsService.Get(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of safeAccountChartViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/safeAccountChart/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/safeAccountChart/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<SafeAccountChartViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._safeAccountChartsService.Get(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of SafeAccountChartViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/safeAccountChart/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/safeAccountChart/get-light-by-condition 
		 */
        public GenericCollectionViewModel<SafeAccountChartLightViewModel> GetLightModel(ConditionFilter<SafeAccountChart, long> condition)
        {
            var result = this._safeAccountChartsService.GetLightModel(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of SafeAccountChartViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/safeAccountChart/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/safeAccountChart/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<SafeAccountChartLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var result = this._safeAccountChartsService.GetLightModel(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a SafeAccountChartViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{bankId}/{accountChartId}")]
        [HttpGet]
        public SafeAccountChartViewModel Get(long bankId, long accountChartId)
        {
            var result = this._safeAccountChartsService.Get(bankId, accountChartId);
            return result;
        }

        [Route("get-account-charts/{bankId}")]
        [HttpGet]
        public List<AccountChartLightViewModel> GetAccountCharts(long bankId)
        {
            return this._safeAccountChartsService.GetAccountCharts(bankId);
        }


        [Route("get/{id}")]
        [HttpGet]
        [JwtAuthentication(Permissions.SafeAccountChartsList)]
        public List<SafeAccountChartViewModel> Get(long id)
        {
            var result = this._safeAccountChartsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SafeAccountCharts/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SafeAccountCharts/add-collection 
		 */
        public IList<SafeAccountChartViewModel> Add([FromBody]IEnumerable<SafeAccountChartViewModel> collection)
        {
            var result = this._safeAccountChartsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SafeAccountCharts/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/safeAccountChart/add 
		 */
        public SafeAccountChartViewModel Add([FromBody]SafeAccountChartViewModel model)
        {
            var result = this._safeAccountChartsService.Add(model);
            return result;
        }


        /// <summary>
        /// Update entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("update-collection")]
        [HttpPost]
        [JwtAuthentication(Permissions.EditSafeAccountCharts)]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/safeAccountChart/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/safeAccountChart/update-collection 
		 */
        public IList<SafeAccountChartViewModel> Update([FromBody]IEnumerable<SafeAccountChartViewModel> collection)
        {
            var result = this._safeAccountChartsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/safeAccountChart/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/safeAccountChart/update 
		 */
        public SafeAccountChartViewModel Update([FromBody]SafeAccountChartViewModel model)
        {
            var result = this._safeAccountChartsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/safeAccountChart/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/safeAccountChart/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<SafeAccountChartViewModel> collection)
        {
            this._safeAccountChartsService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/safeAccountChart/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/safeAccountChart/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._safeAccountChartsService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/safeAccountChart/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/safeAccountChart/delete 
		 */
        public void Delete([FromBody]SafeAccountChartViewModel model)
        {
            this._safeAccountChartsService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/safeAccountChart/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/safeAccountChart/delete/1 
		 */
        public void Delete(long id)
        {
            this._safeAccountChartsService.Delete(id);
        }

        #endregion
    }
}
