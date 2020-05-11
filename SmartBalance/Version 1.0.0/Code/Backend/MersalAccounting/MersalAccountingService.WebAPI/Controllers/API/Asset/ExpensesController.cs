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
    /// Expenses Controller
    /// </summary>
    [RoutePrefix("api/Expenses")]
    public class ExpensesController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IExpensesService _ExpensesService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ExpenseController.
        /// </summary>
        /// <param name="ExpensesService">The injected service.</param>
        public ExpensesController(IExpensesService ExpensesService)
        {
            this._ExpensesService = ExpensesService;
        }
        #endregion

        #region Actions

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExpenseViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Expenses/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Expenses/get-by-condition 
		 */
        public GenericCollectionViewModel<ExpenseViewModel> Get(ConditionFilter<Expense, long> condition)
        {
            var result = this._ExpensesService.Get(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExpenseViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Expenses/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Expenses/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<ExpenseViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._ExpensesService.Get(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExpenseViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Expenses/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Expenses/get-light-by-condition 
		 */
        public GenericCollectionViewModel<ExpenseLightViewModel> GetLightModel(ConditionFilter<Expense, long> condition)
        {
            var result = this._ExpensesService.GetLightModel(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExpenseViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Expenses/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Expenses/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<ExpenseLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var result = this._ExpensesService.GetLightModel(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a ExpenseViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
		[JwtAuthentication(Permissions.ExpensesFixedAssetList)]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Expenses/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Expenses/get/1 
		 */
		public ExpenseViewModel Get(long id)
        {
            var result = this._ExpensesService.Get(id);
            return result;
        }

		[Route("get-with-filter")]
		[HttpPost]
		[JwtAuthentication(Permissions.ExpensesFixedAssetList)]
		public GenericCollectionViewModel<ListExpenseLightViewModel> GetByFilter(ExpenseFilterViewModel model)
		{
			var result = this._ExpensesService.GetByFilter(model);
			return result;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		[Route("add-collection")]
        [HttpPost]
		[JwtAuthentication(Permissions.AddExpensesFixedAsset)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Expenses/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Expenses/add-collection 
		 */
		public IList<ExpenseViewModel> Add([FromBody]IEnumerable<ExpenseViewModel> collection)
        {
            var result = this._ExpensesService.Add(collection);
            return result;
        }

        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("add")]
        [HttpPost]
		[JwtAuthentication(Permissions.AddExpensesFixedAsset)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Expenses/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Expenses/add 
		 */
		public ExpenseViewModel Add([FromBody]ExpenseViewModel model)
        {
            var result = this._ExpensesService.Add(model);
            return result;
        }


        /// <summary>
        /// Update entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("update-collection")]
        [HttpPost]
		[JwtAuthentication(Permissions.EditExpensesFixedAsset)]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Expenses/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Expenses/update-collection 
		 */
		public IList<ExpenseViewModel> Update([FromBody]IEnumerable<ExpenseViewModel> collection)
        {
            var result = this._ExpensesService.Update(collection);
            return result;
        }

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("update")]
        [HttpPost]
		[JwtAuthentication(Permissions.EditExpensesFixedAsset)]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Expenses/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Expenses/update 
		 */
		public ExpenseViewModel Update([FromBody]ExpenseViewModel model)
        {
            var result = this._ExpensesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Expenses/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Expenses/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<ExpenseViewModel> collection)
        {
            this._ExpensesService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Expenses/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Expenses/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._ExpensesService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Expenses/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Expenses/delete 
		 */
        public void Delete([FromBody]ExpenseViewModel model)
        {
            this._ExpensesService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Expenses/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Expenses/delete/1 
		 */
        public void Delete(long id)
        {
            this._ExpensesService.Delete(id);
        }

        #endregion
    }
}
