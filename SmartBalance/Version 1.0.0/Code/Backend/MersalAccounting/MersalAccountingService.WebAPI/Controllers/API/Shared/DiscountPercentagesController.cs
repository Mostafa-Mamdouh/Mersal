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
    /// DiscountPercentages Controller
    /// </summary>
    [RoutePrefix("api/DiscountPercentages")]
    public class DiscountPercentagesController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IDiscountPercentagesService _DiscountPercentagesService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type DiscountPercentageController.
        /// </summary>
        /// <param name="DiscountPercentagesService">The injected service.</param>
        public DiscountPercentagesController(IDiscountPercentagesService DiscountPercentagesService)
        {
            this._DiscountPercentagesService = DiscountPercentagesService;
        }
        #endregion

        #region Actions

        [Route("get-with-filter")]
        [HttpPost]
        [JwtAuthentication(Permissions.DiscountPercentageList)]
        public GenericCollectionViewModel<ListDiscountPercentegesLightViewModel> GetByFilter([FromBody]DiscountPercentageFilterViewModel model)
        {
            var result = this._DiscountPercentagesService.GetByFilter(model);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DiscountPercentageViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DiscountPercentages/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DiscountPercentages/get-by-condition 
		 */
        public GenericCollectionViewModel<DiscountPercentageViewModel> Get(ConditionFilter<DiscountPercentage, long> condition)
        {
            var result = this._DiscountPercentagesService.Get(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DiscountPercentageViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DiscountPercentages/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DiscountPercentages/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<DiscountPercentageViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._DiscountPercentagesService.Get(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DiscountPercentageViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DiscountPercentages/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DiscountPercentages/get-light-by-condition 
		 */
        public GenericCollectionViewModel<DiscountPercentageLightViewModel> GetLightModel(ConditionFilter<DiscountPercentage, long> condition)
        {
            var result = this._DiscountPercentagesService.GetLightModel(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DiscountPercentageViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DiscountPercentages/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DiscountPercentages/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<DiscountPercentageLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var result = this._DiscountPercentagesService.GetLightModel(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a DiscountPercentageViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        [JwtAuthentication(Permissions.DiscountPercentageList)]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DiscountPercentages/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DiscountPercentages/get/1 
		 */
        public DiscountPercentageViewModel Get(long id)
        {
            var result = this._DiscountPercentagesService.Get(id);
            return result;
        }


        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("add-collection")]
        [HttpPost]
        [JwtAuthentication(Permissions.AddDiscountPercentage)]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DiscountPercentages/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DiscountPercentages/add-collection 
		 */
        public IList<DiscountPercentageViewModel> Add([FromBody]IEnumerable<DiscountPercentageViewModel> collection)
        {
            var result = this._DiscountPercentagesService.Add(collection);
            return result;
        }

        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("add")]
        [HttpPost]
        [JwtAuthentication(Permissions.AddDiscountPercentage)]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DiscountPercentages/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DiscountPercentages/add 
		 */
        public DiscountPercentageViewModel Add([FromBody]DiscountPercentageViewModel model)
        {
            var result = this._DiscountPercentagesService.Add(model);
            return result;
        }


        /// <summary>
        /// Update entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("update-collection")]
        [HttpPost]
        [JwtAuthentication(Permissions.EditDiscountPercentage)]
        /*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DiscountPercentages/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DiscountPercentages/update-collection 
		 */
        public IList<DiscountPercentageViewModel> Update([FromBody]IEnumerable<DiscountPercentageViewModel> collection)
        {
            var result = this._DiscountPercentagesService.Update(collection);
            return result;
        }

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("update")]
        [HttpPost]
        [JwtAuthentication(Permissions.EditDiscountPercentage)]
        /*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DiscountPercentages/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DiscountPercentages/update 
		 */
        public DiscountPercentageViewModel Update([FromBody]DiscountPercentageViewModel model)
        {
            var result = this._DiscountPercentagesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DiscountPercentages/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DiscountPercentages/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<DiscountPercentageViewModel> collection)
        {
            this._DiscountPercentagesService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DiscountPercentages/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DiscountPercentages/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._DiscountPercentagesService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DiscountPercentages/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DiscountPercentages/delete 
		 */
        public void Delete([FromBody]DiscountPercentageViewModel model)
        {
            this._DiscountPercentagesService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DiscountPercentages/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DiscountPercentages/delete/1 
		 */
        public void Delete(long id)
        {
            this._DiscountPercentagesService.Delete(id);
        }

        #endregion
    }
}
