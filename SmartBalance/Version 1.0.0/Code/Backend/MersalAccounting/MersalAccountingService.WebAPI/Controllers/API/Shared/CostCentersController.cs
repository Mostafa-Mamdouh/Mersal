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
	/// CostCenters Controller
	/// </summary>
	[RoutePrefix("api/CostCenters")]
	public class CostCentersController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ICostCentersService _CostCentersService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type CostCenterController.
		/// </summary>
		/// <param name="CostCentersService">The injected service.</param>
		public CostCentersController(ICostCentersService CostCentersService)
		{
			this._CostCentersService = CostCentersService;
		}
        #endregion

        #region Actions

        [Route("get-with-filter")]
        [HttpPost]
        public GenericCollectionViewModel<ListCostCenterLightViewModel> GetByFilter([FromBody]CostCenterFilterViewModel model)
        {
            var result = this._CostCentersService.GetByFilter(model);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of CostCenterViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenters/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenters/get-by-condition 
		 */
		public GenericCollectionViewModel<CostCenterViewModel> Get(ConditionFilter<CostCenter, long> condition)
		{
			var result = this._CostCentersService.Get(condition);
			return result;
		}
        [Route("get-lookup")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenters/get-lookup
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenters/get-lookup
		 */
        public List<CostCenterLightViewModel> GetLookup()
        {
            var result = this._CostCentersService.GetLookUp();
            return result;
        }
        /// <summary>
        /// Gets a GenericCollectionViewModel of CostCenterViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenters/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenters/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<CostCenterViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._CostCentersService.Get(pageIndex, pageSize);
			return result;
		}

        [Route("get-employees-cost-center")]
        [HttpGet]
        public GenericCollectionViewModel<CostCenterLightViewModel> GetEmployeesCostCenter()
        {
            var result = this._CostCentersService.GetEmployeesCostCenter();
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of CostCenterViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenters/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenters/get-light-by-condition 
		 */
		public GenericCollectionViewModel<CostCenterLightViewModel> GetLightModel(ConditionFilter<CostCenter, long> condition)
		{
			var result = this._CostCentersService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CostCenterViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenters/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenters/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<CostCenterLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._CostCentersService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a CostCenterViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenters/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenters/get/1 
		 */
		public CostCenterViewModel Get(long id)
		{
			var result = this._CostCentersService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenters/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenters/add-collection 
		 */
		public IList<CostCenterViewModel> Add([FromBody]IEnumerable<CostCenterViewModel> collection)
		{
			var result = this._CostCentersService.Add(collection);
			return result;
		}

		/// <summary>
		/// Add an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("add")]
		[HttpPost] 
        [JwtAuthentication(Permissions.AddCostCenter)]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenters/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenters/add 
		 */
        public CostCenterViewModel Add([FromBody]CostCenterViewModel model)
		{
			var result = this._CostCentersService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenters/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenters/update-collection 
		 */
		public IList<CostCenterViewModel> Update([FromBody]IEnumerable<CostCenterViewModel> collection)
		{
			var result = this._CostCentersService.Update(collection);
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
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenters/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenters/update 
		 */
		public CostCenterViewModel Update([FromBody]CostCenterViewModel model)
		{
			var result = this._CostCentersService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenters/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenters/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<CostCenterViewModel> collection)
		{
			this._CostCentersService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenters/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenters/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._CostCentersService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenters/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenters/delete 
		 */
		public void Delete([FromBody]CostCenterViewModel model)
		{
			this._CostCentersService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenters/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenters/delete/1 
		 */
		public void Delete(long id)
		{
			this._CostCentersService.Delete(id);
		}

		#endregion
	}
}
