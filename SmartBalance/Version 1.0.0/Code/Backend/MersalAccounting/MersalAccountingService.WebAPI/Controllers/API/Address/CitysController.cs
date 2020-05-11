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
	/// Citys Controller
	/// </summary>
	[RoutePrefix("api/Citys")]
	public class CitysController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ICitysService _CitysService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type CityController.
		/// </summary>
		/// <param name="CitysService">The injected service.</param>
		public CitysController(ICitysService CitysService)
		{
			this._CitysService = CitysService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of CityViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Citys/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Citys/get-by-condition 
		 */
		public GenericCollectionViewModel<CityViewModel> Get(ConditionFilter<City, long> condition)
		{
			var result = this._CitysService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CityViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Citys/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Citys/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<CityViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._CitysService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CityViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Citys/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Citys/get-light-by-condition 
		 */
		public GenericCollectionViewModel<CityLightViewModel> GetLightModel(ConditionFilter<City, long> condition)
		{
			var result = this._CitysService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CityViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Citys/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Citys/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<CityLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._CitysService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a CityViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Citys/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Citys/get/1 
		 */
		public CityViewModel Get(long id)
		{
			var result = this._CitysService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Citys/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Citys/add-collection 
		 */
		public IList<CityViewModel> Add([FromBody]IEnumerable<CityViewModel> collection)
		{
			var result = this._CitysService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Citys/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Citys/add 
		 */
		public CityViewModel Add([FromBody]CityViewModel model)
		{
			var result = this._CitysService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Citys/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Citys/update-collection 
		 */
		public IList<CityViewModel> Update([FromBody]IEnumerable<CityViewModel> collection)
		{
			var result = this._CitysService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Citys/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Citys/update 
		 */
		public CityViewModel Update([FromBody]CityViewModel model)
		{
			var result = this._CitysService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Citys/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Citys/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<CityViewModel> collection)
		{
			this._CitysService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Citys/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Citys/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._CitysService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Citys/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Citys/delete 
		 */
		public void Delete([FromBody]CityViewModel model)
		{
			this._CitysService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Citys/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Citys/delete/1 
		 */
		public void Delete(long id)
		{
			this._CitysService.Delete(id);
		}

		#endregion
	}
}
