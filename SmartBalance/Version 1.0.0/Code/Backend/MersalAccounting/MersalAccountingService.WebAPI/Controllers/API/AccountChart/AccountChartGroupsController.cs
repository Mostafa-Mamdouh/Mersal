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
	/// AccountChartGroups Controller
	/// </summary>
	[RoutePrefix("api/AccountChartGroups")]
	public class AccountChartGroupsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IAccountChartGroupsService _AccountChartGroupsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AccountChartGroupController.
		/// </summary>
		/// <param name="AccountChartGroupsService">The injected service.</param>
		public AccountChartGroupsController(IAccountChartGroupsService AccountChartGroupsService)
		{
			this._AccountChartGroupsService = AccountChartGroupsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartGroupViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartGroups/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartGroups/get-by-condition 
		 */
		public GenericCollectionViewModel<AccountChartGroupViewModel> Get(ConditionFilter<AccountChartGroup, long> condition)
		{
			var result = this._AccountChartGroupsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartGroupViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartGroups/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartGroups/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<AccountChartGroupViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._AccountChartGroupsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartGroupViewModel by condition.
        /// loojup
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-Id/{id?}")]
		[HttpGet]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartGroups/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartGroups/get-light-by-condition 
		 */
		public GenericCollectionViewModel<AccountChartGroupLightViewModel> GetLightModel(int? id)
		{
			var result = this._AccountChartGroupsService.GetLightModel(id);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartGroupViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartGroups/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartGroups/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<AccountChartGroupLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._AccountChartGroupsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a AccountChartGroupViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartGroups/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartGroups/get/1 
		 */
		public AccountChartGroupViewModel Get(long id)
		{
			var result = this._AccountChartGroupsService.Get(id);
			return result;
		}

        [Route("get")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartGroups/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartGroups/get/1 
		 */
        public List<AccountChartGroupLightViewModel> Get()
        {
            var result = this._AccountChartGroupsService.Get();
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartGroups/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartGroups/add-collection 
		 */
		public IList<AccountChartGroupViewModel> Add([FromBody]IEnumerable<AccountChartGroupViewModel> collection)
		{
			var result = this._AccountChartGroupsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartGroups/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartGroups/add 
		 */
		public AccountChartGroupViewModel Add([FromBody]AccountChartGroupViewModel model)
		{
			var result = this._AccountChartGroupsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartGroups/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartGroups/update-collection 
		 */
		public IList<AccountChartGroupViewModel> Update([FromBody]IEnumerable<AccountChartGroupViewModel> collection)
		{
			var result = this._AccountChartGroupsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartGroups/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartGroups/update 
		 */
		public AccountChartGroupViewModel Update([FromBody]AccountChartGroupViewModel model)
		{
			var result = this._AccountChartGroupsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartGroups/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartGroups/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<AccountChartGroupViewModel> collection)
		{
			this._AccountChartGroupsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartGroups/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartGroups/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._AccountChartGroupsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartGroups/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartGroups/delete 
		 */
		public void Delete([FromBody]AccountChartGroupViewModel model)
		{
			this._AccountChartGroupsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartGroups/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartGroups/delete/1 
		 */
		public void Delete(long id)
		{
			this._AccountChartGroupsService.Delete(id);
		}

		#endregion
	}
}
