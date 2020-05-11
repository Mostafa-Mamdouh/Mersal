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
	/// SalesRebateProducts Controller
	/// </summary>
	[RoutePrefix("api/SalesRebateProducts")]
	public class SalesRebateProductsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ISalesRebateProductsService _SalesRebateProductsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type SalesRebateProductController.
		/// </summary>
		/// <param name="SalesRebateProductsService">The injected service.</param>
		public SalesRebateProductsController(ISalesRebateProductsService SalesRebateProductsService)
		{
			this._SalesRebateProductsService = SalesRebateProductsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of SalesRebateProductViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebateProducts/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebateProducts/get-by-condition 
		 */
		public GenericCollectionViewModel<SalesRebateProductViewModel> Get(ConditionFilter<SalesRebateProduct, long> condition)
		{
			var result = this._SalesRebateProductsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of SalesRebateProductViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebateProducts/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebateProducts/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<SalesRebateProductViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._SalesRebateProductsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of SalesRebateProductViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebateProducts/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebateProducts/get-light-by-condition 
		 */
		public GenericCollectionViewModel<SalesRebateProductLightViewModel> GetLightModel(ConditionFilter<SalesRebateProduct, long> condition)
		{
			var result = this._SalesRebateProductsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of SalesRebateProductViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebateProducts/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebateProducts/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<SalesRebateProductLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._SalesRebateProductsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a SalesRebateProductViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebateProducts/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebateProducts/get/1 
		 */
		public SalesRebateProductViewModel Get(long id)
		{
			var result = this._SalesRebateProductsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebateProducts/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebateProducts/add-collection 
		 */
		public IList<SalesRebateProductViewModel> Add([FromBody]IEnumerable<SalesRebateProductViewModel> collection)
		{
			var result = this._SalesRebateProductsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebateProducts/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebateProducts/add 
		 */
		public SalesRebateProductViewModel Add([FromBody]SalesRebateProductViewModel model)
		{
			var result = this._SalesRebateProductsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebateProducts/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebateProducts/update-collection 
		 */
		public IList<SalesRebateProductViewModel> Update([FromBody]IEnumerable<SalesRebateProductViewModel> collection)
		{
			var result = this._SalesRebateProductsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebateProducts/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebateProducts/update 
		 */
		public SalesRebateProductViewModel Update([FromBody]SalesRebateProductViewModel model)
		{
			var result = this._SalesRebateProductsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebateProducts/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebateProducts/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<SalesRebateProductViewModel> collection)
		{
			this._SalesRebateProductsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebateProducts/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebateProducts/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._SalesRebateProductsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebateProducts/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebateProducts/delete 
		 */
		public void Delete([FromBody]SalesRebateProductViewModel model)
		{
			this._SalesRebateProductsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesRebateProducts/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesRebateProducts/delete/1 
		 */
		public void Delete(long id)
		{
			this._SalesRebateProductsService.Delete(id);
		}

		#endregion
	}
}
