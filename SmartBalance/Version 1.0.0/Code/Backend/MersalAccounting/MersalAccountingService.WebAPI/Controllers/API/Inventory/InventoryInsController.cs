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
	/// InventoryIns Controller
	/// </summary>
	[RoutePrefix("api/InventoryIns")]
	public class InventoryInsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IInventoryInsService _InventoryInsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryInController.
		/// </summary>
		/// <param name="InventoryInsService">The injected service.</param>
		public InventoryInsController(IInventoryInsService InventoryInsService)
		{
			this._InventoryInsService = InventoryInsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryInViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryIns/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryIns/get-by-condition 
		 */
		public GenericCollectionViewModel<InventoryInViewModel> Get(ConditionFilter<InventoryIn, long> condition)
		{
			var result = this._InventoryInsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryInViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryIns/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryIns/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<InventoryInViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._InventoryInsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryInViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryIns/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryIns/get-light-by-condition 
		 */
		public GenericCollectionViewModel<InventoryInLightViewModel> GetLightModel(ConditionFilter<InventoryIn, long> condition)
		{
			var result = this._InventoryInsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryInViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryIns/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryIns/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<InventoryInLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._InventoryInsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a InventoryInViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryIns/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryIns/get/1 
		 */
		public InventoryInViewModel Get(long id)
		{
			var result = this._InventoryInsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryIns/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryIns/add-collection 
		 */
		public IList<InventoryInViewModel> Add([FromBody]IEnumerable<InventoryInViewModel> collection)
		{
			var result = this._InventoryInsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryIns/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryIns/add 
		 */
		public InventoryInViewModel Add([FromBody]InventoryInViewModel model)
		{
			var result = this._InventoryInsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryIns/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryIns/update-collection 
		 */
		public IList<InventoryInViewModel> Update([FromBody]IEnumerable<InventoryInViewModel> collection)
		{
			var result = this._InventoryInsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryIns/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryIns/update 
		 */
		public InventoryInViewModel Update([FromBody]InventoryInViewModel model)
		{
			var result = this._InventoryInsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryIns/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryIns/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<InventoryInViewModel> collection)
		{
			this._InventoryInsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryIns/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryIns/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._InventoryInsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryIns/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryIns/delete 
		 */
		public void Delete([FromBody]InventoryInViewModel model)
		{
			this._InventoryInsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryIns/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryIns/delete/1 
		 */
		public void Delete(long id)
		{
			this._InventoryInsService.Delete(id);
		}

		#endregion
	}
}
