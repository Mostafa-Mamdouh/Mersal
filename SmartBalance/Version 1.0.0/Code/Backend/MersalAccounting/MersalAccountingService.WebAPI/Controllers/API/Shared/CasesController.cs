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
	/// Cases Controller
	/// </summary>
	[RoutePrefix("api/Cases")]
	public class CasesController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ICasesService _CasesService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type CaseController.
		/// </summary>
		/// <param name="CasesService">The injected service.</param>
		public CasesController(ICasesService CasesService)
		{
			this._CasesService = CasesService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of CaseViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Cases/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Cases/get-by-condition 
		 */
		public GenericCollectionViewModel<CaseViewModel> Get(ConditionFilter<Case, long> condition)
		{
			var result = this._CasesService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CaseViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Cases/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Cases/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<CaseViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._CasesService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CaseViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Cases/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Cases/get-light-by-condition 
		 */
		public GenericCollectionViewModel<CaseLightViewModel> GetLightModel(ConditionFilter<Case, long> condition)
		{
			var result = this._CasesService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CaseViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Cases/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Cases/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<CaseLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._CasesService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a CaseViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Cases/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Cases/get/1 
		 */
		public CaseViewModel Get(long id)
		{
			var result = this._CasesService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Cases/get-lookup
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Cases/get-lookup
		 */
        public List<CaseLightViewModel> GetLookup()
        {
            var result = this._CasesService.GetLookUp();
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Cases/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Cases/add-collection 
		 */
		public IList<CaseViewModel> Add([FromBody]IEnumerable<CaseViewModel> collection)
		{
			var result = this._CasesService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Cases/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Cases/add 
		 */
		public CaseViewModel Add([FromBody]CaseViewModel model)
		{
			var result = this._CasesService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Cases/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Cases/update-collection 
		 */
		public IList<CaseViewModel> Update([FromBody]IEnumerable<CaseViewModel> collection)
		{
			var result = this._CasesService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Cases/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Cases/update 
		 */
		public CaseViewModel Update([FromBody]CaseViewModel model)
		{
			var result = this._CasesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Cases/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Cases/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<CaseViewModel> collection)
		{
			this._CasesService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Cases/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Cases/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._CasesService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Cases/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Cases/delete 
		 */
		public void Delete([FromBody]CaseViewModel model)
		{
			this._CasesService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Cases/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Cases/delete/1 
		 */
		public void Delete(long id)
		{
			this._CasesService.Delete(id);
		}

		#endregion
	}
}
