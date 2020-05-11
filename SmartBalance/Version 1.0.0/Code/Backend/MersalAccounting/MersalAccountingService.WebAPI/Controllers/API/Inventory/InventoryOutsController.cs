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
	/// InventoryOuts Controller
	/// </summary>
	[RoutePrefix("api/InventoryOuts")]
	public class InventoryOutsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IInventoryOutsService _InventoryOutsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryOutController.
		/// </summary>
		/// <param name="InventoryOutsService">The injected service.</param>
		public InventoryOutsController(IInventoryOutsService InventoryOutsService)
		{
			this._InventoryOutsService = InventoryOutsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryOutViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOuts/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOuts/get-by-condition 
		 */
		public GenericCollectionViewModel<InventoryOutViewModel> Get(ConditionFilter<InventoryOut, long> condition)
		{
			var result = this._InventoryOutsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryOutViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOuts/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOuts/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<InventoryOutViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._InventoryOutsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryOutViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOuts/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOuts/get-light-by-condition 
		 */
		public GenericCollectionViewModel<InventoryOutLightViewModel> GetLightModel(ConditionFilter<InventoryOut, long> condition)
		{
			var result = this._InventoryOutsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryOutViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOuts/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOuts/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<InventoryOutLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._InventoryOutsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a InventoryOutViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOuts/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOuts/get/1 
		 */
		public InventoryOutViewModel Get(long id)
		{
			var result = this._InventoryOutsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOuts/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOuts/add-collection 
		 */
		public IList<InventoryOutViewModel> Add([FromBody]IEnumerable<InventoryOutViewModel> collection)
		{
			var result = this._InventoryOutsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOuts/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOuts/add 
		 */
		public InventoryOutViewModel Add([FromBody]InventoryOutViewModel model)
		{
			var result = this._InventoryOutsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOuts/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOuts/update-collection 
		 */
		public IList<InventoryOutViewModel> Update([FromBody]IEnumerable<InventoryOutViewModel> collection)
		{
			var result = this._InventoryOutsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOuts/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOuts/update 
		 */
		public InventoryOutViewModel Update([FromBody]InventoryOutViewModel model)
		{
			var result = this._InventoryOutsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOuts/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOuts/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<InventoryOutViewModel> collection)
		{
			this._InventoryOutsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOuts/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOuts/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._InventoryOutsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOuts/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOuts/delete 
		 */
		public void Delete([FromBody]InventoryOutViewModel model)
		{
			this._InventoryOutsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryOuts/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryOuts/delete/1 
		 */
		public void Delete(long id)
		{
			this._InventoryOutsService.Delete(id);
		}

		#endregion
	}
}
