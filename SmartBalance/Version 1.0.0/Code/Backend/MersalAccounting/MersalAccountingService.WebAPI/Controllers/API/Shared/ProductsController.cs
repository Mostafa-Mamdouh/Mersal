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
	/// Products Controller
	/// </summary>
	[RoutePrefix("api/Products")]
	public class ProductsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IProductsService _ProductsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type ProductController.
		/// </summary>
		/// <param name="ProductsService">The injected service.</param>
		public ProductsController(IProductsService ProductsService)
		{
			this._ProductsService = ProductsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of ProductViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Products/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Products/get-by-condition 
		 */
		public GenericCollectionViewModel<ProductViewModel> Get(ConditionFilter<Product, long> condition)
		{
			var result = this._ProductsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ProductViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Products/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Products/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<ProductViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._ProductsService.Get(pageIndex, pageSize);
			return result;
		}


        /// <summary>
        /// Gets a GenericCollectionViewModel of ProductLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
     /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Products/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Products/get-light-by-condition 
		 */
		public GenericCollectionViewModel<ProductLightViewModel> GetLightModel(ConditionFilter<Product, long> condition)
		{
			var result = this._ProductsService.GetLightModel(condition);
			return result;
		}

        /// <summary>
        /// Gets a GenericCollectionViewModel of ProductViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-lookup")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Products/get-lookup
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Products/get-lookup
		 */
        public List<ProductLightViewModel> GetLookup()
        {
            var result = this._ProductsService.GetLookUp();
            return result;
        }
        /// <summary>
        /// Gets a GenericCollectionViewModel of ProductViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Products/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Products/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<ProductLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._ProductsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a ProductViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Products/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Products/get/1 
		 */
		public ProductViewModel Get(long id)
		{
			var result = this._ProductsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Products/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Products/add-collection 
		 */
		public IList<ProductViewModel> Add([FromBody]IEnumerable<ProductViewModel> collection)
		{
			var result = this._ProductsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Products/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Products/add 
		 */
		public ProductViewModel Add([FromBody]ProductViewModel model)
		{
			var result = this._ProductsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Products/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Products/update-collection 
		 */
		public IList<ProductViewModel> Update([FromBody]IEnumerable<ProductViewModel> collection)
		{
			var result = this._ProductsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Products/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Products/update 
		 */
		public ProductViewModel Update([FromBody]ProductViewModel model)
		{
			var result = this._ProductsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Products/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Products/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<ProductViewModel> collection)
		{
			this._ProductsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Products/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Products/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._ProductsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Products/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Products/delete 
		 */
		public void Delete([FromBody]ProductViewModel model)
		{
			this._ProductsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Products/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Products/delete/1 
		 */
		public void Delete(long id)
		{
			this._ProductsService.Delete(id);
		}

		#endregion
	}
}
