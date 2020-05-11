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
	/// ReceivingMethods Controller
	/// </summary>
	[RoutePrefix("api/ReceivingMethods")]
	public class ReceivingMethodsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IReceivingMethodsService _ReceivingMethodsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type ReceivingMethodController.
		/// </summary>
		/// <param name="ReceivingMethodsService">The injected service.</param>
		public ReceivingMethodsController(IReceivingMethodsService ReceivingMethodsService)
		{
			this._ReceivingMethodsService = ReceivingMethodsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of ReceivingMethodViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ReceivingMethods/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ReceivingMethods/get-by-condition 
		 */
		public GenericCollectionViewModel<ReceivingMethodViewModel> Get(ConditionFilter<ReceivingMethod, int> condition)
		{
			var result = this._ReceivingMethodsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ReceivingMethodViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ReceivingMethods/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ReceivingMethods/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<ReceivingMethodViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._ReceivingMethodsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ReceivingMethodViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ReceivingMethods/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ReceivingMethods/get-light-by-condition 
		 */
		public GenericCollectionViewModel<ReceivingMethodLightViewModel> GetLightModel(ConditionFilter<ReceivingMethod, int> condition)
		{
			var result = this._ReceivingMethodsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ReceivingMethodViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ReceivingMethods/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ReceivingMethods/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<ReceivingMethodLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._ReceivingMethodsService.GetLightModel(pageIndex, pageSize);
			return result;
		}
        [Route("get-lookup")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ReceivingMethods/get-lookup
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ReceivingMethods/get-lookup
		 */
        public List<ReceivingMethodLightViewModel> GetLookup()
        {
            var result = this._ReceivingMethodsService.GetLookUp();
            return result;
        }
        /// <summary>
        /// Gets a ReceivingMethodViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ReceivingMethods/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ReceivingMethods/get/1 
		 */
		public ReceivingMethodViewModel Get(int id)
		{
			var result = this._ReceivingMethodsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ReceivingMethods/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ReceivingMethods/add-collection 
		 */
		public IList<ReceivingMethodViewModel> Add([FromBody]IEnumerable<ReceivingMethodViewModel> collection)
		{
			var result = this._ReceivingMethodsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ReceivingMethods/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ReceivingMethods/add 
		 */
		public ReceivingMethodViewModel Add([FromBody]ReceivingMethodViewModel model)
		{
			var result = this._ReceivingMethodsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ReceivingMethods/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ReceivingMethods/update-collection 
		 */
		public IList<ReceivingMethodViewModel> Update([FromBody]IEnumerable<ReceivingMethodViewModel> collection)
		{
			var result = this._ReceivingMethodsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ReceivingMethods/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ReceivingMethods/update 
		 */
		public ReceivingMethodViewModel Update([FromBody]ReceivingMethodViewModel model)
		{
			var result = this._ReceivingMethodsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ReceivingMethods/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ReceivingMethods/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<ReceivingMethodViewModel> collection)
		{
			this._ReceivingMethodsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ReceivingMethods/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ReceivingMethods/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<int> collection)
		{
			this._ReceivingMethodsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ReceivingMethods/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ReceivingMethods/delete 
		 */
		public void Delete([FromBody]ReceivingMethodViewModel model)
		{
			this._ReceivingMethodsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ReceivingMethods/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ReceivingMethods/delete/1 
		 */
		public void Delete(int id)
		{
			this._ReceivingMethodsService.Delete(id);
		}

		#endregion
	}
}
