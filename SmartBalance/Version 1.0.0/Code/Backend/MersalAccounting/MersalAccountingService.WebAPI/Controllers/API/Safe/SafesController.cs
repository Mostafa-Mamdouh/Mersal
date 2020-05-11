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
	/// Safes Controller
	/// </summary>
	[RoutePrefix("api/Safes")]
	public class SafesController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ISafesService _SafesService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type SafeController.
		/// </summary>
		/// <param name="SafesService">The injected service.</param>
		public SafesController(ISafesService SafesService)
		{
			this._SafesService = SafesService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of SafeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Safes/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Safes/get-by-condition 
		 */
		public GenericCollectionViewModel<SafeViewModel> Get(ConditionFilter<Safe, long> condition)
		{
			var result = this._SafesService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of SafeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Safes/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Safes/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<SafeViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._SafesService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of SafeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Safes/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Safes/get-light-by-condition 
		 */
		public GenericCollectionViewModel<SafeLightViewModel> GetLightModel(ConditionFilter<Safe, long> condition)
		{
			var result = this._SafesService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of SafeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Safes/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Safes/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<SafeLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._SafesService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a SafeViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Safes/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Safes/get/1 
		 */
		public SafeViewModel Get(long id)
		{
			var result = this._SafesService.Get(id);
			return result;
		}


        /// <summary>
		/// Gets a SafeViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get-by-branch-id/{id}")]
        [HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Safes/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Safes/get-by-branch-id/1 
		 */
		public SafeViewModel getByBranchId(long id)
        {
            var result = this._SafesService.GetByBranchId(id);
            return result;
        }
        /// <summary>
        /// Gets a CaseViewModel by its id.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Route("get-lookup")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Safes/get-lookup
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Safes/get-lookup
		 */
        public List<SafeLightViewModel> GetLookup()
        {
            var result = this._SafesService.GetLookUp();
            return result;
        }

        [Route("get-accountcharts/{safeId}/{currencyId}")]
        [HttpGet]
        public List<AccountChartLightViewModel> GetAccountCharts(long safeId, long currencyId)
        {
            var result = this._SafesService.GetAccountCharts(safeId, currencyId);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ListSafesLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-with-filter")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Safes/get-with-filter
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Safes/get-with-filter 
		 */
		public GenericCollectionViewModel<ListSafesLightViewModel> GetByFilter([FromBody]SafeFilterViewModel model)
		{
			var result = this._SafesService.GetByFilter(model);
			return result;
		}

        [Route("get-safe-Accountcharts/{safeId}")]
        [HttpGet]
        [JwtAuthentication(Permissions.SafeAccountChartsList)]
        public SafeAccountChartListViewModel GetSafeAccountChart(long safeId)
        {
            var result = this._SafesService.GetSafeAccountChart(safeId);
            return result;
        }

        [Route("update-safe-Accountcharts")]
        [HttpPost]
        [JwtAuthentication(Permissions.EditSafeAccountCharts)]
        public SafeAccountChartListViewModel UpdateSafeAccountChart([FromBody]SafeAccountChartListViewModel model)
        {
            var result = this._SafesService.UpdateSafeAccountChart(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Safes/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Safes/add-collection 
		 */
		public IList<SafeViewModel> Add([FromBody]IEnumerable<SafeViewModel> collection)
		{
			var result = this._SafesService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Safes/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Safes/add 
		 */
		public SafeViewModel Add([FromBody]SafeViewModel model)
		{
			var result = this._SafesService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Safes/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Safes/update-collection 
		 */
		public IList<SafeViewModel> Update([FromBody]IEnumerable<SafeViewModel> collection)
		{
			var result = this._SafesService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Safes/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Safes/update 
		 */
		public SafeViewModel Update([FromBody]SafeViewModel model)
		{
			var result = this._SafesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Safes/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Safes/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<SafeViewModel> collection)
		{
			this._SafesService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Safes/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Safes/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._SafesService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Safes/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Safes/delete 
		 */
		public void Delete([FromBody]SafeViewModel model)
		{
			this._SafesService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Safes/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Safes/delete/1 
		 */
		public void Delete(long id)
		{
			this._SafesService.Delete(id);
		}

		#endregion
	}
}
