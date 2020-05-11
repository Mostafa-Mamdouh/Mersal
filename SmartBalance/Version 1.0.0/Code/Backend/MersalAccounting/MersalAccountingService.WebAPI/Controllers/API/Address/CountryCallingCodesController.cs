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
	/// CountryCallingCodes Controller
	/// </summary>
	[RoutePrefix("api/CountryCallingCodes")]
	public class CountryCallingCodesController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ICountryCallingCodesService _CountryCallingCodesService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type CountryCallingCodeController.
		/// </summary>
		/// <param name="CountryCallingCodesService">The injected service.</param>
		public CountryCallingCodesController(ICountryCallingCodesService CountryCallingCodesService)
		{
			this._CountryCallingCodesService = CountryCallingCodesService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of CountryCallingCodeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CountryCallingCodes/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CountryCallingCodes/get-by-condition 
		 */
		public GenericCollectionViewModel<CountryCallingCodeViewModel> Get(ConditionFilter<CountryCallingCode, long> condition)
		{
			var result = this._CountryCallingCodesService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CountryCallingCodeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CountryCallingCodes/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CountryCallingCodes/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<CountryCallingCodeViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._CountryCallingCodesService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CountryCallingCodeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CountryCallingCodes/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CountryCallingCodes/get-light-by-condition 
		 */
		public GenericCollectionViewModel<CountryCallingCodeLightViewModel> GetLightModel(ConditionFilter<CountryCallingCode, long> condition)
		{
			var result = this._CountryCallingCodesService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CountryCallingCodeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CountryCallingCodes/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CountryCallingCodes/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<CountryCallingCodeLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._CountryCallingCodesService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a CountryCallingCodeViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CountryCallingCodes/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CountryCallingCodes/get/1 
		 */
		public CountryCallingCodeViewModel Get(long id)
		{
			var result = this._CountryCallingCodesService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CountryCallingCodes/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CountryCallingCodes/add-collection 
		 */
		public IList<CountryCallingCodeViewModel> Add([FromBody]IEnumerable<CountryCallingCodeViewModel> collection)
		{
			var result = this._CountryCallingCodesService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CountryCallingCodes/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CountryCallingCodes/add 
		 */
		public CountryCallingCodeViewModel Add([FromBody]CountryCallingCodeViewModel model)
		{
			var result = this._CountryCallingCodesService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CountryCallingCodes/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CountryCallingCodes/update-collection 
		 */
		public IList<CountryCallingCodeViewModel> Update([FromBody]IEnumerable<CountryCallingCodeViewModel> collection)
		{
			var result = this._CountryCallingCodesService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CountryCallingCodes/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CountryCallingCodes/update 
		 */
		public CountryCallingCodeViewModel Update([FromBody]CountryCallingCodeViewModel model)
		{
			var result = this._CountryCallingCodesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CountryCallingCodes/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CountryCallingCodes/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<CountryCallingCodeViewModel> collection)
		{
			this._CountryCallingCodesService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CountryCallingCodes/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CountryCallingCodes/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._CountryCallingCodesService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CountryCallingCodes/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CountryCallingCodes/delete 
		 */
		public void Delete([FromBody]CountryCallingCodeViewModel model)
		{
			this._CountryCallingCodesService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CountryCallingCodes/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CountryCallingCodes/delete/1 
		 */
		public void Delete(long id)
		{
			this._CountryCallingCodesService.Delete(id);
		}

		#endregion
	}
}
