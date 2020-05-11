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
	/// Currencys Controller
	/// </summary>
	[RoutePrefix("api/Currencys")]
	public class CurrencysController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ICurrencysService _CurrencysService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type CurrencyController.
		/// </summary>
		/// <param name="CurrencysService">The injected service.</param>
		public CurrencysController(ICurrencysService CurrencysService)
		{
			this._CurrencysService = CurrencysService;
		}
        #endregion

        #region Actions

        [Route("get-with-filter")]
        [HttpPost]
        public GenericCollectionViewModel<ListCurrencyLightViewModel> GetByFilter([FromBody]CurrencyFilterViewModel model)
        {
            var result = this._CurrencysService.GetByFilter(model);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of CurrencyViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Currencys/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Currencys/get-by-condition 
		 */
		public GenericCollectionViewModel<CurrencyViewModel> Get(ConditionFilter<Currency, long> condition)
		{
			var result = this._CurrencysService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CurrencyViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Currencys/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Currencys/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<CurrencyViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._CurrencysService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CurrencyViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Currencys/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Currencys/get-light-by-condition 
		 */
		public GenericCollectionViewModel<CurrencyLightViewModel> GetLightModel(ConditionFilter<Currency, long> condition)
		{
			var result = this._CurrencysService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CurrencyViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Currencys/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Currencys/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<CurrencyLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._CurrencysService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a CurrencyViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Currencys/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Currencys/get/1 
		 */
		public CurrencyViewModel Get(long id)
		{
			var result = this._CurrencysService.Get(id);
			return result;
		}

        /// <summary>
        /// Gets a GenericCollectionViewModel of ProductViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-lookup")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Products/get-lookup
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Products/get-lookup
		 */
        public List<CurrencyLightViewModel> GetLookup()
        {
            var result = this._CurrencysService.GetLookUp();
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Currencys/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Currencys/add-collection 
		 */
		public IList<CurrencyViewModel> Add([FromBody]IEnumerable<CurrencyViewModel> collection)
		{
			var result = this._CurrencysService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Currencys/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Currencys/add 
		 */
		public CurrencyViewModel Add([FromBody]CurrencyViewModel model)
		{
			var result = this._CurrencysService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Currencys/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Currencys/update-collection 
		 */
		public IList<CurrencyViewModel> Update([FromBody]IEnumerable<CurrencyViewModel> collection)
		{
			var result = this._CurrencysService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Currencys/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Currencys/update 
		 */
		public CurrencyViewModel Update([FromBody]CurrencyViewModel model)
		{
			var result = this._CurrencysService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Currencys/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Currencys/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<CurrencyViewModel> collection)
		{
			this._CurrencysService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Currencys/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Currencys/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._CurrencysService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Currencys/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Currencys/delete 
		 */
		public void Delete([FromBody]CurrencyViewModel model)
		{
			this._CurrencysService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Currencys/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Currencys/delete/1 
		 */
		public void Delete(long id)
		{
			this._CurrencysService.Delete(id);
		}

		#endregion
	}
}
