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
	/// StockAssessmentPolicys Controller
	/// </summary>
	[RoutePrefix("api/StockAssessmentPolicys")]
	public class StockAssessmentPolicysController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IStockAssessmentPolicysService _StockAssessmentPolicysService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type StockAssessmentPolicyController.
		/// </summary>
		/// <param name="StockAssessmentPolicysService">The injected service.</param>
		public StockAssessmentPolicysController(IStockAssessmentPolicysService StockAssessmentPolicysService)
		{
			this._StockAssessmentPolicysService = StockAssessmentPolicysService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of StockAssessmentPolicyViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StockAssessmentPolicys/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StockAssessmentPolicys/get-by-condition 
		 */
		public GenericCollectionViewModel<StockAssessmentPolicyViewModel> Get(ConditionFilter<StockAssessmentPolicy, long> condition)
		{
			var result = this._StockAssessmentPolicysService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of StockAssessmentPolicyViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StockAssessmentPolicys/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StockAssessmentPolicys/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<StockAssessmentPolicyViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._StockAssessmentPolicysService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of StockAssessmentPolicyViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StockAssessmentPolicys/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StockAssessmentPolicys/get-light-by-condition 
		 */
		public GenericCollectionViewModel<StockAssessmentPolicyLightViewModel> GetLightModel(ConditionFilter<StockAssessmentPolicy, long> condition)
		{
			var result = this._StockAssessmentPolicysService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of StockAssessmentPolicyViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StockAssessmentPolicys/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StockAssessmentPolicys/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<StockAssessmentPolicyLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._StockAssessmentPolicysService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a StockAssessmentPolicyViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StockAssessmentPolicys/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StockAssessmentPolicys/get/1 
		 */
		public StockAssessmentPolicyViewModel Get(long id)
		{
			var result = this._StockAssessmentPolicysService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StockAssessmentPolicys/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StockAssessmentPolicys/add-collection 
		 */
		public IList<StockAssessmentPolicyViewModel> Add([FromBody]IEnumerable<StockAssessmentPolicyViewModel> collection)
		{
			var result = this._StockAssessmentPolicysService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StockAssessmentPolicys/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StockAssessmentPolicys/add 
		 */
		public StockAssessmentPolicyViewModel Add([FromBody]StockAssessmentPolicyViewModel model)
		{
			var result = this._StockAssessmentPolicysService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StockAssessmentPolicys/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StockAssessmentPolicys/update-collection 
		 */
		public IList<StockAssessmentPolicyViewModel> Update([FromBody]IEnumerable<StockAssessmentPolicyViewModel> collection)
		{
			var result = this._StockAssessmentPolicysService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StockAssessmentPolicys/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StockAssessmentPolicys/update 
		 */
		public StockAssessmentPolicyViewModel Update([FromBody]StockAssessmentPolicyViewModel model)
		{
			var result = this._StockAssessmentPolicysService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StockAssessmentPolicys/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StockAssessmentPolicys/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<StockAssessmentPolicyViewModel> collection)
		{
			this._StockAssessmentPolicysService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StockAssessmentPolicys/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StockAssessmentPolicys/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._StockAssessmentPolicysService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StockAssessmentPolicys/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StockAssessmentPolicys/delete 
		 */
		public void Delete([FromBody]StockAssessmentPolicyViewModel model)
		{
			this._StockAssessmentPolicysService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StockAssessmentPolicys/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StockAssessmentPolicys/delete/1 
		 */
		public void Delete(long id)
		{
			this._StockAssessmentPolicysService.Delete(id);
		}

		#endregion
	}
}
