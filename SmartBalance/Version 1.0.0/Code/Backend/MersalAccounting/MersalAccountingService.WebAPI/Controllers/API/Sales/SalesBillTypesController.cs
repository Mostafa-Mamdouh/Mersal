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
	/// SalesBillTypes Controller
	/// </summary>
	[RoutePrefix("api/SalesBillTypes")]
	public class SalesBillTypesController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ISalesBillTypesService _SalesBillTypesService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type SalesBillTypeController.
		/// </summary>
		/// <param name="SalesBillTypesService">The injected service.</param>
		public SalesBillTypesController(ISalesBillTypesService SalesBillTypesService)
		{
			this._SalesBillTypesService = SalesBillTypesService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of SalesBillTypeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesBillTypes/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesBillTypes/get-by-condition 
		 */
		public GenericCollectionViewModel<SalesBillTypeViewModel> Get(ConditionFilter<SalesBillType, long> condition)
		{
			var result = this._SalesBillTypesService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of SalesBillTypeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesBillTypes/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesBillTypes/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<SalesBillTypeViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._SalesBillTypesService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of SalesBillTypeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesBillTypes/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesBillTypes/get-light-by-condition 
		 */
		public GenericCollectionViewModel<SalesBillTypeLightViewModel> GetLightModel(ConditionFilter<SalesBillType, long> condition)
		{
			var result = this._SalesBillTypesService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of SalesBillTypeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesBillTypes/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesBillTypes/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<SalesBillTypeLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._SalesBillTypesService.GetLightModel(pageIndex, pageSize);
			return result;
		}

        [Route("get-lookup")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesBillTypes/get-lookup
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesBillTypes/get-lookup
		 */
        public List<SalesBillTypeLightViewModel> GetLookup()
        {
            var result = this._SalesBillTypesService.GetLookUp();
            return result;
        }

        /// <summary>
        /// Gets a SalesBillTypeViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesBillTypes/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesBillTypes/get/1 
		 */
		public SalesBillTypeViewModel Get(long id)
		{
			var result = this._SalesBillTypesService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesBillTypes/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesBillTypes/add-collection 
		 */
		public IList<SalesBillTypeViewModel> Add([FromBody]IEnumerable<SalesBillTypeViewModel> collection)
		{
			var result = this._SalesBillTypesService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesBillTypes/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesBillTypes/add 
		 */
		public SalesBillTypeViewModel Add([FromBody]SalesBillTypeViewModel model)
		{
			var result = this._SalesBillTypesService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesBillTypes/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesBillTypes/update-collection 
		 */
		public IList<SalesBillTypeViewModel> Update([FromBody]IEnumerable<SalesBillTypeViewModel> collection)
		{
			var result = this._SalesBillTypesService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesBillTypes/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesBillTypes/update 
		 */
		public SalesBillTypeViewModel Update([FromBody]SalesBillTypeViewModel model)
		{
			var result = this._SalesBillTypesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesBillTypes/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesBillTypes/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<SalesBillTypeViewModel> collection)
		{
			this._SalesBillTypesService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesBillTypes/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesBillTypes/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._SalesBillTypesService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesBillTypes/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesBillTypes/delete 
		 */
		public void Delete([FromBody]SalesBillTypeViewModel model)
		{
			this._SalesBillTypesService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesBillTypes/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesBillTypes/delete/1 
		 */
		public void Delete(long id)
		{
			this._SalesBillTypesService.Delete(id);
		}

		#endregion
	}
}
