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
	/// ExchangeBondss Controller
	/// </summary>
	[RoutePrefix("api/ExchangeBondss")]
	public class ExchangeBondssController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IExchangeBondssService _ExchangeBondssService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type ExchangeBondsController.
		/// </summary>
		/// <param name="ExchangeBondssService">The injected service.</param>
		public ExchangeBondssController(IExchangeBondssService ExchangeBondssService)
		{
			this._ExchangeBondssService = ExchangeBondssService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of ExchangeBondsViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExchangeBondss/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExchangeBondss/get-by-condition 
		 */
		public GenericCollectionViewModel<ExchangeBondsViewModel> Get(ConditionFilter<ExchangeBonds, long> condition)
		{
			var result = this._ExchangeBondssService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ExchangeBondsViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExchangeBondss/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExchangeBondss/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<ExchangeBondsViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._ExchangeBondssService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ExchangeBondsViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExchangeBondss/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExchangeBondss/get-light-by-condition 
		 */
		public GenericCollectionViewModel<ExchangeBondsLightViewModel> GetLightModel(ConditionFilter<ExchangeBonds, long> condition)
		{
			var result = this._ExchangeBondssService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ExchangeBondsViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExchangeBondss/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExchangeBondss/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<ExchangeBondsLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._ExchangeBondssService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a ExchangeBondsViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExchangeBondss/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExchangeBondss/get/1 
		 */
		public ExchangeBondsViewModel Get(long id)
		{
			var result = this._ExchangeBondssService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExchangeBondss/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExchangeBondss/add-collection 
		 */
		public IList<ExchangeBondsViewModel> Add([FromBody]IEnumerable<ExchangeBondsViewModel> collection)
		{
			var result = this._ExchangeBondssService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExchangeBondss/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExchangeBondss/add 
		 */
		public ExchangeBondsViewModel Add([FromBody]ExchangeBondsViewModel model)
		{
			var result = this._ExchangeBondssService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExchangeBondss/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExchangeBondss/update-collection 
		 */
		public IList<ExchangeBondsViewModel> Update([FromBody]IEnumerable<ExchangeBondsViewModel> collection)
		{
			var result = this._ExchangeBondssService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExchangeBondss/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExchangeBondss/update 
		 */
		public ExchangeBondsViewModel Update([FromBody]ExchangeBondsViewModel model)
		{
			var result = this._ExchangeBondssService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExchangeBondss/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExchangeBondss/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<ExchangeBondsViewModel> collection)
		{
			this._ExchangeBondssService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExchangeBondss/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExchangeBondss/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._ExchangeBondssService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExchangeBondss/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExchangeBondss/delete 
		 */
		public void Delete([FromBody]ExchangeBondsViewModel model)
		{
			this._ExchangeBondssService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExchangeBondss/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExchangeBondss/delete/1 
		 */
		public void Delete(long id)
		{
			this._ExchangeBondssService.Delete(id);
		}

		#endregion
	}
}
