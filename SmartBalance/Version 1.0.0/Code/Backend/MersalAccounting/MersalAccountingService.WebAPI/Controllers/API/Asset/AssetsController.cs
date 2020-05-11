#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using MersalAccountingService.WebAPI.Auth;
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
	/// Assets Controller
	/// </summary>
	[RoutePrefix("api/Assets")]
	public class AssetsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IAssetsService _AssetsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AssetController.
		/// </summary>
		/// <param name="AssetsService">The injected service.</param>
		public AssetsController(IAssetsService AssetsService)
		{
			this._AssetsService = AssetsService;
		}
        #endregion

        #region Actions

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Assets/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Assets/get-by-condition 
		 */
		public GenericCollectionViewModel<AssetViewModel> Get(ConditionFilter<Asset, long> condition)
		{
			var result = this._AssetsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AssetViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Assets/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Assets/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<AssetViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._AssetsService.Get(pageIndex, pageSize);
			return result;
		}

        [Route("get-Lookup")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Assets/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Assets/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<AssetLookupViewModel> Get()
        {
            var result = this._AssetsService.GetLookup();
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Assets/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Assets/get-light-by-condition 
		 */
		public GenericCollectionViewModel<AssetLightViewModel> GetLightModel(ConditionFilter<Asset, long> condition)
		{
			var result = this._AssetsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AssetViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Assets/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Assets/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<AssetLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._AssetsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a AssetViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		[JwtAuthentication(Permissions.ReceivedFixedAssetsList)]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Assets/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Assets/get/1 
		 */
		public AssetViewModel Get(long id)
		{
			var result = this._AssetsService.Get(id);
			return result;
		}

        [Route("get-with-filter")]
        [HttpPost]
        [JwtAuthentication(Permissions.ReceivedFixedAssetsList)]
        public GenericCollectionViewModel<ListAssetLightViewModel> GetByFilter(AssetFilterViewModel model)
        {
            var result = this._AssetsService.GetByFilter(model);
            return result;
        }

        [Route("get-asset-details-by-location/{locationId}")]
        [HttpPost]
        public IList<AssetInventoryDetailLightViewModel> GetAssetDetailsByLocation(long locationId)
        {
            return this._AssetsService.GetAssetDetailsByLocation(locationId);
        }

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("add-collection")]
		[HttpPost]
		[JwtAuthentication(Permissions.AddReceivedFixedAsset)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Assets/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Assets/add-collection 
		 */
		public IList<AssetViewModel> Add([FromBody]IEnumerable<AssetViewModel> collection)
		{
			var result = this._AssetsService.Add(collection);
			return result;
		}

		/// <summary>
		/// Add an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("add")]
		[HttpPost]
		[JwtAuthentication(Permissions.AddReceivedFixedAsset)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Assets/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Assets/add 
		 */
		public AssetViewModel Add([FromBody]AssetViewModel model)
		{
			var result = this._AssetsService.Add(model);
			return result;
		}


		/// <summary>
		/// Update entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		[Route("update-collection")]
		[HttpPost]
		[JwtAuthentication(Permissions.EditReceivedFixedAsset)]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Assets/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Assets/update-collection 
		 */
		public IList<AssetViewModel> Update([FromBody]IEnumerable<AssetViewModel> collection)
		{
			var result = this._AssetsService.Update(collection);
			return result;
		}

		/// <summary>
		/// Update an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("update")]
		[HttpPost]
		[JwtAuthentication(Permissions.EditReceivedFixedAsset)]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Assets/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Assets/update 
		 */
		public AssetViewModel Update([FromBody]AssetViewModel model)
		{
			var result = this._AssetsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Assets/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Assets/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<AssetViewModel> collection)
		{
			this._AssetsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Assets/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Assets/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._AssetsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Assets/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Assets/delete 
		 */
		public void Delete([FromBody]AssetViewModel model)
		{
			this._AssetsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Assets/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Assets/delete/1 
		 */
		public void Delete(long id)
		{
			this._AssetsService.Delete(id);
		}

		#endregion
	}
}
