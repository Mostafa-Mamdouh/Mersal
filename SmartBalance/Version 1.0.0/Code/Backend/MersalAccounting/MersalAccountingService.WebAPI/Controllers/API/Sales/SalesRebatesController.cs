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
	/// SalesRebates Controller
	/// </summary>
	[RoutePrefix("api/SalesRebates")]
	public class SalesRebatesController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ISalesRebatesService _SalesRebatesService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type SalesRebateController.
		/// </summary>
		/// <param name="SalesRebatesService">The injected service.</param>
		public SalesRebatesController(ISalesRebatesService SalesRebatesService)
		{
			this._SalesRebatesService = SalesRebatesService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of SalesRebateViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebates/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebates/get-by-condition 
		 */
		public GenericCollectionViewModel<SalesRebateViewModel> Get(ConditionFilter<SalesRebate, long> condition)
		{
			var result = this._SalesRebatesService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of SalesRebateViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebates/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebates/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<SalesRebateViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._SalesRebatesService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of SalesRebateViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebates/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebates/get-light-by-condition 
		 */
		public GenericCollectionViewModel<SalesRebateLightViewModel> GetLightModel(ConditionFilter<SalesRebate, long> condition)
		{
			var result = this._SalesRebatesService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of SalesRebateViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebates/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebates/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<SalesRebateLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._SalesRebatesService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a SalesRebateViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebates/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebates/get/1 
		 */
		public SalesRebateViewModel Get(long id)
		{
			var result = this._SalesRebatesService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebates/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebates/add-collection 
		 */
		public IList<SalesRebateViewModel> Add([FromBody]IEnumerable<SalesRebateViewModel> collection)
		{
			var result = this._SalesRebatesService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebates/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebates/add 
		 */
		public SalesRebateViewModel Add([FromBody]SalesRebateViewModel model)
		{
			var result = this._SalesRebatesService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebates/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebates/update-collection 
		 */
		public IList<SalesRebateViewModel> Update([FromBody]IEnumerable<SalesRebateViewModel> collection)
		{
			var result = this._SalesRebatesService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebates/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebates/update 
		 */
		public SalesRebateViewModel Update([FromBody]SalesRebateViewModel model)
		{
			var result = this._SalesRebatesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebates/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebates/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<SalesRebateViewModel> collection)
		{
			this._SalesRebatesService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebates/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebates/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._SalesRebatesService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebates/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebates/delete 
		 */
		public void Delete([FromBody]SalesRebateViewModel model)
		{
			this._SalesRebatesService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebates/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebates/delete/1 
		 */
		public void Delete(long id)
		{
			this._SalesRebatesService.Delete(id);
		}

		#endregion
	}
}
