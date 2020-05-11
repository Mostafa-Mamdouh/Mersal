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
	/// ProductTypes Controller
	/// </summary>
	[RoutePrefix("api/ProductTypes")]
	public class ProductTypesController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IProductTypesService _ProductTypesService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type ProductTypeController.
		/// </summary>
		/// <param name="ProductTypesService">The injected service.</param>
		public ProductTypesController(IProductTypesService ProductTypesService)
		{
			this._ProductTypesService = ProductTypesService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of ProductTypeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductTypes/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductTypes/get-by-condition 
		 */
		public GenericCollectionViewModel<ProductTypeViewModel> Get(ConditionFilter<ProductType, long> condition)
		{
			var result = this._ProductTypesService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ProductTypeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductTypes/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductTypes/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<ProductTypeViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._ProductTypesService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ProductTypeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductTypes/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductTypes/get-light-by-condition 
		 */
		public GenericCollectionViewModel<ProductTypeLightViewModel> GetLightModel(ConditionFilter<ProductType, long> condition)
		{
			var result = this._ProductTypesService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ProductTypeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductTypes/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductTypes/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<ProductTypeLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._ProductTypesService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a ProductTypeViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductTypes/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductTypes/get/1 
		 */
		public ProductTypeViewModel Get(long id)
		{
			var result = this._ProductTypesService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductTypes/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductTypes/add-collection 
		 */
		public IList<ProductTypeViewModel> Add([FromBody]IEnumerable<ProductTypeViewModel> collection)
		{
			var result = this._ProductTypesService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductTypes/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductTypes/add 
		 */
		public ProductTypeViewModel Add([FromBody]ProductTypeViewModel model)
		{
			var result = this._ProductTypesService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductTypes/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductTypes/update-collection 
		 */
		public IList<ProductTypeViewModel> Update([FromBody]IEnumerable<ProductTypeViewModel> collection)
		{
			var result = this._ProductTypesService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductTypes/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductTypes/update 
		 */
		public ProductTypeViewModel Update([FromBody]ProductTypeViewModel model)
		{
			var result = this._ProductTypesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductTypes/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductTypes/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<ProductTypeViewModel> collection)
		{
			this._ProductTypesService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductTypes/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductTypes/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._ProductTypesService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductTypes/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductTypes/delete 
		 */
		public void Delete([FromBody]ProductTypeViewModel model)
		{
			this._ProductTypesService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductTypes/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductTypes/delete/1 
		 */
		public void Delete(long id)
		{
			this._ProductTypesService.Delete(id);
		}

		#endregion
	}
}
