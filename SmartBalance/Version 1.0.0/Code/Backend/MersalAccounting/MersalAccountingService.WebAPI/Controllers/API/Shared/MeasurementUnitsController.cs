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
	/// MeasurementUnits Controller
	/// </summary>
	[RoutePrefix("api/MeasurementUnits")]
	public class MeasurementUnitsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IMeasurementUnitsService _MeasurementUnitsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type MeasurementUnitController.
		/// </summary>
		/// <param name="MeasurementUnitsService">The injected service.</param>
		public MeasurementUnitsController(IMeasurementUnitsService MeasurementUnitsService)
		{
			this._MeasurementUnitsService = MeasurementUnitsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of MeasurementUnitViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MeasurementUnits/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MeasurementUnits/get-by-condition 
		 */
		public GenericCollectionViewModel<MeasurementUnitViewModel> Get(ConditionFilter<MeasurementUnit, long> condition)
		{
			var result = this._MeasurementUnitsService.Get(condition);
			return result;
		}
        [Route("get-lookup")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Products/get-lookup
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Products/get-lookup
		 */
        public List<MeasurementUnitLightViewModel> GetLookup()
        {
            var result = this._MeasurementUnitsService.GetLookUp();
            return result;
        }
        /// <summary>
        /// Gets a GenericCollectionViewModel of MeasurementUnitViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MeasurementUnits/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MeasurementUnits/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<MeasurementUnitViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._MeasurementUnitsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of MeasurementUnitViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MeasurementUnits/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MeasurementUnits/get-light-by-condition 
		 */
		public GenericCollectionViewModel<MeasurementUnitLightViewModel> GetLightModel(ConditionFilter<MeasurementUnit, long> condition)
		{
			var result = this._MeasurementUnitsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of MeasurementUnitViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MeasurementUnits/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MeasurementUnits/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<MeasurementUnitLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._MeasurementUnitsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a MeasurementUnitViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MeasurementUnits/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MeasurementUnits/get/1 
		 */
		public MeasurementUnitViewModel Get(long id)
		{
			var result = this._MeasurementUnitsService.Get(id);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ListMeasurementUnitsLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-with-filter")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MeasurementUnits/get-with-filter
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MeasurementUnits/get-with-filter 
		 */
		public GenericCollectionViewModel<ListMeasurementUnitsLightViewModel> GetByFilter([FromBody]MeasurementUnitFilterViewModel model)
		{
			var result = this._MeasurementUnitsService.GetByFilter(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MeasurementUnits/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MeasurementUnits/add-collection 
		 */
		public IList<MeasurementUnitViewModel> Add([FromBody]IEnumerable<MeasurementUnitViewModel> collection)
		{
			var result = this._MeasurementUnitsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MeasurementUnits/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MeasurementUnits/add 
		 */
		public MeasurementUnitViewModel Add([FromBody]MeasurementUnitViewModel model)
		{
			var result = this._MeasurementUnitsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MeasurementUnits/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MeasurementUnits/update-collection 
		 */
		public IList<MeasurementUnitViewModel> Update([FromBody]IEnumerable<MeasurementUnitViewModel> collection)
		{
			var result = this._MeasurementUnitsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MeasurementUnits/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MeasurementUnits/update 
		 */
		public MeasurementUnitViewModel Update([FromBody]MeasurementUnitViewModel model)
		{
			var result = this._MeasurementUnitsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MeasurementUnits/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MeasurementUnits/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<MeasurementUnitViewModel> collection)
		{
			this._MeasurementUnitsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MeasurementUnits/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MeasurementUnits/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._MeasurementUnitsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MeasurementUnits/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MeasurementUnits/delete 
		 */
		public void Delete([FromBody]MeasurementUnitViewModel model)
		{
			this._MeasurementUnitsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MeasurementUnits/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MeasurementUnits/delete/1 
		 */
		public void Delete(long id)
		{
			this._MeasurementUnitsService.Delete(id);
		}

		#endregion
	}
}
