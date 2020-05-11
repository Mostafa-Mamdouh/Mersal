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
	/// StoreMeasurementUnits Controller
	/// </summary>
	[RoutePrefix("api/StoreMeasurementUnits")]
	public class StoreMeasurementUnitsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IStoreMeasurementUnitsService _StoreMeasurementUnitsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type StoreMeasurementUnitController.
		/// </summary>
		/// <param name="StoreMeasurementUnitsService">The injected service.</param>
		public StoreMeasurementUnitsController(IStoreMeasurementUnitsService StoreMeasurementUnitsService)
		{
			this._StoreMeasurementUnitsService = StoreMeasurementUnitsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of StoreMeasurementUnitViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMeasurementUnits/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMeasurementUnits/get-by-condition 
		 */
		public GenericCollectionViewModel<StoreMeasurementUnitViewModel> Get(ConditionFilter<StoreMeasurementUnit, long> condition)
		{
			var result = this._StoreMeasurementUnitsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of StoreMeasurementUnitViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMeasurementUnits/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMeasurementUnits/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<StoreMeasurementUnitViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._StoreMeasurementUnitsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of StoreMeasurementUnitViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMeasurementUnits/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMeasurementUnits/get-light-by-condition 
		 */
		public GenericCollectionViewModel<StoreMeasurementUnitLightViewModel> GetLightModel(ConditionFilter<StoreMeasurementUnit, long> condition)
		{
			var result = this._StoreMeasurementUnitsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of StoreMeasurementUnitViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMeasurementUnits/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMeasurementUnits/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<StoreMeasurementUnitLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._StoreMeasurementUnitsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a StoreMeasurementUnitViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMeasurementUnits/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMeasurementUnits/get/1 
		 */
		public StoreMeasurementUnitViewModel Get(long id)
		{
			var result = this._StoreMeasurementUnitsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMeasurementUnits/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMeasurementUnits/add-collection 
		 */
		public IList<StoreMeasurementUnitViewModel> Add([FromBody]IEnumerable<StoreMeasurementUnitViewModel> collection)
		{
			var result = this._StoreMeasurementUnitsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMeasurementUnits/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMeasurementUnits/add 
		 */
		public StoreMeasurementUnitViewModel Add([FromBody]StoreMeasurementUnitViewModel model)
		{
			var result = this._StoreMeasurementUnitsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMeasurementUnits/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMeasurementUnits/update-collection 
		 */
		public IList<StoreMeasurementUnitViewModel> Update([FromBody]IEnumerable<StoreMeasurementUnitViewModel> collection)
		{
			var result = this._StoreMeasurementUnitsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMeasurementUnits/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMeasurementUnits/update 
		 */
		public StoreMeasurementUnitViewModel Update([FromBody]StoreMeasurementUnitViewModel model)
		{
			var result = this._StoreMeasurementUnitsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMeasurementUnits/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMeasurementUnits/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<StoreMeasurementUnitViewModel> collection)
		{
			this._StoreMeasurementUnitsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMeasurementUnits/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMeasurementUnits/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._StoreMeasurementUnitsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMeasurementUnits/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMeasurementUnits/delete 
		 */
		public void Delete([FromBody]StoreMeasurementUnitViewModel model)
		{
			this._StoreMeasurementUnitsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/StoreMeasurementUnits/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/StoreMeasurementUnits/delete/1 
		 */
		public void Delete(long id)
		{
			this._StoreMeasurementUnitsService.Delete(id);
		}

		#endregion
	}
}
