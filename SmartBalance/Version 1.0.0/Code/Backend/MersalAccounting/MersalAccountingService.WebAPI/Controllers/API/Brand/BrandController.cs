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
	/// Brands Controller
	/// </summary>
	[RoutePrefix("api/Brands")]
	public class BrandsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IBrandsService _BrandsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type BrandController.
		/// </summary>
		/// <param name="BrandsService">The injected service.</param>
		public BrandsController(IBrandsService BrandsService)
		{
			this._BrandsService = BrandsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of BrandViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Brands/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Brands/get-by-condition 
		 */
		public GenericCollectionViewModel<BrandViewModel> Get(ConditionFilter<Brand, long> condition)
		{
			var result = this._BrandsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BrandViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Brands/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Brands/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<BrandViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._BrandsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BrandViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Brands/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Brands/get-light-by-condition 
		 */
		public GenericCollectionViewModel<BrandLightViewModel> GetLightModel(ConditionFilter<Brand, long> condition)
		{
			var result = this._BrandsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BrandViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Brands/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Brands/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<BrandLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._BrandsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a BrandViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Brands/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Brands/get/1 
		 */
		public BrandViewModel Get(long id)
		{
			var result = this._BrandsService.Get(id);
			return result;
		}


        [Route("get-lookup")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Brands/get-lookup
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Brands/get-lookup
		 */
        public IList<BrandLightViewModel> GetLookup()
        {
            var result = this._BrandsService.GetLookup();
            return result;
        }

		/// <summary>
		/// Gets a GenericCollectionViewModel of ListBrandsLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-with-filter")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Brands/get-with-filter
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Brands/get-with-filter 
		 */
		public GenericCollectionViewModel<ListBrandsLightViewModel> GetByFilter([FromBody]BrandFilterViewModel model)
		{
			var result = this._BrandsService.GetByFilter(model);
			return result;
		}

        [Route("get-children/{id}")]
        [HttpGet]
        //[JwtAuthentication(Permissions.BanksList)]
        public List<BrandLightViewModel> GetChildren(long id)
        {
            var result = this._BrandsService.GetChildren(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Brands/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Brands/add-collection 
		 */
		public IList<BrandViewModel> Add([FromBody]IEnumerable<BrandViewModel> collection)
		{
			var result = this._BrandsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Brands/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Brands/add 
		 */
		public BrandViewModel Add([FromBody]BrandViewModel model)
		{
			var result = this._BrandsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Brands/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Brands/update-collection 
		 */
		public IList<BrandViewModel> Update([FromBody]IEnumerable<BrandViewModel> collection)
		{
			var result = this._BrandsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Brands/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Brands/update 
		 */
		public BrandViewModel Update([FromBody]BrandViewModel model)
		{
			var result = this._BrandsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Brands/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Brands/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<BrandViewModel> collection)
		{
			this._BrandsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Brands/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Brands/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._BrandsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Brands/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Brands/delete 
		 */
		public void Delete([FromBody]BrandViewModel model)
		{
			this._BrandsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Brands/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Brands/delete/1 
		 */
		public void Delete(long id)
		{
			this._BrandsService.Delete(id);
		}

		#endregion
	}
}
