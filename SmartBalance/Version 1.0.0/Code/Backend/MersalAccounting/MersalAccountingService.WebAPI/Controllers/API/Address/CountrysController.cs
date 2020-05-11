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
	/// Countrys Controller
	/// </summary>
	[RoutePrefix("api/Countrys")]
	public class CountrysController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ICountrysService _CountrysService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type CountryController.
		/// </summary>
		/// <param name="CountrysService">The injected service.</param>
		public CountrysController(ICountrysService CountrysService)
		{
			this._CountrysService = CountrysService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of CountryViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Countrys/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Countrys/get-by-condition 
		 */
		public GenericCollectionViewModel<CountryViewModel> Get(ConditionFilter<Country, long> condition)
		{
			var result = this._CountrysService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CountryViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Countrys/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Countrys/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<CountryViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._CountrysService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CountryViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Countrys/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Countrys/get-light-by-condition 
		 */
		public GenericCollectionViewModel<CountryLightViewModel> GetLightModel(ConditionFilter<Country, long> condition)
		{
			var result = this._CountrysService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CountryViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Countrys/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Countrys/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<CountryLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._CountrysService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a CountryViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Countrys/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Countrys/get/1 
		 */
		public CountryViewModel Get(long id)
		{
			var result = this._CountrysService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Countrys/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Countrys/add-collection 
		 */
		public IList<CountryViewModel> Add([FromBody]IEnumerable<CountryViewModel> collection)
		{
			var result = this._CountrysService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Countrys/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Countrys/add 
		 */
		public CountryViewModel Add([FromBody]CountryViewModel model)
		{
			var result = this._CountrysService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Countrys/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Countrys/update-collection 
		 */
		public IList<CountryViewModel> Update([FromBody]IEnumerable<CountryViewModel> collection)
		{
			var result = this._CountrysService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Countrys/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Countrys/update 
		 */
		public CountryViewModel Update([FromBody]CountryViewModel model)
		{
			var result = this._CountrysService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Countrys/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Countrys/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<CountryViewModel> collection)
		{
			this._CountrysService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Countrys/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Countrys/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._CountrysService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Countrys/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Countrys/delete 
		 */
		public void Delete([FromBody]CountryViewModel model)
		{
			this._CountrysService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Countrys/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Countrys/delete/1 
		 */
		public void Delete(long id)
		{
			this._CountrysService.Delete(id);
		}

		#endregion
	}
}
