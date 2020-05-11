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
	/// ProductPrices Controller
	/// </summary>
	[RoutePrefix("api/ProductPrices")]
	public class ProductPricesController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IProductPricesService _ProductPricesService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type ProductPriceController.
		/// </summary>
		/// <param name="ProductPricesService">The injected service.</param>
		public ProductPricesController(IProductPricesService ProductPricesService)
		{
			this._ProductPricesService = ProductPricesService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of ProductPriceViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductPrices/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductPrices/get-by-condition 
		 */
		public GenericCollectionViewModel<ProductPriceViewModel> Get(ConditionFilter<ProductPrice, long> condition)
		{
			var result = this._ProductPricesService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ProductPriceViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductPrices/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductPrices/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<ProductPriceViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._ProductPricesService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ProductPriceViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductPrices/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductPrices/get-light-by-condition 
		 */
		public GenericCollectionViewModel<ProductPriceLightViewModel> GetLightModel(ConditionFilter<ProductPrice, long> condition)
		{
			var result = this._ProductPricesService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ProductPriceViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductPrices/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductPrices/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<ProductPriceLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._ProductPricesService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a ProductPriceViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductPrices/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductPrices/get/1 
		 */
		public ProductPriceViewModel Get(long id)
		{
			var result = this._ProductPricesService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductPrices/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductPrices/add-collection 
		 */
		public IList<ProductPriceViewModel> Add([FromBody]IEnumerable<ProductPriceViewModel> collection)
		{
			var result = this._ProductPricesService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductPrices/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductPrices/add 
		 */
		public ProductPriceViewModel Add([FromBody]ProductPriceViewModel model)
		{
			var result = this._ProductPricesService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductPrices/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductPrices/update-collection 
		 */
		public IList<ProductPriceViewModel> Update([FromBody]IEnumerable<ProductPriceViewModel> collection)
		{
			var result = this._ProductPricesService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductPrices/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductPrices/update 
		 */
		public ProductPriceViewModel Update([FromBody]ProductPriceViewModel model)
		{
			var result = this._ProductPricesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductPrices/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductPrices/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<ProductPriceViewModel> collection)
		{
			this._ProductPricesService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductPrices/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductPrices/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._ProductPricesService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductPrices/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductPrices/delete 
		 */
		public void Delete([FromBody]ProductPriceViewModel model)
		{
			this._ProductPricesService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ProductPrices/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ProductPrices/delete/1 
		 */
		public void Delete(long id)
		{
			this._ProductPricesService.Delete(id);
		}

		#endregion
	}
}
