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
	/// CaseTypes Controller
	/// </summary>
	[RoutePrefix("api/CaseTypes")]
	public class CaseTypesController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ICaseTypesService _CaseTypesService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type CaseTypeController.
		/// </summary>
		/// <param name="CaseTypesService">The injected service.</param>
		public CaseTypesController(ICaseTypesService CaseTypesService)
		{
			this._CaseTypesService = CaseTypesService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of CaseTypeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CaseTypes/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CaseTypes/get-by-condition 
		 */
		public GenericCollectionViewModel<CaseTypeViewModel> Get(ConditionFilter<CaseType, long> condition)
		{
			var result = this._CaseTypesService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CaseTypeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CaseTypes/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CaseTypes/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<CaseTypeViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._CaseTypesService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CaseTypeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CaseTypes/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CaseTypes/get-light-by-condition 
		 */
		public GenericCollectionViewModel<CaseTypeLightViewModel> GetLightModel(ConditionFilter<CaseType, long> condition)
		{
			var result = this._CaseTypesService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CaseTypeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CaseTypes/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CaseTypes/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<CaseTypeLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._CaseTypesService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a CaseTypeViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CaseTypes/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CaseTypes/get/1 
		 */
		public CaseTypeViewModel Get(long id)
		{
			var result = this._CaseTypesService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CaseTypes/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CaseTypes/add-collection 
		 */
		public IList<CaseTypeViewModel> Add([FromBody]IEnumerable<CaseTypeViewModel> collection)
		{
			var result = this._CaseTypesService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CaseTypes/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CaseTypes/add 
		 */
		public CaseTypeViewModel Add([FromBody]CaseTypeViewModel model)
		{
			var result = this._CaseTypesService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CaseTypes/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CaseTypes/update-collection 
		 */
		public IList<CaseTypeViewModel> Update([FromBody]IEnumerable<CaseTypeViewModel> collection)
		{
			var result = this._CaseTypesService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CaseTypes/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CaseTypes/update 
		 */
		public CaseTypeViewModel Update([FromBody]CaseTypeViewModel model)
		{
			var result = this._CaseTypesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CaseTypes/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CaseTypes/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<CaseTypeViewModel> collection)
		{
			this._CaseTypesService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CaseTypes/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CaseTypes/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._CaseTypesService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CaseTypes/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CaseTypes/delete 
		 */
		public void Delete([FromBody]CaseTypeViewModel model)
		{
			this._CaseTypesService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CaseTypes/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CaseTypes/delete/1 
		 */
		public void Delete(long id)
		{
			this._CaseTypesService.Delete(id);
		}

		#endregion
	}
}
