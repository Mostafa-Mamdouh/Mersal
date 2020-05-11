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
	/// InventoryMovementType Controller
	/// </summary>
	[RoutePrefix("api/InventoryMovementType")]
	public class InventoryMovementTypeController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IInventoryMovementTypeService _InventoryMovementTypeService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryMovementTypeController.
		/// </summary>
		/// <param name="InventoryMovementTypeService">The injected service.</param>
		public InventoryMovementTypeController(IInventoryMovementTypeService InventoryMovementTypeService)
		{
			this._InventoryMovementTypeService = InventoryMovementTypeService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryMovementTypeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementType/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementType/get-by-condition 
		 */
		public GenericCollectionViewModel<InventoryMovementTypeViewModel> Get(ConditionFilter<InventoryMovementType, long> condition)
		{
			var result = this._InventoryMovementTypeService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryMovementTypeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementType/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementType/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<InventoryMovementTypeViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._InventoryMovementTypeService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryMovementTypeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementType/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementType/get-light-by-condition 
		 */
		public GenericCollectionViewModel<InventoryMovementTypeLightViewModel> GetLightModel(ConditionFilter<InventoryMovementType, long> condition)
		{
			var result = this._InventoryMovementTypeService.GetLightModel(condition);
			return result;
		}


        [Route("get-lookup")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementType/get-lookup
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementType/get-lookup
		 */
        public List<InventoryMovementTypeLightViewModel> GetLookup()
        {
            var result = this._InventoryMovementTypeService.GetLookUp();
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryMovementTypeViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementType/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementType/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<InventoryMovementTypeLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._InventoryMovementTypeService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a InventoryMovementTypeViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementType/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementType/get/1 
		 */
		public InventoryMovementTypeViewModel Get(long id)
		{
			var result = this._InventoryMovementTypeService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementType/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementType/add-collection 
		 */
		public IList<InventoryMovementTypeViewModel> Add([FromBody]IEnumerable<InventoryMovementTypeViewModel> collection)
		{
			var result = this._InventoryMovementTypeService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementType/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementType/add 
		 */
		public InventoryMovementTypeViewModel Add([FromBody]InventoryMovementTypeViewModel model)
		{
			var result = this._InventoryMovementTypeService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementType/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementType/update-collection 
		 */
		public IList<InventoryMovementTypeViewModel> Update([FromBody]IEnumerable<InventoryMovementTypeViewModel> collection)
		{
			var result = this._InventoryMovementTypeService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementType/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementType/update 
		 */
		public InventoryMovementTypeViewModel Update([FromBody]InventoryMovementTypeViewModel model)
		{
			var result = this._InventoryMovementTypeService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementType/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementType/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<InventoryMovementTypeViewModel> collection)
		{
			this._InventoryMovementTypeService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementType/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementType/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._InventoryMovementTypeService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementType/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementType/delete 
		 */
		public void Delete([FromBody]InventoryMovementTypeViewModel model)
		{
			this._InventoryMovementTypeService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/InventoryMovementType/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/InventoryMovementType/delete/1 
		 */
		public void Delete(long id)
		{
			this._InventoryMovementTypeService.Delete(id);
		}

		#endregion
	}
}
