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
	/// VendorTypes Controller
	/// </summary>
	[RoutePrefix("api/VendorTypes")]
	public class VendorTypesController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IVendorTypesService _VendorTypesService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type VendorTypeController.
		/// </summary>
		/// <param name="VendorTypesService">The injected service.</param>
		public VendorTypesController(IVendorTypesService VendorTypesService)
		{
			this._VendorTypesService = VendorTypesService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of VendorTypeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/VendorTypes/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/VendorTypes/get-by-condition 
		 */
		public GenericCollectionViewModel<VendorTypeViewModel> Get(ConditionFilter<VendorType, long> condition)
		{
			var result = this._VendorTypesService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of VendorTypeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/VendorTypes/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/VendorTypes/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<VendorTypeViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._VendorTypesService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of VendorTypeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/VendorTypes/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/VendorTypes/get-light-by-condition 
		 */
		public GenericCollectionViewModel<VendorTypeLightViewModel> GetLightModel(ConditionFilter<VendorType, long> condition)
		{
			var result = this._VendorTypesService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of VendorTypeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/VendorTypes/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/VendorTypes/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<VendorTypeLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._VendorTypesService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a VendorTypeViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/VendorTypes/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/VendorTypes/get/1 
		 */
		public VendorTypeViewModel Get(long id)
		{
			var result = this._VendorTypesService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/VendorTypes/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/VendorTypes/add-collection 
		 */
		public IList<VendorTypeViewModel> Add([FromBody]IEnumerable<VendorTypeViewModel> collection)
		{
			var result = this._VendorTypesService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/VendorTypes/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/VendorTypes/add 
		 */
		public VendorTypeViewModel Add([FromBody]VendorTypeViewModel model)
		{
			var result = this._VendorTypesService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/VendorTypes/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/VendorTypes/update-collection 
		 */
		public IList<VendorTypeViewModel> Update([FromBody]IEnumerable<VendorTypeViewModel> collection)
		{
			var result = this._VendorTypesService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/VendorTypes/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/VendorTypes/update 
		 */
		public VendorTypeViewModel Update([FromBody]VendorTypeViewModel model)
		{
			var result = this._VendorTypesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/VendorTypes/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/VendorTypes/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<VendorTypeViewModel> collection)
		{
			this._VendorTypesService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/VendorTypes/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/VendorTypes/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._VendorTypesService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/VendorTypes/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/VendorTypes/delete 
		 */
		public void Delete([FromBody]VendorTypeViewModel model)
		{
			this._VendorTypesService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/VendorTypes/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/VendorTypes/delete/1 
		 */
		public void Delete(long id)
		{
			this._VendorTypesService.Delete(id);
		}

		#endregion
	}
}
