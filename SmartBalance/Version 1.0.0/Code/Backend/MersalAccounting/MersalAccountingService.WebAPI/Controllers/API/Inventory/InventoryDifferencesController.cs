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
	/// InventoryDifferences Controller
	/// </summary>
	[RoutePrefix("api/InventoryDifferences")]
	public class InventoryDifferencesController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IInventoryDifferencesService _InventoryDifferencesService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryDifferenceController.
		/// </summary>
		/// <param name="InventoryDifferencesService">The injected service.</param>
		public InventoryDifferencesController(IInventoryDifferencesService InventoryDifferencesService)
		{
			this._InventoryDifferencesService = InventoryDifferencesService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryDifferenceViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryDifferences/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryDifferences/get-by-condition 
		 */
		public GenericCollectionViewModel<InventoryDifferenceViewModel> Get(ConditionFilter<InventoryDifference, long> condition)
		{
			var result = this._InventoryDifferencesService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryDifferenceViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryDifferences/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryDifferences/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<InventoryDifferenceViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._InventoryDifferencesService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryDifferenceViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryDifferences/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryDifferences/get-light-by-condition 
		 */
		public GenericCollectionViewModel<InventoryDifferenceLightViewModel> GetLightModel(ConditionFilter<InventoryDifference, long> condition)
		{
			var result = this._InventoryDifferencesService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryDifferenceViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryDifferences/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryDifferences/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<InventoryDifferenceLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._InventoryDifferencesService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a InventoryDifferenceViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryDifferences/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryDifferences/get/1 
		 */
		public InventoryDifferenceViewModel Get(long id)
		{
			var result = this._InventoryDifferencesService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryDifferences/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryDifferences/add-collection 
		 */
		public IList<InventoryDifferenceViewModel> Add([FromBody]IEnumerable<InventoryDifferenceViewModel> collection)
		{
			var result = this._InventoryDifferencesService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryDifferences/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryDifferences/add 
		 */
		public InventoryDifferenceViewModel Add([FromBody]InventoryDifferenceViewModel model)
		{
			var result = this._InventoryDifferencesService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryDifferences/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryDifferences/update-collection 
		 */
		public IList<InventoryDifferenceViewModel> Update([FromBody]IEnumerable<InventoryDifferenceViewModel> collection)
		{
			var result = this._InventoryDifferencesService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryDifferences/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryDifferences/update 
		 */
		public InventoryDifferenceViewModel Update([FromBody]InventoryDifferenceViewModel model)
		{
			var result = this._InventoryDifferencesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryDifferences/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryDifferences/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<InventoryDifferenceViewModel> collection)
		{
			this._InventoryDifferencesService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryDifferences/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryDifferences/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._InventoryDifferencesService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryDifferences/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryDifferences/delete 
		 */
		public void Delete([FromBody]InventoryDifferenceViewModel model)
		{
			this._InventoryDifferencesService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryDifferences/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryDifferences/delete/1 
		 */
		public void Delete(long id)
		{
			this._InventoryDifferencesService.Delete(id);
		}

		#endregion
	}
}
