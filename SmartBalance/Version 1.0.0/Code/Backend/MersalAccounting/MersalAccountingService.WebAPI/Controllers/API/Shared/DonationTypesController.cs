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
	/// DonationTypes Controller
	/// </summary>
	[RoutePrefix("api/DonationTypes")]
	public class DonationTypesController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IDonationTypesService _DonationTypesService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type DonationTypeController.
		/// </summary>
		/// <param name="DonationTypesService">The injected service.</param>
		public DonationTypesController(IDonationTypesService DonationTypesService)
		{
			this._DonationTypesService = DonationTypesService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of DonationTypeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DonationTypes/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DonationTypes/get-by-condition 
		 */
		public GenericCollectionViewModel<DonationTypeViewModel> Get(ConditionFilter<DonationType, long> condition)
		{
			var result = this._DonationTypesService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of DonationTypeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DonationTypes/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DonationTypes/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<DonationTypeViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._DonationTypesService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of DonationTypeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DonationTypes/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DonationTypes/get-light-by-condition 
		 */
		//public GenericCollectionViewModel<DonationTypeLightViewModel> GetLightModel(ConditionFilter<DonationType, long> condition)
		//{
		//	var result = this._DonationTypesService.GetLightModel(condition);
		//	return result;
		//}

		/// <summary>
		/// Gets a GenericCollectionViewModel of DonationTypeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DonationTypes/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DonationTypes/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<DonationTypeLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._DonationTypesService.GetLightModel(pageIndex, pageSize);
			return result;
		}

        [Route("get-light-by-Id/{id}")]
        [HttpGet]
        public GenericCollectionViewModel<DonationTypeLightViewModel> GetLightModel(int? id)
    {
          
            var result = this._DonationTypesService.GetLightModel(id);
            return result;
        }

        /// <summary>
        /// Gets a DonationTypeViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DonationTypes/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DonationTypes/get/1 
		 */
		public DonationTypeViewModel Get(long id)
		{
			var result = this._DonationTypesService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DonationTypes/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DonationTypes/add-collection 
		 */
		public IList<DonationTypeViewModel> Add([FromBody]IEnumerable<DonationTypeViewModel> collection)
		{
			var result = this._DonationTypesService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DonationTypes/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DonationTypes/add 
		 */
		public DonationTypeViewModel Add([FromBody]DonationTypeViewModel model)
		{
			var result = this._DonationTypesService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DonationTypes/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DonationTypes/update-collection 
		 */
		public IList<DonationTypeViewModel> Update([FromBody]IEnumerable<DonationTypeViewModel> collection)
		{
			var result = this._DonationTypesService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DonationTypes/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DonationTypes/update 
		 */
		public DonationTypeViewModel Update([FromBody]DonationTypeViewModel model)
		{
			var result = this._DonationTypesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DonationTypes/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DonationTypes/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<DonationTypeViewModel> collection)
		{
			this._DonationTypesService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DonationTypes/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DonationTypes/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._DonationTypesService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DonationTypes/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DonationTypes/delete 
		 */
		public void Delete([FromBody]DonationTypeViewModel model)
		{
			this._DonationTypesService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DonationTypes/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DonationTypes/delete/1 
		 */
		public void Delete(long id)
		{
			this._DonationTypesService.Delete(id);
		}

		#endregion
	}
}
