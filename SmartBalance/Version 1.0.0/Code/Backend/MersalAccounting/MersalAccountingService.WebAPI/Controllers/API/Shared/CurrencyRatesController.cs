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
	/// CurrencyRates Controller
	/// </summary>
	[RoutePrefix("api/CurrencyRates")]
	public class CurrencyRatesController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ICurrencyRatesService _CurrencyRatesService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type CurrencyRateController.
		/// </summary>
		/// <param name="CurrencyRatesService">The injected service.</param>
		public CurrencyRatesController(ICurrencyRatesService CurrencyRatesService)
		{
			this._CurrencyRatesService = CurrencyRatesService;
		}
        #endregion

        #region Actions

        [Route("get-with-filter")]
        [HttpPost]
        public GenericCollectionViewModel<ListCurrencyRateLightViewModel> GetByFilter([FromBody]CurrencyRateFilterViewModel model)
        {
            var result = this._CurrencyRatesService.GetByFilter(model);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of CurrencyRateViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CurrencyRates/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CurrencyRates/get-by-condition 
		 */
		public GenericCollectionViewModel<CurrencyRateViewModel> Get(ConditionFilter<CurrencyRate, long> condition)
		{
			var result = this._CurrencyRatesService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CurrencyRateViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CurrencyRates/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CurrencyRates/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<CurrencyRateViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._CurrencyRatesService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CurrencyRateViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CurrencyRates/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CurrencyRates/get-light-by-condition 
		 */
		public GenericCollectionViewModel<CurrencyRateLightViewModel> GetLightModel(ConditionFilter<CurrencyRate, long> condition)
		{
			var result = this._CurrencyRatesService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CurrencyRateViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CurrencyRates/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CurrencyRates/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<CurrencyRateLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._CurrencyRatesService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a CurrencyRateViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CurrencyRates/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CurrencyRates/get/1 
		 */
		public CurrencyRateViewModel Get(long id)
		{
			var result = this._CurrencyRatesService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CurrencyRates/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CurrencyRates/add-collection 
		 */
		public IList<CurrencyRateViewModel> Add([FromBody]IEnumerable<CurrencyRateViewModel> collection)
		{
			var result = this._CurrencyRatesService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CurrencyRates/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CurrencyRates/add 
		 */
		public CurrencyRateViewModel Add([FromBody]CurrencyRateViewModel model)
		{
			var result = this._CurrencyRatesService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CurrencyRates/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CurrencyRates/update-collection 
		 */
		public IList<CurrencyRateViewModel> Update([FromBody]IEnumerable<CurrencyRateViewModel> collection)
		{
			var result = this._CurrencyRatesService.Update(collection);
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
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CurrencyRates/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CurrencyRates/update 
		 */
		public CurrencyRateViewModel Update([FromBody]CurrencyRateViewModel model)
		{
			var result = this._CurrencyRatesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CurrencyRates/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CurrencyRates/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<CurrencyRateViewModel> collection)
		{
			this._CurrencyRatesService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CurrencyRates/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CurrencyRates/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._CurrencyRatesService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CurrencyRates/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CurrencyRates/delete 
		 */
		public void Delete([FromBody]CurrencyRateViewModel model)
		{
			this._CurrencyRatesService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CurrencyRates/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CurrencyRates/delete/1 
		 */
		public void Delete(long id)
		{
			this._CurrencyRatesService.Delete(id);
		}

		#endregion
	}
}
