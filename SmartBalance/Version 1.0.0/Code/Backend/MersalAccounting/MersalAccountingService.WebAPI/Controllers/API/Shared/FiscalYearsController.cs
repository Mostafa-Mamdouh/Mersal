#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.Common;
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
	/// FiscalYears Controller
	/// </summary>
	[RoutePrefix("api/FiscalYears")]
	public class FiscalYearsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ICurrentUserService _currentUserService;
		private readonly IFiscalYearsService _FiscalYearsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type FiscalYearController.
		/// </summary>
		/// <param name="currentUserService">The injected currentUserService.</param>
		/// <param name="FiscalYearsService">The injected service.</param>
		public FiscalYearsController(
			ICurrentUserService currentUserService,
			IFiscalYearsService FiscalYearsService)
		{
			this._currentUserService = currentUserService;
			this._FiscalYearsService = FiscalYearsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of FiscalYearViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/FiscalYears/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/FiscalYears/get-by-condition 
		 */
		public GenericCollectionViewModel<FiscalYearViewModel> Get(ConditionFilter<FiscalYear, long> condition)
		{
			var result = this._FiscalYearsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of FiscalYearViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/FiscalYears/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/FiscalYears/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<FiscalYearViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._FiscalYearsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of FiscalYearViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/FiscalYears/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/FiscalYears/get-light-by-condition 
		 */
		public GenericCollectionViewModel<FiscalYearLightViewModel> GetLightModel(ConditionFilter<FiscalYear, long> condition)
		{
			var result = this._FiscalYearsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of FiscalYearViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/FiscalYears/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/FiscalYears/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<FiscalYearLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._FiscalYearsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a FiscalYearViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/FiscalYears/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/FiscalYears/get/1 
		 */
		public FiscalYearViewModel Get(long id)
		{
			var result = this._FiscalYearsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/FiscalYears/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/FiscalYears/add-collection 
		 */
		public IList<FiscalYearViewModel> Add([FromBody]IEnumerable<FiscalYearViewModel> collection)
		{
			var result = this._FiscalYearsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/FiscalYears/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/FiscalYears/add 
		 */
		public FiscalYearViewModel Add([FromBody]FiscalYearViewModel model)
		{
			var result = this._FiscalYearsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/FiscalYears/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/FiscalYears/update-collection 
		 */
		public IList<FiscalYearViewModel> Update([FromBody]IEnumerable<FiscalYearViewModel> collection)
		{
			var result = this._FiscalYearsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/FiscalYears/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/FiscalYears/update 
		 */
		public FiscalYearViewModel Update([FromBody]FiscalYearViewModel model)
		{
			var result = this._FiscalYearsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/FiscalYears/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/FiscalYears/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<FiscalYearViewModel> collection)
		{
			this._FiscalYearsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/FiscalYears/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/FiscalYears/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._FiscalYearsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/FiscalYears/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/FiscalYears/delete 
		 */
		public void Delete([FromBody]FiscalYearViewModel model)
		{
			this._FiscalYearsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/FiscalYears/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/FiscalYears/delete/1 
		 */
		public void Delete(long id)
		{
			this._FiscalYearsService.Delete(id);
		}

		#endregion
	}
}
