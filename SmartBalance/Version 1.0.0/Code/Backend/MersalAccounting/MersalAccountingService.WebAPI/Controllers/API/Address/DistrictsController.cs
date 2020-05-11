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
	/// Districts Controller
	/// </summary>
	[RoutePrefix("api/Districts")]
	public class DistrictsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IDistrictsService _DistrictsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type DistrictController.
		/// </summary>
		/// <param name="DistrictsService">The injected service.</param>
		public DistrictsController(IDistrictsService DistrictsService)
		{
			this._DistrictsService = DistrictsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of DistrictViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Districts/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Districts/get-by-condition 
		 */
		public GenericCollectionViewModel<DistrictViewModel> Get(ConditionFilter<District, long> condition)
		{
			var result = this._DistrictsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of DistrictViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Districts/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Districts/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<DistrictViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._DistrictsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of DistrictViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Districts/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Districts/get-light-by-condition 
		 */
		public GenericCollectionViewModel<DistrictLightViewModel> GetLightModel(ConditionFilter<District, long> condition)
		{
			var result = this._DistrictsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of DistrictViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Districts/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Districts/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<DistrictLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._DistrictsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a DistrictViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Districts/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Districts/get/1 
		 */
		public DistrictViewModel Get(long id)
		{
			var result = this._DistrictsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Districts/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Districts/add-collection 
		 */
		public IList<DistrictViewModel> Add([FromBody]IEnumerable<DistrictViewModel> collection)
		{
			var result = this._DistrictsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Districts/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Districts/add 
		 */
		public DistrictViewModel Add([FromBody]DistrictViewModel model)
		{
			var result = this._DistrictsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Districts/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Districts/update-collection 
		 */
		public IList<DistrictViewModel> Update([FromBody]IEnumerable<DistrictViewModel> collection)
		{
			var result = this._DistrictsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Districts/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Districts/update 
		 */
		public DistrictViewModel Update([FromBody]DistrictViewModel model)
		{
			var result = this._DistrictsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Districts/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Districts/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<DistrictViewModel> collection)
		{
			this._DistrictsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Districts/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Districts/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._DistrictsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Districts/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Districts/delete 
		 */
		public void Delete([FromBody]DistrictViewModel model)
		{
			this._DistrictsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Districts/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Districts/delete/1 
		 */
		public void Delete(long id)
		{
			this._DistrictsService.Delete(id);
		}

		#endregion
	}
}
