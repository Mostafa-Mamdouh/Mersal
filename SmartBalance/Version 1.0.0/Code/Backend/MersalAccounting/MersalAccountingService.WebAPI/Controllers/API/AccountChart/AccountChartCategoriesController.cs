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
	/// AccountChartCategories Controller
	/// </summary>
	[RoutePrefix("api/AccountChartCategories")]
	public class AccountChartCategoriesController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IAccountChartCategoriesService _AccountChartCategorysService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AccountChartCategoryController.
		/// </summary>
		/// <param name="AccountChartCategorysService">The injected service.</param>
		public AccountChartCategoriesController(IAccountChartCategoriesService AccountChartCategorysService)
		{
			this._AccountChartCategorysService = AccountChartCategorysService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartCategoryViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartCategorys/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartCategorys/get-by-condition 
		 */
		public GenericCollectionViewModel<AccountChartCategoryViewModel> Get(ConditionFilter<AccountChartCategory, long> condition)
		{
			var result = this._AccountChartCategorysService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartCategoryViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartCategorys/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartCategorys/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<AccountChartCategoryViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._AccountChartCategorysService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartCategoryViewModel by condition.
        /// loojup
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-Id/{id?}")]
		[HttpGet]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartCategorys/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartCategorys/get-light-by-condition 
		 */
		public GenericCollectionViewModel<AccountChartCategoryLightViewModel> GetLightModel(int? id)
		{
			var result = this._AccountChartCategorysService.GetLightModel(id);
			return result;
		}

        /// <summary>
		/// Gets AccountChartCategoryLightViewModel by condition.
        /// lookup
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("Get")]
        [HttpGet]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartCategorys/Get
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartCategorys/Get 
		 */
        public List<AccountChartCategoryLightViewModel> Get()
        {
            var result = this._AccountChartCategorysService.Get();
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AccountChartCategoryViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartCategorys/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartCategorys/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<AccountChartCategoryLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._AccountChartCategorysService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a AccountChartCategoryViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartCategorys/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartCategorys/get/1 
		 */
		public AccountChartCategoryViewModel Get(long id)
		{
			var result = this._AccountChartCategorysService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartCategorys/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartCategorys/add-collection 
		 */
		public IList<AccountChartCategoryViewModel> Add([FromBody]IEnumerable<AccountChartCategoryViewModel> collection)
		{
			var result = this._AccountChartCategorysService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartCategorys/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartCategorys/add 
		 */
		public AccountChartCategoryViewModel Add([FromBody]AccountChartCategoryViewModel model)
		{
			var result = this._AccountChartCategorysService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartCategorys/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartCategorys/update-collection 
		 */
		public IList<AccountChartCategoryViewModel> Update([FromBody]IEnumerable<AccountChartCategoryViewModel> collection)
		{
			var result = this._AccountChartCategorysService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartCategorys/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartCategorys/update 
		 */
		public AccountChartCategoryViewModel Update([FromBody]AccountChartCategoryViewModel model)
		{
			var result = this._AccountChartCategorysService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartCategorys/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartCategorys/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<AccountChartCategoryViewModel> collection)
		{
			this._AccountChartCategorysService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartCategorys/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartCategorys/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._AccountChartCategorysService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartCategorys/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartCategorys/delete 
		 */
		public void Delete([FromBody]AccountChartCategoryViewModel model)
		{
			this._AccountChartCategorysService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartCategorys/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartCategorys/delete/1 
		 */
		public void Delete(long id)
		{
			this._AccountChartCategorysService.Delete(id);
		}

		#endregion
	}
}
