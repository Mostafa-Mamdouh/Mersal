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
    /// ExpensesTypes Controller
    /// </summary>
    [RoutePrefix("api/ExpensesTypes")]
    public class ExpensesTypesController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IExpensesTypesService _ExpensesTypesService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ExpensesTypeController.
        /// </summary>
        /// <param name="ExpensesTypesService">The injected service.</param>
        public ExpensesTypesController(IExpensesTypesService ExpensesTypesService)
        {
            this._ExpensesTypesService = ExpensesTypesService;
        }
        #endregion

        #region Actions

        [Route("get-with-filter")]
        [HttpPost]
        //[JwtAuthentication(Permissions.BanksList)]
        public GenericCollectionViewModel<ListExpensesTypesLightViewModel> GetByFilter([FromBody]ExpensesTypesFilterViewModel model)
        {
            var result = this._ExpensesTypesService.GetByFilter(model);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExpensesTypeViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExpensesTypes/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExpensesTypes/get-by-condition 
		 */
        public GenericCollectionViewModel<ExpensesTypeViewModel> Get(ConditionFilter<ExpensesType, long> condition)
        {
            var result = this._ExpensesTypesService.Get(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExpensesTypeViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExpensesTypes/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExpensesTypes/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<ExpensesTypeViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._ExpensesTypesService.Get(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExpensesTypeViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExpensesTypes/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExpensesTypes/get-light-by-condition 
		 */
        public GenericCollectionViewModel<ExpensesTypeLightViewModel> GetLightModel(ConditionFilter<ExpensesType, long> condition)
        {
            var result = this._ExpensesTypesService.GetLightModel(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExpensesTypeViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExpensesTypes/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExpensesTypes/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<ExpensesTypeLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var result = this._ExpensesTypesService.GetLightModel(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a ExpensesTypeViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExpensesTypes/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExpensesTypes/get/1 
		 */
        public ExpensesTypeViewModel Get(long id)
        {
            var result = this._ExpensesTypesService.Get(id);
            return result;
        }


   //     [Route("get-lookup")]
   //     [HttpGet]
   //     /*
		 //* HttpVerb: Get
		 //* URL Pattern: http[s]://IPAddress:PortNumber/api/ExpensesTypes/get-lookup
		 //* Usage: http://localhost/MersalAccountingService.WebAPI/api/ExpensesTypes/get-lookup
		 //*/
   //     public IList<ExpensesTypeLightViewModel> GetLookup()
   //     {
   //         var result = this._ExpensesTypesService.GetLookup();
   //         return result;
   //     }

   //     /// <summary>
   //     /// Gets a GenericCollectionViewModel of ListExpensesTypesLightViewModel by condition.
   //     /// </summary>
   //     /// <param name="condition"></param>
   //     /// <returns></returns>
   //     [Route("get-with-filter")]
   //     [HttpPost]
   //     /*
		 //* HttpVerb: POST
		 //* URL Pattern: http[s]://IPAddress:PortNumber/api/ExpensesTypes/get-with-filter
		 //* Usage: http://localhost/MersalAccountingService.WebAPI/api/ExpensesTypes/get-with-filter 
		 //*/
   //     public GenericCollectionViewModel<ListExpensesTypesLightViewModel> GetByFilter([FromBody]ExpensesTypeFilterViewModel model)
   //     {
   //         var result = this._ExpensesTypesService.GetByFilter(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExpensesTypes/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExpensesTypes/add-collection 
		 */
        public IList<ExpensesTypeViewModel> Add([FromBody]IEnumerable<ExpensesTypeViewModel> collection)
        {
            var result = this._ExpensesTypesService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExpensesTypes/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExpensesTypes/add 
		 */
        public ExpensesTypeViewModel Add([FromBody]ExpensesTypeViewModel model)
        {
            var result = this._ExpensesTypesService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExpensesTypes/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExpensesTypes/update-collection 
		 */
        public IList<ExpensesTypeViewModel> Update([FromBody]IEnumerable<ExpensesTypeViewModel> collection)
        {
            var result = this._ExpensesTypesService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExpensesTypes/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExpensesTypes/update 
		 */
        public ExpensesTypeViewModel Update([FromBody]ExpensesTypeViewModel model)
        {
            var result = this._ExpensesTypesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExpensesTypes/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExpensesTypes/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<ExpensesTypeViewModel> collection)
        {
            this._ExpensesTypesService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExpensesTypes/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExpensesTypes/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._ExpensesTypesService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExpensesTypes/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExpensesTypes/delete 
		 */
        public void Delete([FromBody]ExpensesTypeViewModel model)
        {
            this._ExpensesTypesService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExpensesTypes/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExpensesTypes/delete/1 
		 */
        public void Delete(long id)
        {
            this._ExpensesTypesService.Delete(id);
        }

        #endregion
    }
}
