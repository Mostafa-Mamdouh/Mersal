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
	/// AccountTypes Controller
	/// </summary>
	[RoutePrefix("api/AccountTypes")]
	public class AccountTypesController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IAccountTypesService _AccountTypesService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AccountTypeController.
		/// </summary>
		/// <param name="AccountTypesService">The injected service.</param>
		public AccountTypesController(IAccountTypesService AccountTypesService)
		{
			this._AccountTypesService = AccountTypesService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountTypeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountTypes/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountTypes/get-by-condition 
		 */
		public GenericCollectionViewModel<AccountTypeViewModel> Get(ConditionFilter<AccountType, long> condition)
		{
			var result = this._AccountTypesService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountTypeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountTypes/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountTypes/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<AccountTypeViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._AccountTypesService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountTypeViewModel by condition.
        /// loojup
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-Id/{id?}")]
		[HttpGet]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountTypes/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountTypes/get-light-by-condition 
		 */
		public GenericCollectionViewModel<AccountTypeLightViewModel> GetLightModel(int? id)
		{
			var result = this._AccountTypesService.GetLightModel(id);
			return result;
		}


        /// <summary>
		/// Gets a GenericCollectionViewModel of AccountTypeViewModel by condition.
        /// loojup
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("Get")]
        [HttpGet]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountTypes/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountTypes/get-light-by-condition 
		 */
        public List<AccountTypeLightViewModel> Get()
        {
            var result = this._AccountTypesService.Get();
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AccountTypeViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountTypes/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountTypes/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<AccountTypeLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._AccountTypesService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a AccountTypeViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountTypes/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountTypes/get/1 
		 */
		public AccountTypeViewModel Get(long id)
		{
			var result = this._AccountTypesService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountTypes/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountTypes/add-collection 
		 */
		public IList<AccountTypeViewModel> Add([FromBody]IEnumerable<AccountTypeViewModel> collection)
		{
			var result = this._AccountTypesService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountTypes/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountTypes/add 
		 */
		public AccountTypeViewModel Add([FromBody]AccountTypeViewModel model)
		{
			var result = this._AccountTypesService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountTypes/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountTypes/update-collection 
		 */
		public IList<AccountTypeViewModel> Update([FromBody]IEnumerable<AccountTypeViewModel> collection)
		{
			var result = this._AccountTypesService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountTypes/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountTypes/update 
		 */
		public AccountTypeViewModel Update([FromBody]AccountTypeViewModel model)
		{
			var result = this._AccountTypesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountTypes/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountTypes/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<AccountTypeViewModel> collection)
		{
			this._AccountTypesService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountTypes/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountTypes/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._AccountTypesService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountTypes/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountTypes/delete 
		 */
		public void Delete([FromBody]AccountTypeViewModel model)
		{
			this._AccountTypesService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountTypes/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountTypes/delete/1 
		 */
		public void Delete(long id)
		{
			this._AccountTypesService.Delete(id);
		}

		#endregion
	}
}
