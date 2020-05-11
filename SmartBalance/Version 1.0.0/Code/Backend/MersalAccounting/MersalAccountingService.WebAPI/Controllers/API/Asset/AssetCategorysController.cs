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
	/// AssetCategorys Controller
	/// </summary>
	[RoutePrefix("api/AssetCategorys")]
	public class AssetCategorysController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IAssetCategorysService _AssetCategorysService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AssetCategoryController.
		/// </summary>
		/// <param name="AssetCategorysService">The injected service.</param>
		public AssetCategorysController(IAssetCategorysService AssetCategorysService)
		{
			this._AssetCategorysService = AssetCategorysService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of AssetCategoryViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetCategorys/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetCategorys/get-by-condition 
		 */
		public GenericCollectionViewModel<AssetCategoryViewModel> Get(ConditionFilter<AssetCategory, long> condition)
		{
			var result = this._AssetCategorysService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AssetCategoryViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetCategorys/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetCategorys/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<AssetCategoryViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._AssetCategorysService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AssetCategoryViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetCategorys/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetCategorys/get-light-by-condition 
		 */
		public GenericCollectionViewModel<AssetCategoryLightViewModel> GetLightModel(ConditionFilter<AssetCategory, long> condition)
		{
			var result = this._AssetCategorysService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AssetCategoryViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetCategorys/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetCategorys/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<AssetCategoryLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._AssetCategorysService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a AssetCategoryViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetCategorys/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetCategorys/get/1 
		 */
		public AssetCategoryViewModel Get(long id)
		{
			var result = this._AssetCategorysService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetCategorys/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetCategorys/add-collection 
		 */
		public IList<AssetCategoryViewModel> Add([FromBody]IEnumerable<AssetCategoryViewModel> collection)
		{
			var result = this._AssetCategorysService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetCategorys/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetCategorys/add 
		 */
		public AssetCategoryViewModel Add([FromBody]AssetCategoryViewModel model)
		{
			var result = this._AssetCategorysService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetCategorys/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetCategorys/update-collection 
		 */
		public IList<AssetCategoryViewModel> Update([FromBody]IEnumerable<AssetCategoryViewModel> collection)
		{
			var result = this._AssetCategorysService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetCategorys/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetCategorys/update 
		 */
		public AssetCategoryViewModel Update([FromBody]AssetCategoryViewModel model)
		{
			var result = this._AssetCategorysService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetCategorys/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetCategorys/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<AssetCategoryViewModel> collection)
		{
			this._AssetCategorysService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetCategorys/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetCategorys/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._AssetCategorysService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetCategorys/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetCategorys/delete 
		 */
		public void Delete([FromBody]AssetCategoryViewModel model)
		{
			this._AssetCategorysService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AssetCategorys/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AssetCategorys/delete/1 
		 */
		public void Delete(long id)
		{
			this._AssetCategorysService.Delete(id);
		}

		#endregion
	}
}
